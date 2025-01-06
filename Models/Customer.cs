using System.ComponentModel.DataAnnotations;

namespace ASPproj.Models
{
    public class Customer
    {
        [Key]
        public String ID { get; set; }

        [Required]
        [NotNull]
        [MaxLength(255)]
        [Column(name:"Name",TypeName ="nvarchar(255)")]
        public string Name { get; set; }

        [Required]
        [NotNull]
        [MaxLength(255)]
        [Column(name:"Email",TypeName ="nvarchar(255)")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [NotNull]
        [MaxLength(255)]
        [Column(name:"Password",TypeName ="nvarchar(255)")]
        public string Password { get; set; }

    }
}