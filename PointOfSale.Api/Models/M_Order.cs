using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace PointOfSale.Api.Models
{
    public class M_Order : BaseModel
    {
        public int Id { get; set; }
        public int Status { get; set; } = 1;
        public List<M_OrderDetail> OrderProducts { get; set; } = new();
    }

    public class ItemProduct
    {
        public int ProductID { get; set; }
        public int Quantity { get; set; }
    }

    public class EM_OrderCreate : BaseModel
    {
        //public int Id { get; set; }
        public int Status { get; set; } = 1;

        [Required]
        public List<ItemProduct> ProductObjs { get; set; }
    }
    
}
