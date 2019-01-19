using AutoMapper;
using Drinks.API.Data.Contracts;
using Drinks.API.Dtos.Recipes;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Drinks.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecipeController : ControllerBase
    {
        private readonly IDrinkingRepository repo;
        private readonly IMapper mapper;
        public RecipeController(IDrinkingRepository repo, IMapper mapper)
        {
            this.mapper = mapper;
            this.repo = repo;

        }

        [HttpGet]
        public async Task<IActionResult> GetRecipes()
        {
            var recipes = await this.repo.GetRecipes();

            var recipesToReturn = mapper.Map<IEnumerable<RecipeForListDto>>(recipes);

            return Ok(recipesToReturn);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetRecipe(int id)
        {
            var recipe = await this.repo.GetRecipe(id);

            var recipeToReturn = mapper.Map<RecipeForDetailedDto>(recipe);
            if(recipeToReturn.Ingredients == null)
            recipeToReturn.Ingredients = "A lot of ingredients";

            return Ok(recipeToReturn);
        }
    }
}