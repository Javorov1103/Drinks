using System;
using System.Collections.Generic;

namespace Drinks.API.Models
{
    public class User
    {
        public int Id {get;set;}

        public string Email { get; set; }

        public byte[] PasswordHash { get; set; }

        public byte[] PasswordSalt { get; set; }

        public string Username { get; set; }

        public DateTime Created { get; set; }

        public DateTime LastActive { get; set; }

        public string Introduction { get; set; }

        public string Favourites { get; set; }

        public ICollection<Recipe> Recipes { get; set; }
    }
}