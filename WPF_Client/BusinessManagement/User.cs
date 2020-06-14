using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_Client.BusinessManagement
{
    class User
    {
        /// <summary>
        /// Returns a User with matching ID from the database, or null if no matching user was found.
        /// The returned User will have an empty password field for security reasons.
        /// </summary>
        public static Dbo.User GetUserById(long id)
        {
            return DataAccess.User.GetUserById(id);
        }

        /// <summary>
        /// Returns a User with matching Name from the database, or null if no matching user was found.
        /// The returned User will have an empty password field for security reasons.
        /// </summary>
        public static Dbo.User GetUserByName(string name)
        {
            return DataAccess.User.GetUserByName(name);
        }

        /// <summary>
        /// Returns a User with matching Name and Password from the database, or null if no matching user was found.
        /// The returned User will have an empty password field for security reasons.
        /// </summary>
        public static Dbo.User GetUserByCredentials(string name, string password)
        {
            return DataAccess.User.GetUserByCredentials(name, password);
        }

        /// <summary>
        /// Adds a new User to the database and returns the success of the operation.
        /// The id field of the parameter will be ignored when adding to the database.
        /// </summary>
        public static bool AddUser(Dbo.User user)
        {
            return DataAccess.User.AddUser(user);
        }
    }
}
