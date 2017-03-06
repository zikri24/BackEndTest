namespace BackEnd.Entity_Framework
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class MerchantsDbContext : DbContext
    {
        public MerchantsDbContext()
            : base("name=MerchantsDbContext")
        {
        }

        public virtual DbSet<Merchant> Merchants { get; set; }
        public virtual DbSet<Address> Addresses { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Merchant>()
                .Property(e => e.DisplayName)
                .IsUnicode(false);

            modelBuilder.Entity<Merchant>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<Merchant>()
                .Property(e => e.Phone)
                .IsUnicode(false);

            modelBuilder.Entity<Merchant>()
                .Property(e => e.Status)
                .IsUnicode(false);

            modelBuilder.Entity<Merchant>()
                .Property(e => e.Logo)
                .IsUnicode(false);

            modelBuilder.Entity<Merchant>()
                .HasOptional(e => e.Address)
                .WithRequired(e => e.Merchant)
                .WillCascadeOnDelete();

            modelBuilder.Entity<Address>()
                .Property(e => e.addrss1)
                .IsUnicode(false);

            modelBuilder.Entity<Address>()
                .Property(e => e.addrss2)
                .IsUnicode(false);

            modelBuilder.Entity<Address>()
                .Property(e => e.Suburb)
                .IsUnicode(false);

            modelBuilder.Entity<Address>()
                .Property(e => e.State)
                .IsUnicode(false);

            modelBuilder.Entity<Address>()
                .Property(e => e.Postcode)
                .IsUnicode(false);

            modelBuilder.Entity<Address>()
                .Property(e => e.Country)
                .IsUnicode(false);
        }
    }
}
