namespace WebDemo.Business.src.DTO
{
    public class ProductLineReadDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public float Price { get; set; }
        public CategoryReadDto Category { get; set; }
        public Guid CategoryId { get; set; }
        public IEnumerable<ImageReadDto> Images { get; set; }
    }

    public class ProductLineCreateDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public float Price { get; set; }
        public Guid CategoryId { get; set; }
        public IEnumerable<ImageCreateDto> Images { get; set; }
    }

    public class ProductLineUpdateDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public float Price { get; set; }
        public Guid CategoryId { get; set; }
        public IEnumerable<ImageCreateDto> NewImages { get; set; }
        public IEnumerable<Guid> DeleteImageIds { get; set; }
    }
}