using AutoMapper;
using WebDemo.Business.src.Abtraction;
using WebDemo.Business.src.DTO;
using WebDemo.Core.src.Abstraction;
using WebDemo.Core.src.Entity;

namespace WebDemo.Business.src.Service
{
    public class ImageService : BaseService<Image, ImageReadDto, ImageCreateDto, ImageUpdateDto>, IImageService
    {
        public ImageService(IImageRepo repo, IMapper mapper) : base(repo, mapper)
        {
        }
    }
}