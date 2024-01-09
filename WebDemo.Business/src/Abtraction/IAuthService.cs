
using WebDemo.Core.src.Shared;

namespace WebDemo.Business.src.Abtraction
{
    public interface IAuthService
    {
        Task<string> Login(Credentials credentials);
    }
}