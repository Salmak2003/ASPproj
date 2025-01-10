using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ASPproj.Models
{
    public class Cart
    {
        [Key]
        public string Cart_Id { set; get; }
        public string Customr_Id {  get; set; }

        [ForeignKey("Customr_Id")]
        public Customer customer { get; set; }

        public ICollection<Cart_item> Cart_items { get; set; }
    }
}
