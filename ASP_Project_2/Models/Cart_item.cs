using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace ASPproj.Models
{
    public class Cart_item
    {
        [Key]
        public string Car_Item_Id { get; set; }
        public string Cart_Id { get; set; }
        public string Item_Id { get; set; }

        [Required]
        [NotNull]
        [Column(name:"Quantity",TypeName ="int")]
        public int Quantity {set; get; }

        [ForeignKey("Item_Id")]
        public Item item { get; set; }

        [ForeignKey("Cart_Id")]
        public Cart cart { get; set; }


    }
}
