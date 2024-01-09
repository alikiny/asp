using WebDemo.API.src.Database;
using WebDemo.Core.src.Abstraction;
using WebDemo.Core.src.Entity;

namespace WebDemo.API.src.Repository
{
    public class AddressRepo : BaseRepo<Address>, IAddressRepo
    {
        public AddressRepo(DatabaseContext databaseContext) : base(databaseContext)
        {
        }
    }
}