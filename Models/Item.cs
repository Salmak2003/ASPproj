using System.ComponentModel.DataAnnotations;

namespace ASPproj.Models
{
    public class Item
    {
        [Key]
        public string Id { get; set; }

        [Required]
        [NotNull]
        [MaxLength(255)]
        [Column(name:"Name",TypeName ="nvarchar(255)")]
        public string Name { get; set; }

        [Required]
        [NotNull]
        [Column(name:"Price",TypeName ="int")]
        public int Price { get; set; }

        [Required]
        [NotNull]
        [Column(name:"stock_quantity",TypeName ="int")]
        public int stock_quantity { get; set; }

    }
}
