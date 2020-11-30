using MobileTestApp.Models;
using System.Threading.Tasks;

namespace MobileTestApp.Managers.Users
{
    public interface IUsersManager
    {
        Task<bool> AddUserAsync(string username, string password);

        Task<User> GetUserOrDefaultAsync(string username);
    }
}