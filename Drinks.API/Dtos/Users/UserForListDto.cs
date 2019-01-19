using System;

namespace Drinks.API.Dtos.Users
{
    public class UserForListDto
    {
        public int Id {get;set;}

        public string Email { get; set; }

        public string Username { get; set; }

        public DateTime Created { get; set; }

        public DateTime LastActive { get; set; }

        public string Introduction { get; set; }

        public string Favourites { get; set; }
    }
}