using MobileTestApp.Entites;
using MobileTestApp.Models;

namespace MobileTestApp.Mappers
{
    public static class UserMapper
    {
        public static User MapToModel(this UserEntity entity)
        {
            return new User(entity.Id,
                            entity.Username,
                            entity.HashedPassword);
        }

        public static UserEntity MapToEntity(this User user)
        {
            return new UserEntity
            {
                Id = user.Id,
                Username = user.Username,
                HashedPassword = user.HashedPassword
            };
        }
    }
}