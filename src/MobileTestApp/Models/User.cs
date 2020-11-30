using System;

namespace MobileTestApp.Models
{
    public class User
    {
        public User(Guid id,
                    string username,
                    string hashedPassword)
        {
            Id = id;
            Username = username;
            HashedPassword = hashedPassword;
        }

        public Guid Id { get; }

        public string Username { get; }

        public string HashedPassword { get; }
    }
}