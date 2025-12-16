using Microsoft.AspNetCore.Mvc;
using PointOfSale.Api.Models;
using PointOfSale.Api.Services;

namespace PointOfSale.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IS_User _userService;

        public UserController(IS_User userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public async Task<IActionResult> Create(User user)
        {
            var result = await _userService.CreateUser(user);
            return new JsonResult(result);
        }
    }
}
