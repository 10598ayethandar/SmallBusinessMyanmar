namespace SmallBusinessForYouth.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("AdminTable")]
    public partial class AdminTable
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public AdminTable()
        {
            Products = new HashSet<Product>();
        }

        [Key]
        public int AId { get; set; }

        [Required(ErrorMessage = "အမည်ဖြည့်ရန်လိုအပ်သည်")]
        [StringLength(20)]
        public string Name { get; set; }

        [Required(ErrorMessage = "လျှို့ဝှတ်ကုတ်ဖြည့်ရန်လိုအပ်သည်")]
        [StringLength(10)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Product> Products { get; set; }
    }
}
