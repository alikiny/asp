using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using WebDemo.Business.src.Abtraction;
using WebDemo.Business.src.DTO;
using WebDemo.Core.src.Entity;

namespace WebDemo.Controller.src
{
    // [Authorize(Roles = "Admin")]
    public class UserController : BaseController<User, UserReadDto, UserCreateDto, UserUpdateDto>
    {
        private readonly IAvartarService _avartarService;

        public UserController(IUserService service, IAvartarService avartarService) : base(service)
        {
            _avartarService = avartarService;
        }

        [HttpPost("register")] // have method RegisterAsync in service to create for role customer
        /*         public async Task<object> MyMethodAsync(string parameter)
                {

                } */

        [HttpPost("create-admin")] // service with method createadmin with role admin
        /*         public async Task<object> MyMethodAsync(string parameter)
                {

                } */

        [HttpGet("{id:Guid}"), Authorize(Roles = "Admin")]
        public override Task<ActionResult<UserReadDto>> GetByIdAsync([FromRoute] Guid id)
        {
            return base.GetByIdAsync(id);
        }

        [HttpGet("profile")]
        [Authorize]
        public async Task<ActionResult<UserReadDto>> GetUserProfile()
        {
            var authenticatedClaims = HttpContext.User;
            var id = authenticatedClaims.FindFirst(c => c.Type == ClaimTypes.NameIdentifier)!.Value;
            return await base.GetByIdAsync(Guid.Parse(id));
        }

        /*         [HttpPost("")]
                [Consumes("multipart/form-data")]
                public new async Task<ActionResult<UserReadDto>> CreateOneAsync([FromForm] UserForm userForm)
                {
                    if (userForm.AvatarImage == null || userForm.AvatarImage.Length == 0)
                    {
                        return BadRequest("Avatar is missing");
                    }
                    return CreatedAtAction(nameof(CreateOneAsync), await _service.CreateOneAsync(userForm.UserCreateDto));
                } */
        [HttpPost("upload-avatar")]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> UploadAvatar([FromForm] UserForm userForm)
        {
            if (userForm.AvatarImage == null || userForm.AvatarImage.Length == 0)
            {
                return BadRequest("Avatar is missing");
            }
            else
            {
                using (var ms = new MemoryStream())
                {
                    await userForm.AvatarImage.CopyToAsync(ms);
                    var content = ms.ToArray();
                    // return File(content, userForm.AvatarImage.ContentType);
                    return File(content, userForm.AvatarImage.ContentType);
                }
            }
        }
        /*         [HttpGet("avatar")]
                public async Task<ActionResult> GetAvatar()
                {

                } */

    }

    public class UserForm
    {
        public IFormFile AvatarImage { get; set; }
        public Guid UserId { get; set; }
    }
}