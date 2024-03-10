using DevTesteInovage.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace DevTesteInovage.Infrastructure
{
    public class DevTesteInovageDbContext : DbContext
    {
        public DevTesteInovageDbContext(DbContextOptions<DevTesteInovageDbContext> options) : base(options)
        {

        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Purchase> Purchases{ get; set; }
        public DbSet<PurchaseItem> PurchaseItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            //Product
            modelBuilder.Entity<Product>(p =>
            {
                p.HasKey(p=> p.Id);
                p.Property(p => p.Title).HasMaxLength(50);
                p.Property(p => p.Description).HasMaxLength(254);
                p.Property(p => p.Price).HasColumnType("decimal(18, 2)");

                p.HasMany(p => p.PurchaseItems)
                 .WithOne(pi => pi.Product)
                 .HasForeignKey(pi => pi.IdProduct);
            });

            //Purchase
            modelBuilder.Entity<Purchase>(p =>
            {
                p.HasKey(p=> p.Id);
                p.Property(p => p.Description).HasMaxLength(50);
                p.Property(p => p.DeliveryAdress).HasMaxLength(254);
                p.Property(p => p.Status).HasConversion(typeof(string));

                p.HasMany(p => p.PurchaseItems)
                 .WithOne(pi => pi.Purchase)
                 .HasForeignKey(pi => pi.IdPurchase);
            });

            //PurchaseItems
            modelBuilder.Entity<PurchaseItem>(pi =>
            {
                pi.HasKey(pi => new { pi.IdProduct, pi.IdPurchase });

                pi.HasKey(pi => pi.Id);

                pi.Property(pi => pi.TotalPrice).HasColumnType("decimal(18, 2)");
            });
        }
    }
}
