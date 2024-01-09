using AutoMapper;
using WebDemo.Business.src.Abtraction;
using WebDemo.Business.src.DTO;
using WebDemo.Core.src.Abstraction;
using WebDemo.Core.src.Entity;

namespace WebDemo.Business.src.Service
{
    public class ProductSizeService : BaseService<ProductSize, ProductSizeReadDto, ProductSizeCreateDto, ProductSizeUpdateDto>, IProductSizeService
    {
        public ProductSizeService(IProductSizeRepo repo, IMapper mapper) : base(repo, mapper)
        {
        }
    }
}