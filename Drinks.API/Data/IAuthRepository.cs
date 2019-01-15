using System.Threading.Tasks;
using Drinks.API.Models;

namespace Drinks.API.Data
{
    public interface IAuthRepository
    {
         Task<User> Register(User user, string password);

         Task<User> Login(string email, string password);

         Task<bool> UserExist(string email);
    }
}