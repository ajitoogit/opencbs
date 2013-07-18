using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ServiceStack.OrmLite;
using OpenCBS.API.DataModel;
namespace OpenCBS.API.DAL
{
    public class RoleManager
    {
        readonly static OrmLiteConnectionFactory DbFactory = DALHelper.GetOrmLiteConnectionFactory();

        public static List<Role> GetAllRoles(bool isSelectDeletedToo)
        {
            //var dbFactory = DALHelper.GetOrmLiteConnectionFactory();

            using (var db = DbFactory.OpenDbConnection())
            {
                string query = DALHelper.ReadQuery("Role.GetAllRoles.sql");

                if (!isSelectDeletedToo)
                    query += " AND [deleted] = 0";

                return db.Query<Role>(query);
            }
        }

        public static Role GetRoleById(int id)
        {
            using (var db = DbFactory.OpenDbConnection())
            {
                string query = DALHelper.ReadQuery("Role.GetAllRoles.sql");
                query += " AND [id] = @Id";


                return db.Query<Role>(query, new {Id = id}).FirstOrDefault();
            }
        }
    }
}
