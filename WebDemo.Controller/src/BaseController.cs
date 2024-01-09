using Microsoft.AspNetCore.Mvc;
using WebDemo.Business.src.Abtraction;
using WebDemo.Core.src.Entity;
using WebDemo.Core.src.Shared;

namespace WebDemo.Controller.src
{
    [ApiController]
    [Route("api/v1/[controller]s")]
    public class BaseController<T, TReadDto, TCreateDto, TUpdateDto> : ControllerBase where T : BaseEntity
    {
        protected readonly IBaseService<T, TReadDto, TCreateDto, TUpdateDto> _service;

        public BaseController(IBaseService<T, TReadDto, TCreateDto, TUpdateDto> service)
        {
            _service = service;
        }

        [HttpPost()]
        public virtual async Task<ActionResult<TReadDto>> CreateOneAsync([FromBody] TCreateDto createObject)
        {
            return Ok(await _service.CreateOneAsync(createObject));
            //return CreatedAtAction(nameof(CreateOneAsync), await _service.CreateOneAsync(createObject));
        }

        [HttpDelete("{id:guid}")] // users/:userid
        public virtual async Task<ActionResult<bool>> DeleteOneAsync([FromRoute] Guid id)
        {
            return Ok(await _service.DeleteOneAsync(id));
        }

        // [Authorize(Policy = "SuperAdmin")]
        // [Authorize(Roles = "Customer")] // role-based
        [HttpGet()] // /users?limit=10&offet=1
        public virtual async Task<ActionResult<IEnumerable<TReadDto>>> GetAllAsync([FromQuery] GetAllOptions getAllOptions)
        {
            return Ok(await _service.GetAllAsync(getAllOptions));
        }

        [HttpGet("{id:guid}")]
        public virtual async Task<ActionResult<TReadDto>> GetByIdAsync([FromRoute] Guid id)
        {
            return Ok(await _service.GetByIdAsync(id));
        }

        [HttpPatch("{id:guid}")]
        // patch: update the existing resource
        // put: update if resource exist, otherwise, create that resource
        public virtual async Task<ActionResult<bool>> UpdateOneAsync([FromRoute] Guid id, [FromBody] TUpdateDto updateObject)
        {
            return Ok(await _service.UpdateOneAsync(id, updateObject));
        }
/*         [Authorize(Policy = "MaxLength")]
        [HttpPatch("/update-address")]
        public async Task<bool> UpdateAddress()
        {
            return true;
        } */
    }
}