using WebDemo.Core.src.Entity;

namespace WebDemo.Business.src.DTO
{
    public class OrderCreateDto
    {
        public Guid UserId { get; set; }
        public IEnumerable<OrderDetailCreateDto> OrderDetails { get; set; }
    }

    public class OrderReadDto : OwnerContainer
    {
        public IEnumerable<OrderDetailReadDto> OrderDetails { get; set; }
    }

    public class OrderUpdateDto
    {
        public IEnumerable<OrderDetailUpdateDto> OrderDetails { get; set; }
    }
}