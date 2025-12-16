using PointOfSale.Api.Data;
using PointOfSale.Api.Models;

namespace PointOfSale.Api.Services
{
    public interface IS_User
    {
        Task<List<User>> GetListUser();
        Task<User> CreateUser(User user);
    }

    public class S_User : IS_User
    {
        private readonly MyDbContext _context;

        public S_User(MyDbContext context)
        {
            _context = context;
        }

        public async Task<User> CreateUser(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public Task<List<User>> GetListUser()
        {
            throw new NotImplementedException();
        }
    }
}
