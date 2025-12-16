using Microsoft.AspNetCore.Mvc;
using PointOfSale.Api.Services;

namespace PointOfSale.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class CategoryController : ControllerBase
    {
        private readonly IS_Category _categoryService;

        public CategoryController(IS_Category categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<IActionResult> GetCategories()
        {
            var result = await _categoryService.GetCategoryList();
            return new JsonResult(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategories(List<Models.M_Category> categories)
        {
            var result = await _categoryService.CreateCategories(categories);
            return new JsonResult(result);
        }
    }
}
