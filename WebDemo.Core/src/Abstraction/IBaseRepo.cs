using WebDemo.Core.src.Entity;
using WebDemo.Core.src.Shared;

namespace WebDemo.Core.src.Abstraction
{
    public interface IBaseRepo<T> where T : BaseEntity
    {
        Task<IEnumerable<T>> GetAllAsync(GetAllOptions getAllOptions);
        Task<T?> GetByIdAsync(Guid id);
        Task<bool> UpdateOneAsync(T updateObject);
        Task<bool> DeleteOneAsync(T deleteObject);
        Task<T> CreateOneASync(T createObject);
    }
}