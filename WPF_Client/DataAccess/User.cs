using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_Client.DataAccess
{
    class User
    {
        /// <summary>
        /// Returns a User with matching ID from the database, or null if no matching user was found.
        /// The returned User will have an empty password field for security reasons.
        /// </summary>
        public static Dbo.User GetUserById(long id)
        {
            try
            {
                using (ProjectDBEntities ctx = new ProjectDBEntities())
                {
                    var user = (from tmp in ctx.T_User
                                   where tmp.Id == id
                                   select tmp).First();
                    return new Dbo.User(user.Id, user.Name, "", user.Admin);
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// Returns a User with matching Name from the database, or null if no matching user was found.
        /// The returned User will have an empty password field for security reasons.
        /// </summary>
        public static Dbo.User GetUserByName(string name)
        {
            try
            {
                using (ProjectDBEntities ctx = new ProjectDBEntities())
                {
                    var user = (from tmp in ctx.T_User
                                where tmp.Name == name
                                select tmp).First();
                    return new Dbo.User(user.Id, user.Name, "", user.Admin);
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// Returns a User with matching Name and Password from the database, or null if no matching user was found.
        /// The returned User will have an empty password field for security reasons.
        /// </summary>
        public static Dbo.User GetUserByCredentials(string name, string password)
        {
            try
            {
                using (ProjectDBEntities ctx = new ProjectDBEntities())
                {
                    var user = (from tmp in ctx.T_User
                                where tmp.Name == name && tmp.Password == password
                                select tmp).First();
                    return new Dbo.User(user.Id, user.Name, "", user.Admin);
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// Adds a new User to the database and returns the success of the operation.
        /// The id field of the parameter will be ignored when adding to the database.
        /// </summary>
        public static bool AddUser(Dbo.User user)
        {
            try
            {
                using (ProjectDBEntities ctx = new ProjectDBEntities())
                {
                    ctx.T_User.Add(new T_User()
                    {
                        Name = user.Name,
                        Password = user.Password,
                        Admin = user.Admin
                    });
                    if (ctx.SaveChanges() == 0)
                        return false;
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
