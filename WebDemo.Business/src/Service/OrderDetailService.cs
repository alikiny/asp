using WebDemo.Business.src.Abtraction;
using WebDemo.Business.src.DTO;
using WebDemo.Core.src.Shared;

namespace WebDemo.Business.src.Service
{
    public class OrderDetailService : IOrderDetailService
    {
        public Task<OrderDetailReadDto> CreateOneASync(OrderDetailCreateDto createObject)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteOneAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<OrderDetailReadDto>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<OrderDetailReadDto?> GetOneAsync(OrderDetailKey orderDetailKey)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateOneAsync(OrderDetailUpdateDto updateObject)
        {
            throw new NotImplementedException();
        }
    }
}