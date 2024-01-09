namespace WebDemo.Business.src.DTO
{
    public class ProductSizeReadDto
    {
        public Guid Id { get; set; }
        public string Value { get; set; }
    }

    public class ProductSizeCreateDto
    {
        public string Value { get; set; }
    }

    public class ProductSizeUpdateDto
    {
        public string Value { get; set; }
    }
}