using Microsoft.EntityFrameworkCore;
using PointOfSale.Api.Data;
using PointOfSale.Api.Models;

namespace PointOfSale.Api.Services
{
    public interface IS_Category
    {
        Task<List<M_Category>> GetCategoryList();

        Task<List<M_Category>> CreateCategories(List<M_Category> categories);
    }

    public class S_Category : IS_Category
    {
        private readonly MyDbContext _context;
        public S_Category(MyDbContext context)
        {
            _context = context;
        }

        public async Task<List<M_Category>> CreateCategories(List<M_Category> categories)
        {
            _context.Categories.AddRange(categories);
            await _context.SaveChangesAsync();
            return categories;
        }

        public async Task<List<M_Category>> GetCategoryList()
        {
            return await _context.Categories.AsNoTracking().Where(x => x.IsActive).ToListAsync();
        }
    }
}
