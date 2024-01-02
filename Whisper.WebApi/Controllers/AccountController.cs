using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.Dynamic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Whisper.Business.DTOs.Account;
using Whisper.Core.Application.Services;
using Whisper.Core.Domain.Entities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Whisper.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IJwtService _jwtService;

        public AccountController(UserManager<AppUser> userManager,
                                 RoleManager<IdentityRole> roleManager,
                                 IJwtService jwtService)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _jwtService = jwtService;
        }

        [HttpPost("login")]
        public async Task<ActionResult> Login(LoginDto loginUser)
        {
            AppUser? appUser = await _userManager.FindByNameAsync(loginUser.Username);

            if (appUser == null) return NotFound();

            if(!await _userManager.CheckPasswordAsync(appUser, loginUser.Password)) return Unauthorized();

            string token = _jwtService.GenerateToken(appUser);

            return Ok(token);
        }

        [HttpPost("register")]
        public async Task<ActionResult> Register(RegisterDto registerUser)
        {
            AppUser newUser = new AppUser()
            {
                UserName = registerUser.Username,
                Email = registerUser.Email
            };

            IdentityResult result = await _userManager.CreateAsync(newUser, registerUser.Password);


            if (!result.Succeeded)
            {
                List<IdentityError> errors = [.. result.Errors];

                return BadRequest(errors);
            }

            return Ok();
        }
    }
}
