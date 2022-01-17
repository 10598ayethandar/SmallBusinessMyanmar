namespace SmallBusinessForYouth.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Deli_Man
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Deli_Man()
        {
            Order_Complete = new HashSet<Order_Complete>();
        }

        [Key]
        public int DId { get; set; }

        public int MId { get; set; }

      
        [Required(ErrorMessage = "ဖြည့်ရန်လိုအပ်သည်")]
        [StringLength(8)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Column(TypeName = "date")]
        public DateTime Entry_Date { get; set; }

        public int? Rating { get; set; }

       
        public virtual Member Member { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Order_Complete> Order_Complete { get; set; }
    }
}
