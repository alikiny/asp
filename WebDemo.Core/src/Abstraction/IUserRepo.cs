using WebDemo.Core.src.Entity;

namespace WebDemo.Core.src.Abstraction
{
    public interface IUserRepo : IBaseRepo<User>
    {
        // Task<bool> UpdatePasswordAsync(string newPassword, Guid userId);
        Task<User?> FindByEmailAsync(string email);
    }
}