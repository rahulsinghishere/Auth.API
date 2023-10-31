using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Auth.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GoogleAuthController : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> GoogleLogin()
        {
            return Ok();
        }
    }
}
