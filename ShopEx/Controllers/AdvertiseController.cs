using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ShopEx.Controllers;
using ShopEx.Models;

namespace Shop.Controllers
{
    public class AdvertiseController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

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
        public ActionResult Edit([Bind(Include = "PageId,Id,PageName,Password,ConfirmPassword,PageOwnerName,OwnerAddress,OwnersNumber,Description,PageFbLink,PageWebsite,Preference,Delivery,Picture")] PageInfo pageInfo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pageInfo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(pageInfo);
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
    }
}
