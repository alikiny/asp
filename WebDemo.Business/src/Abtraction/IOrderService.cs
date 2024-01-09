using WebDemo.Business.src.DTO;
using WebDemo.Core.src.Entity;

namespace WebDemo.Business.src.Abtraction
{
    public interface IOrderService : IBaseService<Order, OrderReadDto, OrderCreateDto, OrderUpdateDto>
    {
        
    }
}