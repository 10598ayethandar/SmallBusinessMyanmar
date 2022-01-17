namespace SmallBusinessForYouth.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Seller")]
    public partial class Seller
    {
        [Key]
        public int SId { get; set; }

        public int MId { get; set; }

        [Required(ErrorMessage = "ဖြည့်ရန်လိုအပ်သည်")]
        [DataType(DataType.Password)]
        [StringLength(8)]
        public string Password { get; set; }

        [Column(TypeName = "date")]
        public DateTime Entry_Date { get; set; }

        public int? Rating { get; set; }

        
        public virtual Member Member { get; set; }
    }
}
