using Auth.API.Application.IServices;
using Auth.API.Application.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Auth.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserAuthService _userauthservice;
        private readonly ILogger<AuthController> _logger;

        public AuthController(IUserAuthService userAuthService, ILogger<AuthController> logger)
        {
            this._userauthservice = userAuthService;
            this._logger = logger;

        }

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> AddRoles([FromBody]string[] roleNames)
        {
            (bool IsSuccess, dynamic? DataObject, string[]? Errors, string Message) result = await this._userauthservice.AddRoles(roleNames);
            return Ok(result.Message);
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> Register([FromBody]RegisterVM newUser)
        {
            var result = await this._userauthservice.Register(newUser);
            if(result.IsSuccess) 
            {
                return Ok(result.Message);
            }

            return NotFound(result.Errors);
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> Login([FromBody]LoginVM loginVM) 
        {
            var result = await _userauthservice.Login(loginVM);
            if(result.IsSuccess) 
            {
                return Ok(result.DataObject);
            }
            return Unauthorized(result.Message);
        }

        [HttpGet]
        [Route("[action]")]
        [Authorize]
        public async Task<IActionResult> TestAuth()
        {
            return Ok("Auth Success");
        }
    }
}


