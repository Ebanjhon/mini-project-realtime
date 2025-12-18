using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using PointOfSale.Api.Models;
using PointOfSale.Api.Services;
using PointOfSale.Api.SignalR;

namespace PointOfSale.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class OrderController : ControllerBase
    {
        private readonly IS_Order _orderService;
        private readonly IS_OrderDetail _orderDetail;
        private readonly IHubContext<OrderHub> _hubContext;

        public OrderController(IS_Order orderService, IS_OrderDetail orderDetail, IHubContext<OrderHub> hubContext)
        {
            _orderService = orderService;
            _orderDetail = orderDetail;
            _hubContext = hubContext;
        }


        [HttpGet]
        public async Task<IActionResult> GetListOrder()
        {
            try
            {
                var result = await _orderService.GetOrderList();
                return new JsonResult(new { success = true, data = result });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { success = false, message = "Có lỗi xảy ra: " + ex.Message });

            }
        }

        [HttpGet]
        public async Task <IActionResult> GetOrderById(int Id)
        {
            try
            {
                var result = await _orderService.GetOrderById(Id);
                return new JsonResult(new { success = true, data = result });
            }
            catch (Exception e) {
                return new JsonResult(new { success = false, message = "Có lỗi xẩy ra!" });
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrder(EM_OrderCreate order)
        {
            var message = new M_MessageOrder();
            var itemProducts = new List<M_OrderDetail>();
            M_Order orderResult = new M_Order();
            try
            {
                orderResult = await _orderService.CreateOrder(order);
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
                message.OrderId = orderResult.Id;
                message.Messsage = "Thanh toán thành công!";
                await _hubContext.Clients.All.SendAsync("ReceiveMessage", message);
                return new JsonResult(new { success = true, data = result });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { success = false, message = "Có lỗi xảy ra: " + ex.Message });

            }
        }

        //// POST: api/Order/SendMessage
        //[HttpPost]
        //public async Task<IActionResult> SendMessage(string message)
        //{
        //    try
        //    {
        //        await _hubContext.Clients.All.SendAsync("ReceiveMessage", message);
        //        return Ok(new { status = "Sent Message Success!" });
        //    }catch(Exception ex)
        //    {
        //        return Ok(new { status = "Sent Message Error!" });
        //    }

        //}

    }
}
