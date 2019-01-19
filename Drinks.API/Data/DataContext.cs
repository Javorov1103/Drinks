using Microsoft.EntityFrameworkCore;
using Drinks.API.Models;

namespace Drinks.API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options):base(options) {}  

         public DbSet<Value> Values {get;set;}

         public DbSet<User> Users { get; set; }

         public DbSet<Recipe> Recipes { get; set; }

         public DbSet<Photo> Photos { get; set; }
        
    }
}