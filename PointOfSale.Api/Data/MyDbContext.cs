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
        }

    }
}
