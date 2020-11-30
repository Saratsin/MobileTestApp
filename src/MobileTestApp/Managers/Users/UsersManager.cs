using MobileTestApp.Common.Utils;
using MobileTestApp.Mappers;
using MobileTestApp.Models;
using MobileTestApp.Repositories.Users;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace MobileTestApp.Managers.Users
{
    public class UsersManager : IUsersManager
    {
        private readonly IUsersRepository _usersRepository;

        public UsersManager(IUsersRepository usersRepository)
        {
            _usersRepository = usersRepository;
        }

        public async Task<bool> AddUserAsync(string username, string password)
        {
            var hashedPassword = PasswordUtils.Hash(password);
            var user = new User(Guid.NewGuid(), username, hashedPassword);
            var userEntity = user.MapToEntity();
            var result = await _usersRepository.SaveAsync(userEntity).ConfigureAwait(false);

            return result > 0;
        }

        public async Task<User> GetUserOrDefaultAsync(string username)
        {
            var userEntities = await _usersRepository.GetAllAsync(entity => entity.Username == username).ConfigureAwait(false);
            var userEntity = userEntities.FirstOrDefault();

            return userEntity?.MapToModel();
        }
    }
}
