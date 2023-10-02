using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using StringCalculator.Application.Interfaces;
using StringCalculator.Core.Entities;

namespace StringIntegerCalculator_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly ITokenService _tokenService;
        public AuthenticationController(ITokenService tokenService) { 
            _tokenService = tokenService;
        }
        [HttpPost("login")]
        public ActionResult Login(LoginModel model)
        {
            AppUser _appUser = new AppUser();
            _appUser.UserId = model.UserId;
            _appUser.UserName = model.UserName;


            // Generate a JWT token
            var token = _tokenService.GenerateToken(_appUser);

            return Ok(new { Token = token });
        }
    }
}
