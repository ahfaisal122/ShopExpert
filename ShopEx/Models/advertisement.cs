using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ShopEx.Models
{
    public class advertisement
    {
        [Key]
        public int advertisementId { get; set; }
        public string pageName { get; set; }
        public string ShopExpertpageLink { get; set; }
        public string pageId { get; set; }
        [StringLength(1000)]
        [Required(ErrorMessage = "Give some informaton")]
        public string information { get; set; }
        [Required(ErrorMessage = "Enter a date-1 january 2018")]
        public DateTime validity { get; set; }
        public byte[] pics { get; set; }
    }
}