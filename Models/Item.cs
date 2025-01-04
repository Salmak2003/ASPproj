using System.ComponentModel.DataAnnotations;

namespace ASPproj.Models
{
    public class Item
    {
        [Key]
        public string Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public int stock_quantity { get; set; }

    }
}
