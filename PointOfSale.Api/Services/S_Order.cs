using Microsoft.EntityFrameworkCore;
using PointOfSale.Api.Data;
using PointOfSale.Api.Models;

namespace PointOfSale.Api.Services
{
    public interface IS_Order
    {
        Task<M_Order> CreateOrder(EM_OrderCreate order);
        Task<M_Order> UpdateOrder(M_Order order);
        Task<M_Order> DeleteOrder(int orderId);
        Task<List<M_Order>> GetOrderList();
    }

    public class S_Order : IS_Order
    {
        private readonly MyDbContext _context;
        public S_Order(MyDbContext context)
        {
            _context = context;
        }
        public async Task<M_Order> CreateOrder(EM_OrderCreate order)
        {
            var newOrder = new M_Order
            {
                Status = order.Status
            };
            _context.Orders.Add(newOrder);
            await _context.SaveChangesAsync();
            return newOrder;
        }

        public Task<M_Order> DeleteOrder(int orderId)
        {
            throw new NotImplementedException();
        }

        public async Task<List<M_Order>> GetOrderList()
        {
            var orders = await _context.Orders
            .Include(o => o.OrderProducts)
            .ThenInclude(op => op.Product)
            .ToListAsync();
            return orders;
        }

        public Task<M_Order> UpdateOrder(M_Order order)
        {
            throw new NotImplementedException();
        }
    }
}
