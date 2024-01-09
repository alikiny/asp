using Microsoft.EntityFrameworkCore;
using WebDemo.API.src.Database;
using WebDemo.Core.src.Abstraction;
using WebDemo.Core.src.Entity;

namespace WebDemo.API.src.Repository
{
    public class UserRepo : BaseRepo<User>, IUserRepo
    {
        public UserRepo(DatabaseContext databaseContext) : base(databaseContext)
        {
        }

        public async Task<User?> FindByEmailAsync(string email)
        {
            return await _data.AsNoTracking().FirstOrDefaultAsync(u => u.Email == email);
        }

        public override async Task<User?> GetByIdAsync(Guid id)
        {
            return await _data.Include(user => user.Addresses).FirstOrDefaultAsync(user => user.Id == id);
        }
    }
}