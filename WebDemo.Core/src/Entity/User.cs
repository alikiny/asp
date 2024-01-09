using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace WebDemo.Core.src.Entity
{
    public class User : BaseEntity
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        public string Password { get; set; }
        public Role Role { get; set; }
        public byte[] Salt { get; set; } //random key to hash password
        public IEnumerable<Address> Addresses { get; set; }
        public Avatar Avatar { get; set; }
    }

    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum Role
    {
        Admin,
        Customer
    }
}