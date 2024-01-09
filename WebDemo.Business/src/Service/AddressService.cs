using AutoMapper;
using WebDemo.Business.src.Abtraction;
using WebDemo.Business.src.DTO;
using WebDemo.Core.src.Abstraction;
using WebDemo.Core.src.Entity;

namespace WebDemo.Business.src.Service
{
    public class AddressService : BaseService<Address, AddressReadDto, AddressCreateDto, AddressUpdateDto>, IAddressService
    {
        public AddressService(IAddressRepo repo, IMapper mapper) : base(repo, mapper)
        {
        }
    }
}