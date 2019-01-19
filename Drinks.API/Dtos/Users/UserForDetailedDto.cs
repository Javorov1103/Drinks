using System;
using System.Collections.Generic;
using Drinks.API.Dtos.Recipes;
using Drinks.API.Models;

namespace Drinks.API.Dtos.Users
{
    public class UserForDetailedDto
    {
        public int Id {get;set;}

        public string Email { get; set; }

        public string Username { get; set; }

        public DateTime Created { get; set; }

        public DateTime LastActive { get; set; }

        public string Introduction { get; set; }

        public string Favourites { get; set; }

        public ICollection<RecipeForDetailedDto> Recipes { get; set; }
    }
}