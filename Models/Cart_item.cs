using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using JetBrains.Annotations;

namespace ASPproj.Models
{
    public class Cart_item
    {
        [Key]
        public required string Id { get; set; }
        public required string Cart_Id { get; set; }
        public required string Item_Id { get; set; }

        [Required]
        public required int Quantity { get; set; }

        [ForeignKey("Item_Id")]
        public required Item item { get; set; }

        [ForeignKey("Cart_Id")]
        public required Cart cart { get; set; }

        [Required(ErrorMessage = "Customer ID is required.")]
        public required string CustomerId { get; set; }
    }
}
