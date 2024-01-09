namespace WebDemo.Core.src.Entity
{
    public class ProductLine : BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public float Price { get; set; }
        public Category Category { get; set; }
        public Guid CategoryId { get; set; }
        public IEnumerable<Image> Images { get; set; }
    }
}