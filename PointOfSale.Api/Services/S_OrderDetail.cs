using PointOfSale.Api.Data;
using PointOfSale.Api.Models;

namespace PointOfSale.Api.Services
{
    public interface IS_OrderDetail
    {
        Task<M_OrderDetail> CreateOrderDetail(M_OrderDetail orderDetail);
        Task<List<M_OrderDetail>> CreateListOrderDetail(List<M_OrderDetail> orderDetails);
    }

    public class S_OrderDetail : IS_OrderDetail
    {
        private readonly MyDbContext _context;
        public S_OrderDetail(MyDbContext context)
        {
            _context = context;
        }

        public async Task<List<M_OrderDetail>> CreateListOrderDetail(List<M_OrderDetail> orderDetails)
        {
            _context.OrderDetails.AddRange(orderDetails);
            await _context.SaveChangesAsync();
            return orderDetails;
        }

        public async Task<M_OrderDetail> CreateOrderDetail(M_OrderDetail orderDetail)
        {
            _context.OrderDetails.Add(orderDetail);
            await _context.SaveChangesAsync();
            return orderDetail;
        }
    }
}
