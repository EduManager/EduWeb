using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Edu.Infrastructure.Database
{
    public class DatabaseManager
    {
        private static string GetDefaultDatabase()
        {
            return "Server=mxgumwcmyyqv.mysql.sae.sina.com.cn;Port=10270;Database=edu; User=wangjj;Password=jerry123;";
        }

        private static string GetDatabase(int schoolId)
        {
            string db = "edu";
            var rule = (schoolId%10+1).ToString().PadLeft(2,'0');
            db = db + rule;
            return $"Server=mxgumwcmyyqv.mysql.sae.sina.com.cn;Port=10270;Database={db}; User=wangjj;Password=jerry123;";
        }

        public static MySqlConnection GetConnectionString(int schoolId)
        {
            if (schoolId == 0)
                return new MySqlConnection(GetDefaultDatabase());
            return new MySqlConnection(GetDatabase(schoolId));
        }
    }
}
