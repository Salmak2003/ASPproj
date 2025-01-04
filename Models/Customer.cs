using System.ComponentModel.DataAnnotations;

namespace ASPproj.Models
{
    public class Customer
    {
        [Key]
        public String ID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

    }
}
