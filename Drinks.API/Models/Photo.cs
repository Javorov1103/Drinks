using System;

namespace Drinks.API.Models
{
    public class Photo
    {
        public int Id { get; set; }

        public string Url { get; set; }

        public DateTime Added { get; set; }

        public bool IsMain { get; set; }

        public int RecipeId { get; set; }

        public Recipe Recipe { get; set; }

    }
}