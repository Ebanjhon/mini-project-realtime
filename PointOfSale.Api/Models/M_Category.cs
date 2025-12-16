using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace PointOfSale.Api.Models
{
    public class M_Category : BaseModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 3)]
        public string Name { get; set; }

        public bool IsActive { get; set; } = true;

        [StringLength(500)]
        public string? Description { get; set; }

        // Set mỗi quan hệ bảng
        [JsonIgnore]
        public List<M_Product> Products { get; set; } = new List<M_Product>();
    }
}
