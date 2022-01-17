namespace SmallBusinessForYouth.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Order_Complete
    {
        [Key]
        public int CompleteId { get; set; }

        public int OId { get; set; }

        public int Pay_Id { get; set; }

        public int DId { get; set; }

        public virtual Deli_Man Deli_Man { get; set; }

        public virtual Payment Payment { get; set; }

        public virtual Order Order { get; set; }
    }
}
