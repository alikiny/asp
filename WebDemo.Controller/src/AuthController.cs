using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebDemo.Business.src.Abtraction;
using WebDemo.Core.src.Shared;

namespace WebDemo.Controller.src
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class AuthController : ControllerBase
    {

        private IAuthService _service;
        public AuthController(IAuthService service)
        {
            _service = service;
        }
        [HttpPost()]
        public async Task<string> Login(Credentials cred)
        {
            return await _service.Login(cred);
        }
    }
}