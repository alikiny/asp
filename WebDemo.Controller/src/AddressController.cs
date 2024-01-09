using WebDemo.Business.src.Abtraction;
using WebDemo.Business.src.DTO;
using WebDemo.Core.src.Entity;

namespace WebDemo.Controller.src
{
    public class AddressController : BaseController<Address, AddressReadDto, AddressCreateDto, AddressUpdateDto>
    {
        public AddressController(IAddressService service) : base(service)
        {
        }
    }
}