using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace PointOfSale.Api.Models
{
    public class M_Product : BaseModel
    {
        public int Id { get; set; }

        [Required]
        public int CategoryID { get; set; }

        [Required]
        [StringLength(150, MinimumLength = 3)]
        public string ProductName { get; set; }

        [Required]
        public decimal Price { get; set; }

        public List<M_Image>? ImageObjs { get; set; } = new List<M_Image>();

        public bool IsActive { get; set; } = true;

        [StringLength(500)]
        public string? Description { get; set; }

        // Set mỗi quan hệ bảng
        [ForeignKey("CategoryID")]
        [JsonIgnore]
        public M_Category Category { get; set; }
    }

    public class EM_ProductCreate
    {
        //public int Id { get; set; }

        [Required]
        public int CategoryID { get; set; }

        [Required]
        [StringLength(150, MinimumLength = 3)]
        public string ProductName { get; set; }

        [Required]
        public decimal Price { get; set; }

        public bool IsActive { get; set; } = true;

        [StringLength(500)]
        public string? Description { get; set; }
     
    }

}
