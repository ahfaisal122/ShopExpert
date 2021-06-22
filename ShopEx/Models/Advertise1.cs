using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Linq;
using System.Web;

namespace Shop.Models
{
    public class Advertise1
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }
        public byte[] Adphoto { get; set; }
        public int NumberOfDays { get; set; }
        public DateTime? Validity { get; set; }
    }
}