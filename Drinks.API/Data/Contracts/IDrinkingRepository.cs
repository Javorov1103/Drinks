using System.Threading.Tasks;
using System.Collections.Generic;
using Drinks.API.Models;

namespace Drinks.API.Data.Contracts
{
    public interface IDrinkingRepository
    {
         void Add<T>(T entity) where T: class;

         void Delete<T>(T entity) where T:class;

         Task<bool> SaveAll();

         Task<IEnumerable<User>> GetUsers();

         Task<User> GetUser(int id);

         Task<IEnumerable<Recipe>> GetRecipes();

         Task<Recipe> GetRecipe(int id);
    }
}