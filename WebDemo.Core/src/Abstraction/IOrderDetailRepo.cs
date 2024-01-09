using WebDemo.Core.src.Entity;
using WebDemo.Core.src.Shared;

namespace WebDemo.Core.src.Abstraction
{
    public interface IOrderDetailRepo
    {
        Task<IEnumerable<OrderDetail>> GetAllAsync();
        Task<OrderDetail?> GetOneAsync(OrderDetailKey orderDetailKey);
        Task<bool> UpdateOneAsync(OrderDetail updateObject);
        Task<bool> DeleteOneAsync(OrderDetail deleteObject);
        Task<OrderDetail> CreateOneASync(OrderDetail createObject);
    }
}