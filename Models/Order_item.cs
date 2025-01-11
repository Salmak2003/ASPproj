using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;

namespace ASPproj.Models
{
    public class Order_item
    {
        [Key]
        public required string Id { get; set; }
        public required string Order_Id { get; set; }
        public required string Item_Id { get; set; }

        [Required]
        [NotNull]
        [Column(name: "Quantity", TypeName = "int")]
        public int Quantity { get; set; }

        [ForeignKey("Item_Id")]
        public required Item item { get; set; }

        [ForeignKey("Order_Id")]
        public required Order order { get; set; }
    }
}
