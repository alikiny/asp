using WebDemo.API.src.Database;
using WebDemo.Core.src.Abstraction;
using WebDemo.Core.src.Entity;

namespace WebDemo.API.src.Repository
{
    public class ImageRepo : BaseRepo<Image>, IImageRepo
    {
        public ImageRepo(DatabaseContext databaseContext) : base(databaseContext)
        {
        }
    }
}