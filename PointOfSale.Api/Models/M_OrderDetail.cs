using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace PointOfSale.Api.Models
{
    public class M_OrderDetail
    {
        public int Quantity { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        [Required, JsonIgnore]
        public M_Order Order { get; set; }
        [Required]
        public M_Product Product { get; set; }
    }
}
