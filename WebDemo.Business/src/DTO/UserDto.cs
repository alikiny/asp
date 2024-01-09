using WebDemo.Core.src.Entity;

namespace WebDemo.Business.src.DTO
{
    public class UserReadDto : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public Role Role { get; set; }
        public Avatar Avatar { get; set; }
        public IEnumerable<AddressReadDto> Addresses { get; set; }
    }

    public class GetAllUserDto
    {
      public IEnumerable<UserReadDto> UserReadDtos { get; set; }
      public int Pages { get; set; }
    }

    public class UserCreateDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public IEnumerable<AddressCreateDto> Addresses { get; set; }
    }

    public class UserUpdateDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public Avatar Avatar { get; set; }
    }
}