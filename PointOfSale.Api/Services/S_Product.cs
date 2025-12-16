using Microsoft.EntityFrameworkCore;
using PointOfSale.Api.Data;
using PointOfSale.Api.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using static Microsoft.Extensions.Logging.EventSource.LoggingEventSource;

namespace PointOfSale.Api.Services
{
    public interface IS_Product
    {
        Task<M_Product> CreateProduct(EM_ProductCreate product, List<M_Image> images);
        Task<List<M_Product>> GetProductList(string? keyword, int? categoryId);
    }

    public class S_Product : IS_Product
    {
        private readonly MyDbContext _context;
        public S_Product(MyDbContext context)
        {
            _context = context;
        }

        public async Task<M_Product> CreateProduct(EM_ProductCreate product, List<M_Image> images)
        {
            var data = new M_Product {
                CategoryID = product.CategoryID,
                ProductName = product.ProductName,
                Price = product.Price,
                IsActive = product.IsActive,
                Description = product.Description,
                ImageObjs = images
            };
            _context.Products.Add(data);
            await _context.SaveChangesAsync();
            return data;
        }

        public async Task<List<M_Product>> GetProductList(string? keyword, int? categoryId)
        {
            IQueryable<M_Product> query = _context.Products
                .AsNoTracking()
                .Include(p => p.ImageObjs)
                .Where(x => x.IsActive);

            if (categoryId.HasValue)
                query = query.Where(x => x.CategoryID == categoryId.Value);

            if (!string.IsNullOrWhiteSpace(keyword))
            {
                var lowerKeyword = keyword.Trim().ToLower();
                query = query.Where(x => EF.Functions.Like(x.ProductName.ToLower(), $"%{lowerKeyword}%"));
            }

            return await query.ToListAsync();
        }
    }
}
