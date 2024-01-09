using AutoMapper;
using WebDemo.Business.src.Abtraction;
using WebDemo.Business.src.DTO;
using WebDemo.Core.src.Abstraction;
using WebDemo.Core.src.Entity;

namespace WebDemo.Business.src.Service
{
    public class ProductLineService : BaseService<ProductLine, ProductLineReadDto, ProductLineCreateDto, ProductLineUpdateDto>, IProductLineService
    {
        public ProductLineService(IProductLineRepo repo, IMapper mapper) : base(repo, mapper)
        {
        }
    }
}