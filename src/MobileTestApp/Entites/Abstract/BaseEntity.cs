using SQLite;
using System;

namespace MobileTestApp.Entites.Abstract
{
    public class BaseEntity
    {
        [PrimaryKey, Unique]
        public Guid Id { get; set; }
    }
}