using Microsoft.EntityFrameworkCore;
using WebDemo.API.src.Database;
using WebDemo.Core.src.Abstraction;
using WebDemo.Core.src.Entity;
using WebDemo.Core.src.Shared;

namespace WebDemo.API.src.Repository
{
    public class OrderDetailRepo : IOrderDetailRepo
    {
        protected readonly DbSet<OrderDetail> _data;
        protected readonly DatabaseContext _databaseContext;

        public OrderDetailRepo(DatabaseContext context)
        {
            _databaseContext = context;
            _data = _databaseContext.OrderDetails;
        }

        public Task<OrderDetail> CreateOneASync(OrderDetail createObject)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteOneAsync(OrderDetail deleteObject)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<OrderDetail>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<OrderDetail?> GetOneAsync(OrderDetailKey orderDetailKey)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateOneAsync(OrderDetail updateObject)
        {
            throw new NotImplementedException();
        }
    }
}