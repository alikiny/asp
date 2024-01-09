using AutoMapper;
using WebDemo.Business.src.Abtraction;
using WebDemo.Business.src.DTO;
using WebDemo.Business.src.Shared;
using WebDemo.Core.src.Abstraction;
using WebDemo.Core.src.Entity;

namespace WebDemo.Business.src.Service
{
    public class UserService : BaseService<User, UserReadDto, UserCreateDto, UserUpdateDto>, IUserService
    {
        public UserService(IUserRepo repo, IMapper mapper) : base(repo, mapper)
        {
            _repo = repo;
        }

        public async Task<bool> UpdatePasswordAsync(string newPassword, Guid userId)
        {
            var user = await _repo.GetByIdAsync(userId);
            if (user is null)
            {
                throw CustomException.NotFound("User not found");
            }
            PasswordService.HashPasword(newPassword, out string hashedPassword, out byte[] salt);
            user.Password = hashedPassword;
            user.Salt = salt;
            return await _repo.UpdateOneAsync(user);
        }

        public override async Task<UserReadDto> CreateOneAsync(UserCreateDto createObject)
        {
            PasswordService.HashPasword(createObject.Password, out string hashedPassword, out byte[] salt);
            var user = _mapper.Map<UserCreateDto, User>(createObject);
            user.Password = hashedPassword;
            user.Salt = salt;
            user.Role = Role.Customer;
            return _mapper.Map<User, UserReadDto>(await _repo.CreateOneASync(user));
        }

        public override async Task<UserReadDto> GetByIdAsync(Guid id)
        {
            var result = await base.GetByIdAsync(id);
            var user = await _repo.GetByIdAsync(id);
            return await base.GetByIdAsync(id);
        }
    }
}