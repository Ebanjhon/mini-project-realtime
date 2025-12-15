using Microsoft.AspNetCore.Mvc;

namespace PointOfSale.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return Ok("Hello Jhon");
        }
    }
}
