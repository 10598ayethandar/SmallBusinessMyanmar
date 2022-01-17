namespace SmallBusinessForYouth.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Order_Detail
    {
        [Key]
        public int DetailId { get; set; }

        public int OId { get; set; }

        public int PId { get; set; }


        public int Qty { get; set; }

        public int Amount { get; set; }

        [StringLength(1000)]
        public string Special_Note { get; set; }

        public virtual Order Order { get; set; }

        public virtual Product Product { get; set; }
    }
}
