using WebDemo.API.src.Database;
using WebDemo.Core.src.Abstraction;
using WebDemo.Core.src.Entity;

namespace WebDemo.API.src.Repository
{
    public class ProductSizeRepo : BaseRepo<ProductSize>, IProductSizeRepo
    {
        public ProductSizeRepo(DatabaseContext databaseContext) : base(databaseContext)
        {
        }
    }
}