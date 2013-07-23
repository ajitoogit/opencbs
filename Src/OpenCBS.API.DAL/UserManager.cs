using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ServiceStack.OrmLite;
using System.Data;
using OpenCBS.API.DataModel;
using System.Runtime.Serialization;
using ServiceStack.Common.Extensions;

namespace OpenCBS.API.DAL
{

    public class UserManager
    {
        private readonly static OrmLiteConnectionFactory _dbFactory = DALHelper.GetOrmLiteConnectionFactory();

        public static User GetUserByCredentials(string username, string password)
        {
            using (var db = _dbFactory.OpenDbConnection())
            {
                string query = DALHelper.ReadQuery("User.GetUserByCredentials.sql");
                var user = db.Query<User>(query, new { Username = username,Password = password }).FirstOrDefault();
                return user;
            }

        }

        public static User GetUserById(int id)
        {
             using (var db = _dbFactory.OpenDbConnection())
            {
                string query = DALHelper.ReadQuery("User.GetUsers.sql");
                query += " AND [id] = @Id";


                return db.Query<User>(query, new {Id = id}).FirstOrDefault();
            }
        }

        public static List<User>GetUsers(bool isIncludeDeleted)
        {
            using (var db = _dbFactory.OpenDbConnection())
            {
                string query = DALHelper.ReadQuery("User.GetUsers.sql");
                var users = db.Query<User>(query + " AND [deleted] = @Include", new { Include = isIncludeDeleted});
                return users;
            }
        }

        public static List<string> GetPermissionsByRoleId(int roleId)
        {
            return new List<string> {"TestService"};
        }

        public static int InsertUser(User user)
        {

            using (var db = _dbFactory.OpenDbConnection())
            {
                string query = DALHelper.ReadQuery("User.InsertUser.sql");
                var insertedId = db.SqlScalar<int>(query,
                                                   new
                                                       {
                                                           RoleCode = user.RoleCode,
                                                           Deleted = user.Deleted,
                                                           Username = user.Username,
                                                           Password = user.Password,
                                                           FirstName = user.FirstName,
                                                           LastName = user.LastName,
                                                           Mail = user.Mail,
                                                           Sex = user.Sex,
                                                           Phone = user.Phone,
                                                           RoleId = user.RoleId
                                                       });
                return insertedId;
            }
        }

        public static void UpdateUser(User user)
        {
            using (var db = _dbFactory.OpenDbConnection())
            {
                string query = DALHelper.ReadQuery("User.UpdateUser.sql");
                var result = db.SqlScalar<int>(query, new
                    {
                        Id = user.Id,
                        Username = user.Username,
                        Password = user.Password,
                        RoleCode = user.RoleCode,
                        FirstName = user.FirstName,
                        LastName = user.LastName,
                        Mail = user.Mail,
                        Sex = user.Sex,
                        Phone = user.Phone,
                        RoleId = user.RoleId
                    });
            }
        }

        public static void DeleteUser(int id)
        {
            using (var db = _dbFactory.OpenDbConnection())
            {
                const string query = "UPDATE [Users] SET deleted = 1 WHERE [id] = @UserId";
                var result = db.SqlScalar<int>(query, new {UserId = id});
            }
            
        }

    }
}
