using AutoMapper;
using WebDemo.Business.src.Abtraction;
using WebDemo.Business.src.DTO;
using WebDemo.Core.src.Abstraction;
using WebDemo.Core.src.Entity;

namespace WebDemo.Business.src.Service
{
    public class ProductService : BaseService<Product, ProductReadDto, ProductCreateDto, ProductUpdateDto>, IProductService
    {
        public ProductService(IProductRepo repo, IMapper mapper) : base(repo, mapper)
        {
        }
    }
}