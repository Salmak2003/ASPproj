using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using JetBrains.Annotations;

namespace ASPproj.Models
{
    public class Item
    {
        [Key]
        public required string Id { get; set; }

        [Required]
        [NotNull]
        [MaxLength(255)]
        [Column(name: "Name", TypeName = "nvarchar(255)")]
        public required string Name { get; set; }

        [Required]
        [NotNull]
        [Column(name: "Price", TypeName = "int")]
        public int Price { get; set; }

        [Required]
        [NotNull]
        [Column(name: "stock_quantity", TypeName = "int")]
        public required int StockQuantity { get; set; }
    }
}
