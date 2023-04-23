
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CodeTest.IServices;

namespace CodeTest.Controllers.API
{
    [Route("api/token")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        public IConfiguration _configuration;
        private readonly ITokenService _tokenService;

        public AccountController(IConfiguration configuration, ITokenService tokenService)
        {
            _configuration = configuration;
            _tokenService = tokenService;
        }

        [HttpPost("login")]
        public ActionResult Login(string email, string password)
        {
            if (email != "kno@gmail.com" && password != "admin")
                return Unauthorized("Invalid Credentials");
            else
                return new JsonResult(new { userName = email, token = _tokenService.CreateToken(email) });
        }
    }
}
