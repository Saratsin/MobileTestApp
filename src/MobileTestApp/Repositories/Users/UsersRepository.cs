using MobileTestApp.Entites;
using MobileTestApp.Repositories.Abstract;

namespace MobileTestApp.Repositories.Users
{
    public class UsersRepository : BaseRepository<UserEntity>, IUsersRepository
    {
    }
}