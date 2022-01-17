namespace SmallBusinessForYouth.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class DBModel : DbContext
    {
        public DBModel()
            : base("name=DBModel")
        {
        }

        public virtual DbSet<AdminTable> AdminTables { get; set; }
        public virtual DbSet<Company> Companies { get; set; }
        public virtual DbSet<Complain> Complains { get; set; }
        public virtual DbSet<Deli_Man> Deli_Man { get; set; }
        public virtual DbSet<InvestCompany> InvestCompanies { get; set; }
        public virtual DbSet<Member> Members { get; set; }
        public virtual DbSet<Order_Complete> Order_Complete { get; set; }
        public virtual DbSet<Order_Detail> Order_Detail { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Payment> Payments { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Seller> Sellers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {


            modelBuilder.Entity<Company>()
                .Property(e => e.C_Regi_No)
                .IsUnicode(false);

            modelBuilder.Entity<Company>()
                .HasMany(e => e.InvestCompanies)
                .WithRequired(e => e.Company)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Deli_Man>()
                .HasMany(e => e.Order_Complete)
                .WithRequired(e => e.Deli_Man)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Member>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<Order>()
                .Property(e => e.OrderImagePath)
                .IsUnicode(true);

            modelBuilder.Entity<Order>()
                .Property(e => e.Special_Note)
                .IsUnicode(true);

            modelBuilder.Entity<Member>()
                .HasMany(e => e.Complains)
                .WithRequired(e => e.Member)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Member>()
                .HasMany(e => e.Deli_Man)
                .WithRequired(e => e.Member)
                .WillCascadeOnDelete(false);


            modelBuilder.Entity<Member>()
                .HasMany(e => e.Sellers)
                .WithRequired(e => e.Member)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Order>()
                .HasMany(e => e.Order_Complete)
                .WithRequired(e => e.Order)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Order>()
                .HasMany(e => e.Order_Detail)
                .WithRequired(e => e.Order)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Payment>()
                .Property(e => e.Bank)
                .IsUnicode(false);

            modelBuilder.Entity<Payment>()
                .Property(e => e.Branch)
                .IsUnicode(false);



            modelBuilder.Entity<Payment>()
                .HasMany(e => e.Order_Complete)
                .WithRequired(e => e.Payment)
                .WillCascadeOnDelete(false);


        }
    }
}
