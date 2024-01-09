using WebDemo.Business.src.DTO;
using WebDemo.Core.src.Shared;

namespace WebDemo.Business.src.Abtraction
{
    public interface IOrderDetailService 
    {
        Task<IEnumerable<OrderDetailReadDto>> GetAllAsync();
        Task<OrderDetailReadDto?> GetOneAsync(OrderDetailKey orderDetailKey);
        Task<bool> UpdateOneAsync(OrderDetailUpdateDto updateObject);
        Task<bool> DeleteOneAsync(Guid id);
        Task<OrderDetailReadDto> CreateOneASync(OrderDetailCreateDto createObject);
    }
}