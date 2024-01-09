namespace WebDemo.Core.src.Entity
{
    public class Order : OwnerContainer
    {
        public IEnumerable<OrderDetail> OrderDetails { get; set; }
    }
}