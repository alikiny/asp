using WebDemo.API.src.Database;
using WebDemo.Core.src.Abstraction;
using WebDemo.Core.src.Entity;

namespace WebDemo.API.src.Repository
{
    public class ProductColorRepo : BaseRepo<ProductColor>, IProductColorRepo
    {
        public ProductColorRepo(DatabaseContext databaseContext) : base(databaseContext)
        {
        }
    }
}