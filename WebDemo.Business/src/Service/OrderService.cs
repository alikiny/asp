using AutoMapper;
using WebDemo.Business.src.Abtraction;
using WebDemo.Business.src.DTO;
using WebDemo.Core.src.Abstraction;
using WebDemo.Core.src.Entity;

namespace WebDemo.Business.src.Service
{
    public class OrderService : BaseService<Order, OrderReadDto, OrderCreateDto, OrderUpdateDto>, IOrderService
    {
        public OrderService(IOrderRepo repo, IMapper mapper) : base(repo, mapper)
        {
        }
    }
}