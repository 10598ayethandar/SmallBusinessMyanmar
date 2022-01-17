namespace SmallBusinessForYouth.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Web;

    public partial class Order
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Order()
        {
            Order_Complete = new HashSet<Order_Complete>();
            Order_Detail = new HashSet<Order_Detail>();
        }

        [Key]
        public int OId { get; set; }
      
        [StringLength(100)]
        public string OrderImagePath { get; set; }
       
        [NotMapped]
        public HttpPostedFileBase OrderImageFile { get; set; }

        [Column(TypeName = "date")]
        public DateTime Entry_Date { get; set; }

        [Required]
        public String Special_Note { get; set; }

        public int Order_No { get; set; }
        

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Order_Complete> Order_Complete { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Order_Detail> Order_Detail { get; set; }
    }
}
