using System.ComponentModel.DataAnnotations;

namespace ASPproj.Models
{
    public class Cart
    {
        [Key]
        public string Id { set; get; }
        public string Customr_Id {  get; set; }

        [ForeignKey("ID")]
        public Customer customer { get; set; }
    }
}
