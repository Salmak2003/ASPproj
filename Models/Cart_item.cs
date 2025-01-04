using System.ComponentModel.DataAnnotations;

namespace ASPproj.Models
{
    public class Cart_item
    {
        [Key]
        public string Id { get; set; }
        public string Cart_Id { get; set; }
        public string Item_Id { get; set; }
        public int Quantity {set; get; }
    }
}
