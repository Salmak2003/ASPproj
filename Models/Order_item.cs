using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace ASPproj.Models
{
    public class Order_item
    {
        [Key]
        public string Id { get; set; }
        public string Order_Id { get; set; }

        public string Item_Id { get; set; }
        public int Quantity { get; set; }

    }
}
