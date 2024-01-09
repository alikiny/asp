using WebDemo.Core.src.Entity;

namespace WebDemo.Core.src.Abstraction
{
    public interface IAvatarRepo
    {
        Task<string> CreateAvartarAsync(Avatar avatar);
    }
}