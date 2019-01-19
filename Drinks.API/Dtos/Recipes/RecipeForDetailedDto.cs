using System.Collections.Generic;
using Drinks.API.Dtos.Photos;

namespace Drinks.API.Dtos.Recipes
{
    public class RecipeForDetailedDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Ingredients { get; set; }
        public string PhotoUrl { get; set; }
        public ICollection<PhotoForDetailedDto> Photos { get; set; }
    }
}