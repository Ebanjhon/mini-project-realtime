using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace PointOfSale.Api.Models
{
    public class M_Image : BaseModel
    {
        public int Id { get; set; }

        public int ProductId { get; set; }

        [Required]
        [StringLength(255)]
        public string ImageUrl { get; set; }

        //[Required]
        //public bool IsPrimary { get; set; }

        public bool IsActive { get; set; } = true;

        [ForeignKey("ProductId")]
        [JsonIgnore]
        public M_Product Product { get; set; }
    }
}
