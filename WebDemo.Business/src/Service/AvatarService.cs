using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using WebDemo.Business.src.Abtraction;
using WebDemo.Business.src.DTO;
using WebDemo.Core.src.Abstraction;
using WebDemo.Core.src.Entity;

namespace WebDemo.Business.src.Service
{
    public class AvatarService : IAvartarService
    {
        private readonly IAvatarRepo _repo;
        private readonly IMapper _mapper;

        public AvatarService(IAvatarRepo repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }
        public async Task<string> CreateAvartarAsync(AvartarCreateDto avartarCreateDto)
        {
            var avatar =  await _repo.CreateAvartarAsync(_mapper.Map<Avatar>(avartarCreateDto));
            return avatar;
            /* avatar id: 8746r834hbjkbsdyucg6ygbhjbhj
            -> create url : /:id 
            https://example.com/api/v1/images/:id */
        }
    }
}