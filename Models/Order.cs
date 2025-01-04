using System.ComponentModel.DataAnnotations;

namespace ASPproj.Models
{
    public class Order
    {
        [Key]
        public string Id { get; set; }
        public string Customer_Id { get; set; }
         public string Status { get; set; }
        public double total_price { get; set; }
    }
}
