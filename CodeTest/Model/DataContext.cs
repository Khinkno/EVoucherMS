
using Microsoft.EntityFrameworkCore;

namespace CodeTest.Model
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Evouchers> Evoucher { get; set; }

        public DbSet<Payments> Payment { get; set; }
        public DbSet<Items> Items { get; set; }

        public DbSet<Purchases> Purchase { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("public");
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Evouchers>()
            .Property(a => a.Id).IsConcurrencyToken();
            modelBuilder.Entity<Evouchers>().ToTable("Evoucher");
            modelBuilder.Entity<Payments>()
           .Property(a => a.PaymentId).IsConcurrencyToken();
            modelBuilder.Entity<Payments>().ToTable("Payment");

        }

    }
}
