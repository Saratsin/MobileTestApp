using SQLite;

namespace MobileTestApp.Entites.Abstract
{
    public class BaseEntity
    {
        [PrimaryKey, Unique, AutoIncrement]
        public long Id { get; set; }
    }
}