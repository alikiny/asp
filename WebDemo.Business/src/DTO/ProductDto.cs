namespace WebDemo.Business.src.DTO
{
    public class ProductReadDto
    {
        public Guid Id { get; set; }
        public ProductLineReadDto ProductLine { get; set; }
        public IEnumerable<ProductSizeReadDto> Sizes { get; set; }
        public IEnumerable<ProductColorReadDto> Colors { get; set; }
        public IEnumerable<ImageReadDto> Images { get; set; }
    }

    public class ProductCreateDto
    {
        public int Inventory { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public float Price { get; set; }
        public IEnumerable<Guid> SizeIds { get; set; }
        public IEnumerable<Guid> ColorIds { get; set; }
        public IEnumerable<ImageCreateDto> Images { get; set; }
    }

    public class ProductUpdateDto
    {
        public int Inventory { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public float Price { get; set; }
        public IEnumerable<Guid> SizeIds { get; set; }
        public IEnumerable<Guid> ColorIds { get; set; }
    }
}