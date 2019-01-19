using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Drinks.API.Data.Contracts;
using System.Threading.Tasks;
using AutoMapper;
using Drinks.API.Dtos.Users;
using System.Collections.Generic;

namespace Drinks.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IDrinkingRepository repo;
        private readonly IMapper mapper;

        public UsersController(IDrinkingRepository repo, IMapper mapper)
        {
            this.mapper = mapper;
            this.repo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            var users = await this.repo.GetUsers();

            var usersToReturn = mapper.Map<IEnumerable<UserForListDto>>(users);

            return Ok(usersToReturn);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUser(int id)
        {
            var user = await this.repo.GetUser(id);

            var userToReturn = mapper.Map<UserForDetailedDto>(user);

            return Ok(userToReturn);
        }

    }
}