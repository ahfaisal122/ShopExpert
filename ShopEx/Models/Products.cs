using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ShopEx.Models
{
    public class Products
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int ProductId { get; set; }
        public string PageName { get; set; }
        public string ShopExpertpageLink { get; set; }
        public string pageId { get; set; }
        [StringLength(1000)]
        [Required(ErrorMessage = "Give some informaton")]
        public string information { get; set; }
        public byte[] pics { get; set; }
    }
}