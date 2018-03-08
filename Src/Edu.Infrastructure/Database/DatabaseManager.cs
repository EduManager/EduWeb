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
            return "Server=rm-2zelu0bwe56072w78xo.mysql.rds.aliyuncs.com;Port=3306;Database=edu; User=huxum;Password=lird*654852;";
        }

        private static string GetDatabase(int schoolId)
        {
            string db = "edu";
            var rule = (schoolId%10+1).ToString().PadLeft(2,'0');
            db = db + rule;
            return $"Server=rm-2zelu0bwe56072w78xo.mysql.rds.aliyuncs.com;Port=3306;Database={db}; User=huxum;Password=lird*654852;";
        }

        public static MySqlConnection GetConnectionString(int schoolId)
        {
            if (schoolId == 0)
                return new MySqlConnection(GetDefaultDatabase());
            return new MySqlConnection(GetDatabase(schoolId));
        }
    }
}
