using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using JetBrains.Annotations;

namespace ASPproj.Models
{
    public enum OrderStatus
    {
        Pending,
        Processing,
        Shipped,
        Delivered,
        Canceled,
    }

    public class Order
    {
        [Key]
        public required string Id { get; set; }

        public required string CustomerId { get; set; }

        [Required]
        [NotNull]
        [MaxLength(255)]
        [Column(name: "Status", TypeName = "nvarchar(255)")]
        public required OrderStatus Status { get; set; }

        [Required]
        [NotNull]
        [Column("Total_Price", TypeName = "decimal(18,2)")]
        public required double TotalPrice { get; set; }

        [ForeignKey("CustomerId")]
        public required Customer Customer { get; set; }
    }
}
