using SQLite;
using System;
using System.IO;
using System.Threading.Tasks;

namespace MobileTestApp.Repositories.Abstract
{
    public abstract class BaseRepository
    {
        private const string DatabaseFileName = "database.db3";

        private static readonly string _databaseFilePath = Path.Combine(Xamarin.Essentials.FileSystem.AppDataDirectory, DatabaseFileName);

        private static readonly Lazy<SQLiteAsyncConnection> _connectionLazy = new Lazy<SQLiteAsyncConnection>(() =>
        {
            var flags = SQLiteOpenFlags.ReadWrite | SQLiteOpenFlags.Create | SQLiteOpenFlags.SharedCache;
            var connection = new SQLiteAsyncConnection(_databaseFilePath, flags);
            return connection;
        });

        protected virtual async ValueTask<SQLiteAsyncConnection> GetConnectionAsync()
        {
            var isFirstTimeCall = !_connectionLazy.IsValueCreated;
            var connection = _connectionLazy.Value;
            if (isFirstTimeCall)
            {
                await connection.EnableWriteAheadLoggingAsync().ConfigureAwait(false);
            }

            return connection;
        }
    }
}