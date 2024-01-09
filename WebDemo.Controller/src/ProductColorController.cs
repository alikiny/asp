using WebDemo.Business.src.Abtraction;
using WebDemo.Business.src.DTO;
using WebDemo.Core.src.Entity;

namespace WebDemo.Controller.src
{
    public class ProductColorController : BaseController<ProductColor, ProductColorReadDto, ProductColorCreateDto, ProductColorUpdateDto>
    {
        public ProductColorController(IProductColorService service) : base(service)
        {
        }
    }
}