using System.ComponentModel.DataAnnotations;

namespace ASPproj.Models
{
    public class Order
    {
        [Key]
        public string Id { get; set; }
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

        [ForeignKey("ID")]
        public Customer customer { get; set; }

    }
}
