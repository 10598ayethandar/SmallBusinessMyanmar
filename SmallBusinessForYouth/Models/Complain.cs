namespace SmallBusinessForYouth.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Complain")]
    public partial class Complain
    {
        public int ComplainId { get; set; }

        public int MId { get; set; }

        [Required]
        [StringLength(30)]
        public string C_Type { get; set; }

        [Required]
        [StringLength(1000)]
        public string C_Text { get; set; }

        public virtual Member Member { get; set; }
    }
}
