using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Drinks.API.Data;
using Drinks.API.Dtos;
using Drinks.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Drinks.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepository repo;
        private readonly IConfiguration config;
        public AuthController(IAuthRepository repo, IConfiguration config)
        {
            this.config = config;
            this.repo = repo;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(UserForRegisterDto userForRegister)
        {

            userForRegister.Email = userForRegister.Email.ToLower();

            if (await this.repo.UserExist(userForRegister.Email))
            {
                return BadRequest("User with this email already exist!");
            }

            var userToCreate = new User
            {
                Email = userForRegister.Email
            };

            var createdUser = await this.repo.Register(userToCreate, userForRegister.Password);

            return StatusCode(201);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(UserForLoginDto userForLogin)
        {
            var userFromRepo = await this.repo.Login(userForLogin.Email.ToLower(), userForLogin.Password);

            if (userFromRepo == null)
            {
                return Unauthorized();
            }

            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, userFromRepo.Id.ToString()),
                new Claim(ClaimTypes.Name, userFromRepo.Email)
            };

            var key = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(this.config.GetSection("AppSettings:Token").Value));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = creds
            };

            var tokenHandler = new JwtSecurityTokenHandler();

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return Ok(new
            {
                token = tokenHandler.WriteToken(token)
            });
        }

    }
}