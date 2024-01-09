using WebDemo.API.src.Database;
using WebDemo.Core.src.Abstraction;
using WebDemo.Core.src.Entity;

namespace WebDemo.API.src.Repository
{
    public class ProductLineRepo : BaseRepo<ProductLine>, IProductLineRepo
    {
        public ProductLineRepo(DatabaseContext databaseContext) : base(databaseContext)
        {
        }
    }
}