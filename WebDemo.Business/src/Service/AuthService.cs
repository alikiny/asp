using WebDemo.Business.src.Abtraction;
using WebDemo.Business.src.Shared;
using WebDemo.Core.src.Abstraction;
using WebDemo.Core.src.Shared;

namespace WebDemo.Business.src.Service
{
    public class AuthService : IAuthService
    {
        private IUserRepo _repo;
        private ITokenService _tokenService;

        public AuthService(IUserRepo userRepo, ITokenService tokenService)
        {
            _repo = userRepo;
            _tokenService = tokenService;
        }

        public async Task<string> Login(Credentials credentials)
        {
            var foundByEmail = await _repo.FindByEmailAsync(credentials.Email);
            if(foundByEmail is null)
            {
                throw CustomException.UnAuthorized();
            }
            var isPaswordMatch = PasswordService.VerifyPassword(credentials.Password, foundByEmail.Password, foundByEmail.Salt);
            if(isPaswordMatch)
            {
                return _tokenService.GenerateToken(foundByEmail);
            }
            throw CustomException.UnAuthorized();
        }
    }
}