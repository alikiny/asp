using Microsoft.AspNetCore.Mvc;
using WebDemo.Business.src.Abtraction;
using WebDemo.Business.src.DTO;
using WebDemo.Core.src.Entity;

namespace WebDemo.Controller.src
{
    [ApiController]
    [Route("api/v1/categories")]
    public class CategoryController : BaseController<Category, CategoryReadDto, CategoryCreateDto, CategoryUpdateDto>
    {
        public CategoryController(ICategoryService service) : base(service)
        {
        }
    }
}