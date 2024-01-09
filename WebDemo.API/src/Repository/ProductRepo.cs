using Microsoft.EntityFrameworkCore;
using WebDemo.API.src.Database;
using WebDemo.Core.src.Abstraction;
using WebDemo.Core.src.Entity;
using WebDemo.Core.src.Shared;

namespace WebDemo.API.src.Repository
{
    public class ProductRepo : BaseRepo<Product>, IProductRepo
    {
        public ProductRepo(DatabaseContext databaseContext) : base(databaseContext)
        {
        }
        public override async Task<IEnumerable<Product>> GetAllAsync(GetAllOptions getAllOptions)
        {
            return await 
            _data.AsNoTracking()
            .Include(p=>p.Color)
            .Include(p=>p.Size)
            .Include(p => p.ProductLine).ThenInclude(pl => pl.Category)
            .Include(p => p.ProductLine).ThenInclude(pl => pl.Images)
            .OrderBy(p => p.UpdatedAt)
            .Skip(getAllOptions.Offset)
            .Take(getAllOptions.Limit)
            .ToArrayAsync();
        }
    }
}