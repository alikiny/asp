using WebDemo.Business.src.DTO;
using WebDemo.Core.src.Entity;

namespace WebDemo.Business.src.Abtraction
{
    public interface IAddressService : IBaseService<Address, AddressReadDto, AddressCreateDto, AddressUpdateDto>
    {
        
    }
}