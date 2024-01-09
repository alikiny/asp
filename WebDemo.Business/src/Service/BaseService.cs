using AutoMapper;
using WebDemo.Business.src.Abtraction;
using WebDemo.Business.src.Shared;
using WebDemo.Core.src.Abstraction;
using WebDemo.Core.src.Entity;
using WebDemo.Core.src.Shared;

namespace WebDemo.Business.src.Service
{
    public class BaseService<T, TReadDto, TCreateDto, TUpdateDto> : IBaseService<T, TReadDto, TCreateDto, TUpdateDto>
    where T : BaseEntity
    {
        protected IBaseRepo<T> _repo;
        protected readonly IMapper _mapper;

        public BaseService(IBaseRepo<T> repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public virtual async Task<TReadDto> CreateOneAsync(TCreateDto createObject)
        {
            return _mapper.Map<T, TReadDto>(await _repo.CreateOneASync(_mapper.Map<TCreateDto, T>(createObject)));
        }

        public virtual async Task<bool> DeleteOneAsync(Guid id)
        {
            var foundItem = await _repo.GetByIdAsync(id);
            if (foundItem is not null)
            {
                return await _repo.DeleteOneAsync(foundItem);
            }
            return false;
        }

        public virtual async Task<IEnumerable<TReadDto>> GetAllAsync(GetAllOptions getAllOptions)
        {
            return _mapper.Map<IEnumerable<T>, IEnumerable<TReadDto>>(await _repo.GetAllAsync(getAllOptions));
        }

        public virtual async Task<TReadDto> GetByIdAsync(Guid id)
        {
            var foundItem = await _repo.GetByIdAsync(id);
            if (foundItem is null)
            {
                throw CustomException.NotFound();
            }
            return _mapper.Map<T, TReadDto>(foundItem);
        }

        public virtual async Task<bool> UpdateOneAsync(Guid id, TUpdateDto updateObject)
        {
            var foundItem = await _repo.GetByIdAsync(id) ?? throw CustomException.NotFound();
            var properties = updateObject!.GetType().GetProperties();
            foreach (var p in properties)
            {
                if(p.GetValue(foundItem) is not null && p.GetValue(updateObject) is null)
                {
                    p.SetValue(updateObject, p.GetValue(foundItem));
                }
            }
            return await _repo.UpdateOneAsync(_mapper.Map<TUpdateDto, T>(updateObject));
        }
    }
}

/* 

Automapper<UserUpdateDto, User>
controller: 
endpoint: [PATCH] api/v1/users
authorized ? 
request body: 
{
    id: 836482364,
    firstName: "",
    email: "",
}
 */

/* 
admin endpoint [PATCH]:  api/v1/users/:userId
normal user endpoint [PATCH]:  api/v1/users/profile 
*/