using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ASPproj.Models
{
    public class Cart
    {
        [Key]
        public required string Id { get; set; }

        [Required(ErrorMessage = "Customer ID is required.")]
        public required string CustomerId { get; set; }

        [ForeignKey("CustomerId")]
        public required Customer Customer { get; set; }

        public required ICollection<Cart_item> CartItems { get; set; } = new List<Cart_item>();
    }
}
