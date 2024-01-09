using AutoMapper;
using WebDemo.Business.src.Abtraction;
using WebDemo.Business.src.DTO;
using WebDemo.Core.src.Abstraction;
using WebDemo.Core.src.Entity;

namespace WebDemo.Business.src.Service
{
    public class ProductColorService : BaseService<ProductColor, ProductColorReadDto, ProductColorCreateDto, ProductColorUpdateDto>, IProductColorService
    {
        public ProductColorService(IProductColorRepo repo, IMapper mapper) : base(repo, mapper)
        {
        }
    }
}