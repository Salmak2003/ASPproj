using System.ComponentModel.DataAnnotations;

namespace ASPproj.Models
{
    public class Cart_item
    {
        [Key]
        public string Id { get; set; }
        public string Cart_Id { get; set; }
        public string Item_Id { get; set; }

        [Required]
        [NotNull]
        [Column(name:"Quantity",TypeName ="int")]
        public int Quantity {set; get; }

        [ForeignKey("Id")]
        public Item item { get; set; }

        [ForeignKey("Id")]
        public Cart cart { get; set; }


    }
}
