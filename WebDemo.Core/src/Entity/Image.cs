namespace WebDemo.Core.src.Entity
{
    public class Image : BaseEntity
    {
        public ProductLine ProductLine { get; set; }
        public Guid ProductLineId { get; set; }
        public byte[] Data { get; set; }
    }
}