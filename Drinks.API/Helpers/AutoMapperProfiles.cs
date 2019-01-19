using System.Linq;
using AutoMapper;
using Drinks.API.Dtos.Photos;
using Drinks.API.Dtos.Recipes;
using Drinks.API.Dtos.Users;
using Drinks.API.Models;

namespace Drinks.API.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<User,UserForListDto>();
            CreateMap<User,UserForDetailedDto>();

            CreateMap<Photo,PhotoForDetailedDto>();

            CreateMap<Recipe,RecipeForDetailedDto>().ForMember(
                dest => dest.PhotoUrl, opt => {
                    opt.MapFrom(src => src.Photos.FirstOrDefault(p => p.IsMain).Url);
                }
            );
            CreateMap<Recipe,RecipeForListDto>().ForMember(
                dest => dest.PhotoUrl, opt => {
                    opt.MapFrom(src => src.Photos.FirstOrDefault(p => p.IsMain).Url);
                }
            );
        }
    }
}