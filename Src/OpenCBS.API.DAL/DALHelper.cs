using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Reflection;
using ServiceStack.OrmLite;
namespace OpenCBS.API.DAL
{
    public class DALHelper
    {
        public static string ReadQuery(string queryPath)
        {
            using (var stream = Assembly
                .GetExecutingAssembly()
                .GetManifestResourceStream("OpenCBS.API.DAL.Queries" + queryPath))
            using (var reader = new StreamReader(stream))
            {
                return reader.ReadToEnd();
            }
        }

        public static OrmLiteConnectionFactory GetOrmLiteConnectionFactory()
        {
            return  new OrmLiteConnectionFactory(
            @"server=.\Sqlexpress;Trusted_Connection=yes; database=Opencbs13; user id=sa; password=1",
            SqlServerDialect.Provider);
        }
    }
}
