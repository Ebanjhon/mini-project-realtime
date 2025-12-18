namespace PointOfSale.Api.Models
{
    public abstract class BaseModel
    {
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime? UpdatedAt { get; set; }
    }
}
