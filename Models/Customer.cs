using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using JetBrains.Annotations;

namespace ASPproj.Models
{
    public class Customer
    {
        [Key]
        public required string ID { get; set; }

        [Required]
        [NotNull]
        [MaxLength(50)]
        [Column(name: "Username", TypeName = "nvarchar(50)")]
        public required string Username { get; set; }

        [Required]
        [NotNull]
        [MaxLength(255)]
        [Column(name: "Name", TypeName = "nvarchar(255)")]
        public required string Name { get; set; }

        [Required]
        [NotNull]
        [MaxLength(255)]
        [Column(name: "Email", TypeName = "nvarchar(255)")]
        [DataType(DataType.EmailAddress)]
        public required string Email { get; set; }

        [Required]
        [NotNull]
        [MaxLength(255)]
        [Column(name: "Password", TypeName = "nvarchar(255)")]
        public required string PasswordHash { get; set; }
    }
}
