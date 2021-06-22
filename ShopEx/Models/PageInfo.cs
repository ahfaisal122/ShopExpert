namespace ShopEx.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class PageInfo
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PageInfo()
        {
            Cats = new HashSet<Cat>();
        }

        [Key]
        public string PageId { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string PageName { get; set; }

        public string Password { get; set; }

        public string ConfirmPassword { get; set; }

        public string PageOwnerName { get; set; }

        public string OwnerAddress { get; set; }

        public string OwnersNumber { get; set; }

        public string OwnersEmail { get; set; }

        public string Description { get; set; }

        public string PageFbLink { get; set; }

        public string PageWebsite { get; set; }

        public byte[] Preference { get; set; }

        public string Delivery { get; set; }

        public byte[] Picture { get; set; }

        public int VisitorCount { get; set; }
        public float avgRating { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Cat> Cats { get; set; }
    }
}
