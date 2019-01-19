using System;

namespace Drinks.API.Dtos.Photos
{
    public class PhotoForDetailedDto
    {
        public int Id { get; set; }

        public string Url { get; set; }

        public DateTime Added { get; set; }

        public bool IsMain { get; set; }
    }
}