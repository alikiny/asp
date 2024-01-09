using WebDemo.Business.src.Abtraction;
using WebDemo.Business.src.DTO;
using WebDemo.Core.src.Entity;

namespace WebDemo.Controller.src
{
    public class ProductSizeController : BaseController<ProductSize, ProductSizeReadDto, ProductSizeCreateDto, ProductSizeUpdateDto>
    {
        public ProductSizeController(IProductSizeService service) : base(service)
        {
        }
    }
}