namespace WebDemo.Core.src.Entity
{
    public class Product : BaseEntity
    {
        public ProductLine ProductLine { get; set; }
        public int Inventory { get; set; }
        public ProductSize? Size { get; set; }
        public ProductColor? Color { get; set; }

        public Guid ProductLineId { get; set; }
        public Guid? SizeId { get; set; }
        public Guid? ColorId { get; set; }
    }

    public class ProductSize : BaseEntity
    {
        public int Value { get; set; }
        public IEnumerable<Product> Products { get; set; }
    }

    public class ProductColor : BaseEntity
    {
        public string Value { get; set; }
        public IEnumerable<Product> Products { get; set; }
    }
}