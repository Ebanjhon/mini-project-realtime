using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using PointOfSale.Api.Models;
using PointOfSale.Api.Services;

namespace PointOfSale.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class ProductController : ControllerBase
    {
        private readonly IS_Product _productService;
        private readonly S_Minio _minio;

        public ProductController(IS_Product productService, S_Minio minio)
        {
            _productService = productService;
            _minio = minio;
        }

        [HttpGet]
        public async Task<IActionResult> GetProductList(string? textSearch, int? categoryId)
        {
            var result = await _productService.GetProductList(textSearch, categoryId);
            return new JsonResult(new { success = true, data = result});
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct([FromForm] EM_ProductCreate product, [FromForm] List<IFormFile>? imageFiles)
        {
            try
            {
                var images = await _minio.UploadImages(imageFiles);
                var result = await _productService.CreateProduct(product, images);
                return new JsonResult(new { message = "Thêm sản phẩm thành công!", data = result });
            }
            catch (DbUpdateException ex) when (ex.InnerException is SqlException sqlEx && sqlEx.Number == 547)
            {
                return BadRequest(new { success = false, message = "Mã danh mục không tồn tại!" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { success = false, message = "Có lỗi xảy ra: " + ex.Message });
            }
        }
    }
}
