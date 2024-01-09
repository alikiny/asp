using WebDemo.Core.src.Entity;

namespace WebDemo.Business.src.DTO
{
    public class ImageCreateDto
    {
        public Guid Product { get; set; }
        public byte[] Data { get; set; }
    }

    public class ImageReadDto
    {
        public Guid Id { get; set; }
        public byte[] Data { get; set; }
    }

    public class ImageUpdateDto
    {
        public byte[] Data { get; set; }
    }

}