namespace SmallBusinessForYouth.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("InvestCompany")]
    public partial class InvestCompany
    {
        [Key]
        public int InvestId { get; set; }

        public int CId { get; set; }

        public int PId { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Entry_date { get; set; }

        public virtual Company Company { get; set; }

        public virtual Product Product { get; set; }
    }
}
