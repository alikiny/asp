using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebDemo.Business.src.Abtraction;
using WebDemo.Business.src.DTO;
using WebDemo.Core.src.Entity;

namespace WebDemo.Controller.src
{
    public class OrderController : BaseController<Order, OrderReadDto, OrderCreateDto, OrderUpdateDto>
    {
        private readonly IAuthorizationService _authorizationService;

        public OrderController(IOrderService service, IAuthorizationService authorizationService) : base(service)
        {
            _authorizationService = authorizationService;
        }

        [Authorize/* (Roles = "Customer") */]
        public override Task<ActionResult<OrderReadDto>> CreateOneAsync([FromBody] OrderCreateDto createObject)
        {
            /*             var authenticatedClaims = HttpContext.User;
                        var userId = authenticatedClaims.FindFirst(c => c.Type == ClaimTypes.NameIdentifier)!.Value;
                        createObject.UserId = new Guid(userId); */

            /* service should require 2 params: user id and createObject */
            return base.CreateOneAsync(createObject);
        }

        [Authorize]
        public override Task<ActionResult<bool>> UpdateOneAsync([FromRoute] Guid orderId, [FromBody] OrderUpdateDto updateObject)
        {
            var authenticatedClaims = HttpContext.User;
            var userId = authenticatedClaims.FindFirst(c => c.Type == ClaimTypes.NameIdentifier)!.Value;
            // resource-based authorization
            return base.UpdateOneAsync(orderId, updateObject);
        }

        // [Authorize(Policy = "AdminOrOwner")]
        public override async Task<ActionResult<bool>> DeleteOneAsync([FromRoute] Guid id) // only admin and owner of the order
        {
            /* who does the order belong to -> order repo -> get order by id -> get owner id -> compare owner id == claim ?*/
            // var order = await _service.GetByIdAsync(id);
            var authenticatedClaims = HttpContext.User;
            var userId = authenticatedClaims.FindFirst(c => c.Type == ClaimTypes.NameIdentifier)!.Value;
            /* var authorizationResult = _authorizationService
            .AuthorizeAsync(HttpContext.User, order, "AdminOrOwner")
            .GetAwaiter()
            .GetResult(); */
            var order = new OrderReadDto { Id = Guid.NewGuid(), UserId = new Guid(userId) };
            Console.WriteLine($"userId: {userId}");
            var authorizationResult = await _authorizationService
            .AuthorizeAsync(HttpContext.User, order, "AdminOrOwner");

            if (authorizationResult.Succeeded)
            {
                return await base.DeleteOneAsync(id);
            }
            else if (User.Identity!.IsAuthenticated)
            {
                return new ForbidResult();
            }
            else
            {
                return new ChallengeResult();
            }
        }
    }
}