using System.Collections.Generic;
using System.Threading.Tasks;
using Drinks.API.Data.Contracts;
using Drinks.API.Models;
using Microsoft.EntityFrameworkCore;

namespace Drinks.API.Data
{
    public class DrinkingRepository : IDrinkingRepository
    {
        private readonly DataContext context;
        public DrinkingRepository(DataContext context)
        {
            this.context = context;

        }

        public void Add<T>(T entity) where T : class
        {
            this.context.Add(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
           this.context.Remove(entity);
        }

        public async Task<User> GetUser(int id)
        {
            var user = await context.Users
            .Include(r=>r.Recipes).ThenInclude(r =>r.Photos).FirstOrDefaultAsync(u =>u.Id==id);

            return user;
        }

        public async Task<IEnumerable<User>> GetUsers()
        {
            return await this.context.Users.Include(r =>r.Recipes).ToListAsync();
        }

        public async Task<bool> SaveAll()
        {
            return await this.context.SaveChangesAsync() > 0;
        }

        public async Task<IEnumerable<Recipe>> GetRecipes()
        {
            return await this.context.Recipes.Include(r=>r.Photos).ToListAsync();
        }

        public async Task<Recipe> GetRecipe(int id)
        {
            return await this.context.Recipes.Include(r=>r.Photos).FirstOrDefaultAsync(r => r.Id == id); 
        }
    }
}