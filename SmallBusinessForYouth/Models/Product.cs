namespace SmallBusinessForYouth.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Web;

    [Table("Product")]
    public partial class Product
    {
        [Key]
        public int PId { get; set; }

        public int Owner { get; set; }

        [Required]
        [StringLength(30)]
        public string Name { get; set; }

        public int Price { get; set; }

        [Required]
        [StringLength(100)]
        public string Image_Path { get; set; }
        [NotMapped]
        public HttpPostedFileBase ProductFile { get; set; }

        [Required]
        [StringLength(50)]
        public string Catagories { get; set; }

        [Required]
        [StringLength(100)]
        public string AQty { get; set; }

        [StringLength(1000)]
        public string Description { get; set; }
    }
}
