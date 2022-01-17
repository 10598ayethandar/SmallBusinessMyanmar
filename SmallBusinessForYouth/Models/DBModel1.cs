namespace SmallBusinessForYouth.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class DBModel1 : DbContext
    {
        public DBModel1()
            : base("name=DBModel1")
        {
        }

        public virtual DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
               .Property(e => e.PId);

            modelBuilder.Entity<Product>()
                .Property(e => e.Name)
                .IsUnicode(true);

            modelBuilder.Entity<Product>()
                .Property(e => e.Owner);


            modelBuilder.Entity<Product>()
                .Property(e => e.Price);


            modelBuilder.Entity<Product>()
                .Property(e => e.Image_Path)
                .IsUnicode(true);

            modelBuilder.Entity<Product>()
                .Property(e => e.Catagories)
                .IsUnicode(true);
            modelBuilder.Entity<Product>()
                .Property(e => e.AQty)
                .IsUnicode(true);

            modelBuilder.Entity<Product>()
                .Property(e => e.Description)
                .IsUnicode(true);
        }
    }
}
