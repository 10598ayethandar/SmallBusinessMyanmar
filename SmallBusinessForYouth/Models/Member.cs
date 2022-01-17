namespace SmallBusinessForYouth.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Web;

    [Table("Member")]
    public partial class Member
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Member()
        {
            Complains = new HashSet<Complain>();
            Deli_Man = new HashSet<Deli_Man>();
            Products = new HashSet<Product>();
            Sellers = new HashSet<Seller>();
        }

        [Key]
        public int MId { get; set; }

        [Required(ErrorMessage = "အမည်ဖြည့်ရန်လိုအပ်သည်")]
        [StringLength(50)]
        public string UName { get; set; }

        [Required]
        [StringLength(10)]
        public string Gender { get; set; }

        [Required(ErrorMessage = "နိုင်ငံရေးစီစစ်ရေးကတ်နံပါတ်ဖြည့်ရန်လိုအပ်သည်")]
        [StringLength(30)]
      
        public string NRC_No { get; set; }

        [Required(ErrorMessage = "ဓာတ်ပုံဖြည့်ရန်လိုအပ်သည်")]
        [StringLength(100)]
        public string ImagePath { get; set; }
        [Required(ErrorMessage = "ဓာတ်ပုံဖြည့်ရန်လိုအပ်သည်")]
        [NotMapped]
        public HttpPostedFileBase ImageFile { get; set; }

        [Required(ErrorMessage = "ဖုန်းနံပါတ်ဖြည့်ရန်လိုအပ်သည်")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\d{9}$", ErrorMessage = "ဖုန်းနံပါတ်ပုံစံမှားယွင်းနေပါသည်")]
        public int Phone_no { get; set; }

        [Required(ErrorMessage = "အီးမေး(လ်)ဖြည့်ရန်လိုအပ်သည်")]
        [StringLength(50)]
        [RegularExpression(@"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$", ErrorMessage = "အီးမေး(လ်)ပုံစံမှားယွင်းနေပါသည်")]
        public string Email { get; set; }

        [Required(ErrorMessage = "လိပ်စာဖြည့်ရန်လိုအပ်သည်")]
        [StringLength(20)]
        public string House_no { get; set; }

        [Required(ErrorMessage = "လိပ်စာဖြည့်ရန်လိုအပ်သည်")]
        [StringLength(30)]
        public string Street { get; set; }

        [Required(ErrorMessage = "လိပ်စာဖြည့်ရန်လိုအပ်သည်")]
        [StringLength(30)]
        public string Quarter { get; set; }

        [Required(ErrorMessage = "လိပ်စာဖြည့်ရန်လိုအပ်သည်")]
        [StringLength(30)]
        public string Township { get; set; }

        [Required(ErrorMessage = "လိပ်စာဖြည့်ရန်လိုအပ်သည်")]
        [StringLength(30)]
        public string Division { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Complain> Complains { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Deli_Man> Deli_Man { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Product> Products { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Seller> Sellers { get; set; }
    }
}
