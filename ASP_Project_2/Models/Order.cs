using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace ASPproj.Models
{
    public class Order
    {
        [Key]
        public string Order_Id { get; set; }
        public string Customer_Id { get; set; }

        [Required]
        [NotNull]
        [MaxLength(255)]
        [Column(name:"Status",TypeName ="nvarchar(255)")]
        public string Status { get; set; }

        [Required]
        [NotNull]
        [Column("Total_Price", TypeName = "decimal(18,2)")]
        public double total_price { get; set; }

        [ForeignKey("Customr_Id")]
        public Customer customer { get; set; }

        public ICollection<Order_item> Order_items { get; set; }

    }
}
