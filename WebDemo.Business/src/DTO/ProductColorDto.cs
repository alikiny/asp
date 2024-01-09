namespace WebDemo.Business.src.DTO
{
    public class ProductColorReadDto
    {
        public Guid Id { get; set; }
        public string Value { get; set; }
    }

    public class ProductColorCreateDto
    {
        public string Value { get; set; }
    }

    public class ProductColorUpdateDto
    {
        public string Value { get; set; }
    }
}