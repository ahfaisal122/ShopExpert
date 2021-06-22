using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using ShopEx.Controllers;
using ShopEx.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;

namespace Shop.Controllers.App_Start
{
    public class PageInfoController : Controller
    {
        static Dictionary<string, bool> myMap = new Dictionary<string, bool>();
        // GET: PageInfo
        public ActionResult Login1()
        {
            return View();
        }
        public ActionResult Check(string id)
        {
            TempData["id"] = id;
            return View();
        }
        [HttpPost]
        public ActionResult Check2(string searchString)
        {
            var id="";
            if (!string.IsNullOrEmpty(searchString))
            {
                var cat = (from a in db.Categories
                    where a.CategoryName == searchString
                    select a).ToList();
                id = cat[0].CategoryId;
               
            }

            TempData["id"] = id;

            return View("Check");
            if (!string.IsNullOrEmpty(searchString))
            {
                var cat = (from a in db.Categories
                          where a.CategoryName==searchString
                                select a).ToString();
               
                return View("Check2",cat);

            }

            TempData["id"] = 1;
            return View("Check");

        }


        [Authorize]
        public ActionResult PageInformation(string id)
        {

            ViewBag.id = id;
            TempData["iid"] = id;

            if (User.IsInRole("Admin"))
                return View("OwnerPageView");

            var IpAddress = Request.UserHostAddress;
            ApplicationDbContext db= new ApplicationDbContext();
            string s = IpAddress + id;
            bool t;
           
            if (myMap.ContainsKey(s))
            {
               
            }
            else
            {

                myMap.Add(s, true);
                var view = db.PageAccount.SingleOrDefault(i => i.PageId == id);
                view.VisitorCount++;
                db.SaveChanges();
            }



            return View();


        }
        public ActionResult OwnerPageView(string id)
        {

            TempData["iid"] = id;
            return View();


        }
        public ApplicationDbContext db = new ApplicationDbContext();

        // GET: Advertise
        public ActionResult Index()
        {
            return View(db.PageAccount.ToList());
        }

        // GET: Advertise/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PageInfo pageInfo = db.PageAccount.Find(id);
            if (pageInfo == null)
            {
                return HttpNotFound();
            }
            return View(pageInfo);
        }

        // GET: Advertise/Create
        public ActionResult Create()
        {
            return View();
        }
        public ActionResult PageRegister()
        {
            return View();

        }

       
       
        [HttpPost]
        public ActionResult PageRegister(PageInfo account, HttpPostedFileBase file1,string[] sCategories)
        {
            if (ModelState.IsValid)
            {
                
                using (ApplicationDbContext db = new ApplicationDbContext())
                {
                    account.VisitorCount = 0;
                    account.OwnersEmail = User.Identity.GetUserId();
                    if (file1!=null)
                    {
                        account.Picture = new byte[file1.ContentLength];
                        file1.InputStream.Read(account.Picture, 0, file1.ContentLength);


                        string s="";
                        foreach (var a in sCategories)
                        {

                             s =  s+a;
                            
                            Cat cate=db.Categories.FirstOrDefault(i=>i.CategoryId ==a);
                            s = s + cate.CategoryName;
                            if (cate != null)
                            { 
                            account.Cats.Add(cate);
                                }
                        }

                        TempData["ch"] = s;
                       // return View("Check");

                        db.PageAccount.Add(account);
                        db.SaveChanges();
                    }

                }
                ModelState.Clear();
                ViewBag.messsage = account.PageName + " is Successfully Registered";
            }

            return View("Index");
        }

      
        public ActionResult View1()
        {
            return View();

        }
        // POST: Advertise/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PageId,Id,PageName,Password,ConfirmPassword,PageOwnerName,OwnerAddress,OwnersNumber,Description,PageFbLink,PageWebsite,Preference,Delivery,Picture")] PageInfo pageInfo)
        {
            if (ModelState.IsValid)
            {
                db.PageAccount.Add(pageInfo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(pageInfo);
        }

        // GET: Advertise/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PageInfo pageInfo = db.PageAccount.Find(id);
            if (pageInfo == null)
            {
                return HttpNotFound();
            }
            return View(pageInfo);
        }

        // POST: Advertise/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(PageInfo account, HttpPostedFileBase file1, string[] sCategories)
        {
            if (ModelState.IsValid)
            {
                if (file1 != null)
                {
                    account.Picture = new byte[file1.ContentLength];
                    file1.InputStream.Read(account.Picture, 0, file1.ContentLength);


                    string s = "";
                    foreach (var a in sCategories)
                    {

                        s = s + a;

                        Cat cate = db.Categories.FirstOrDefault(i => i.CategoryId == a);
                        s = s + cate.CategoryName;
                        if (cate != null)
                        {
                            account.Cats.Add(cate);
                        }
                    }
                }

                db.Entry(account).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(account);
        }

        // GET: Advertise/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PageInfo pageInfo = db.PageAccount.Find(id);
            if (pageInfo == null)
            {
                return HttpNotFound();
            }
            return View(pageInfo);
        }

        // POST: Advertise/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            PageInfo pageInfo = db.PageAccount.Find(id);
            db.PageAccount.Remove(pageInfo);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
          [HttpPost]
          public ActionResult Login1(PageInfo user)
          {


              using (ApplicationDbContext db = new ApplicationDbContext())
              {
                  var usr = db.PageAccount.FirstOrDefault(u => u.PageId == user.PageId && u.Password == user.Password);

                  if (usr != null)
                  {
                      Session["UserId"] = usr.PageId.ToString();
                      Session["UserName"] = usr.PageName.ToString();
                      return RedirectToAction("LoggedIn");

                  }
                  else
                  {
                      ModelState.AddModelError("", user.PageName);
                  }

              }



              return View();
          }

          public ActionResult LoggedIn()
          {


              if (Session["PageId"] != null)
              {

                  return View("Index");
              }
              else
              {
                  return RedirectToAction("Login1");
              }

          }
    }
}
