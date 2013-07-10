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

    public class GetUsers
    {
        
        public static User GetUserByCredentials(string username, string password)
        {
            var dbFactory = DALHelper.GetOrmLiteConnectionFactory();

            using (var db = dbFactory.OpenDbConnection())
            {
                string query = DALHelper.ReadQuery("User.GetUserByCredentials.sql");
                var user = db.Query<User>(query, new { Username = username,Password = password }).First();
                return user;
            }

        }
    }
}
