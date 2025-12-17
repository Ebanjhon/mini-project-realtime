using Microsoft.EntityFrameworkCore;
using PointOfSale.Api.Models;

namespace PointOfSale.Api.Data
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {
        }
        public DbSet<User> Users { get; set; }
        public DbSet<M_Category> Categories { get; set; }
        public DbSet<M_Product> Products { get; set; }
        public DbSet<M_Image> Images { get; set; }
        public DbSet<M_Order> Orders { get; set; }
        public DbSet<M_OrderDetail> OrderDetails { get; set; }


        // Cấu hình quan hệ giữa các bảng
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<M_Product>()
                .HasOne(p => p.Category)
                .WithMany(c => c.Products)
                .HasForeignKey(p => p.CategoryID)
                .OnDelete(DeleteBehavior.Cascade); // or Restrict

            modelBuilder.Entity<M_Image>()
                .HasOne(i => i.Product)
                .WithMany(p => p.ImageObjs)
                .HasForeignKey(i => i.ProductId)
                .OnDelete(DeleteBehavior.Cascade);


            modelBuilder.Entity<M_Product>()
               .Property(p => p.Price)
               .HasPrecision(18, 2);

            // M_Order ↔ M_OrderDetail
            modelBuilder.Entity<M_OrderDetail>()
                .HasKey(od => new { od.OrderId, od.ProductId });

            modelBuilder.Entity<M_OrderDetail>()
                .HasOne(od => od.Order)
                .WithMany(o => o.OrderProducts)
                .HasForeignKey(od => od.OrderId);

            modelBuilder.Entity<M_OrderDetail>()
                .HasOne(od => od.Product)
                .WithMany(p => p.OrderProducts)
                .HasForeignKey(od => od.ProductId);
        }

    }
}
