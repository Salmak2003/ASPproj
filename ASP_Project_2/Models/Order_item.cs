using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace ASPproj.Models
{
    public class Order_item
    {
        [Key]
        public string Order_Item_Id { get; set; }
        public string Order_Id { get; set; }

        public string Item_Id { get; set; }

        [Required]
        [NotNull]
        [Column(name:"Quantity",TypeName ="int")]
        public int Quantity { get; set; }

        [ForeignKey("Item_Id")]
        public Item item { get; set; }

        [ForeignKey("Order_Id")]
        public Order order { get; set; }

    }
}
