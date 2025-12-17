using Microsoft.AspNetCore.Mvc;
using PointOfSale.Api.Models;
using PointOfSale.Api.Services;

namespace PointOfSale.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class OrderController : ControllerBase
    {
        private readonly IS_Order _orderService;
        private readonly IS_OrderDetail _orderDetail;
        public OrderController(IS_Order orderService, IS_OrderDetail orderDetail)
        {
            _orderService = orderService;
            _orderDetail = orderDetail;
        }


        [HttpGet]
        public async Task<IActionResult> GetListOrder()
        {
            try{
                var result = await _orderService.GetOrderList();
                return new JsonResult(new { success = true, data = result });
            }catch(Exception ex){
                return StatusCode(500, new { success = false, message = "Có lỗi xảy ra: " + ex.Message });

            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrder(EM_OrderCreate order)
        {
            var itemProducts = new List<M_OrderDetail>();
            try
            {
                var orderResult = await _orderService.CreateOrder(order);
                foreach (var product in order.ProductObjs)
                {
                    itemProducts.Add(new M_OrderDetail
                    {
                        ProductId = product.ProductID,
                        Quantity = product.Quantity,
                        OrderId = orderResult.Id
                    });
                }

                var result = await _orderDetail.CreateListOrderDetail(itemProducts);
                return new JsonResult(new { success = true, data = result });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { success = false, message = "Có lỗi xảy ra: " + ex.Message });

            }
        }

    }
}
