using WebDemo.Core.src.Entity;
using WebDemo.Core.src.Shared;

namespace WebDemo.Business.src.Abtraction
{
    public interface IBaseService<T, TReadDto, TCreateDto, TUpdateDto> where T: BaseEntity
    {
        Task<IEnumerable<TReadDto>> GetAllAsync(GetAllOptions getAllOptions);
        Task<TReadDto> GetByIdAsync(Guid id);
        Task<bool> UpdateOneAsync(Guid id, TUpdateDto updateObject);
        Task<bool> DeleteOneAsync(Guid id);
        Task<TReadDto> CreateOneAsync(TCreateDto createObject);
    }
}