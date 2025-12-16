using System.ComponentModel.DataAnnotations;

namespace PointOfSale.Api.Models
{
    public class User
    {
        [Required]
        public int id { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string username { get; set; }   
    }
}
