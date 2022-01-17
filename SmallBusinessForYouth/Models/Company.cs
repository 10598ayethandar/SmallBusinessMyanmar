namespace SmallBusinessForYouth.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Company")]
    public partial class Company
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Company()
        {
            InvestCompanies = new HashSet<InvestCompany>();
        }

        [Key]
        public int CId { get; set; }

        [Required]
        [StringLength(50)]
        public string CName { get; set; }

        [Required]
        [StringLength(30)]
        public string C_Regi_No { get; set; }

        [Column(TypeName = "date")]
        public DateTime C_Regi_Date { get; set; }

        public int C_Phno { get; set; }

        [StringLength(1000)]
        public string Special_Note { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<InvestCompany> InvestCompanies { get; set; }
    }
}
