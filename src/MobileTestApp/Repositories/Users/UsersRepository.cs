using MobileTestApp.Common.Utils;
using MobileTestApp.Entites;
using MobileTestApp.Repositories.Abstract;
using SQLite;
using System.Threading.Tasks;

namespace MobileTestApp.Repositories.Users
{
    public class UsersRepository : BaseRepository<UserEntity>, IUsersRepository
    {
        private const string DemoUserUsername = "demo";

        private bool _isFirstCall = true;

        protected override async ValueTask<SQLiteAsyncConnection> GetConnectionAsync()
        {
            var connection = await base.GetConnectionAsync().ConfigureAwait(false);
            if (_isFirstCall)
            {
                var demoUser = await connection.Table<UserEntity>()
                                               .FirstOrDefaultAsync(user => user.Username == DemoUserUsername)
                                               .ConfigureAwait(false);
                if (demoUser is null)
                {
                    demoUser = new UserEntity
                    {
                        Username = DemoUserUsername,
                        HashedPassword = PasswordUtils.Hash("demo")
                    };

                    await connection.InsertAsync(demoUser).ConfigureAwait(false);
                }

                _isFirstCall = false;
            }

            return connection;
        }
    }
}