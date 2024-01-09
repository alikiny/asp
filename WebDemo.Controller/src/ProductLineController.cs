using WebDemo.Business.src.Abtraction;
using WebDemo.Business.src.DTO;
using WebDemo.Core.src.Entity;

namespace WebDemo.Controller.src
{
    public class ProductLineController : BaseController<ProductLine, ProductLineReadDto, ProductLineCreateDto, ProductLineUpdateDto>
    {
        public ProductLineController(IProductLineService service) : base(service)
        {
        }
    }
}