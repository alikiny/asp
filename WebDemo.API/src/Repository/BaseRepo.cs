using Microsoft.EntityFrameworkCore;
using WebDemo.API.src.Database;
using WebDemo.Core.src.Abstraction;
using WebDemo.Core.src.Entity;
using WebDemo.Core.src.Shared;

namespace WebDemo.API.src.Repository
{
    public class BaseRepo<T> : IBaseRepo<T> where T : BaseEntity
    {
        protected readonly DbSet<T> _data;
        protected readonly DatabaseContext _databaseContext;

        public BaseRepo(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
            _data = _databaseContext.Set<T>();
        }
        public virtual async Task<T> CreateOneASync(T createObject)
        {
            await _data.AddAsync(createObject);
            await _databaseContext.SaveChangesAsync();
            return createObject;
        }

        public virtual async Task<bool> DeleteOneAsync(T deleteObject)
        {
            _data.Remove(deleteObject);
            await _databaseContext.SaveChangesAsync();
            return true;
        }

        public virtual async Task<IEnumerable<T>> GetAllAsync(GetAllOptions getAllOptions)
        {
            return await _data.AsNoTracking().Skip(getAllOptions.Offset).Take(getAllOptions.Limit).ToArrayAsync();
        }

        public virtual async Task<T?> GetByIdAsync(Guid id)
        {
            return await _data.FindAsync(id);
        }

        public virtual async Task<bool> UpdateOneAsync(T updateObject)
        {
            if (await _data.FindAsync(updateObject) is null)
            {
                return false;
            }
            _data.Update(updateObject);
            await _databaseContext.SaveChangesAsync();
            return true;
        }
    }
}