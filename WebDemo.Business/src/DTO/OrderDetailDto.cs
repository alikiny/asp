namespace WebDemo.Business.src.DTO
{
    public class OrderDetailCreateDto
    {
        public int Quantity { get; set; }
        public Guid ProductId { get; set; }
        public Guid OrderId { get; set; }
    }

    public class OrderDetailReadDto
    {
        public int Quantity { get; set; }
        public ProductReadDto Product { get; set; }
    }

    public class OrderDetailUpdateDto
    {
        public int Quantity { get; set; }
    }
}