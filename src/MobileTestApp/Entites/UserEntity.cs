using MobileTestApp.Entites.Abstract;
using SQLite;

namespace MobileTestApp.Entites
{
    [Table(TableName)]
    public class UserEntity : BaseEntity
    {
        public const string TableName = "User";

        [Unique]
        public string Username { get; set; }

        public string HashedPassword { get; set; }
    }
}