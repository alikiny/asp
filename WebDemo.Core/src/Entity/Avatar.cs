namespace WebDemo.Core.src.Entity
{
    public class Avatar : BaseEntity
    {
        public byte[] Data { get; set; }
        public Guid UserId { get; set; }
    }
}