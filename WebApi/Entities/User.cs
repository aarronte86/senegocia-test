using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senegocia.WebApi.Entities
{
    public class User : Entity
    {
        private User() { }

        public static User Create(string firstName, string lastName, string email, string password)
        {
            // TODO: Add user creation validation rules

            return new User
            {
                FirstName = firstName,
                LastName = lastName,
                Email = email,
                Password = password
            };
        }

        public string FirstName { get; private set; }

        public string LastName { get; private set; }

        public string Email { get; private set; }

        public string Password { get; private set; }
    }
}
