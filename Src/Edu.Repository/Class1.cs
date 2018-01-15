using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Edu.Infrastructure.Sql;

namespace Edu.Repository
{
    public class Class1
    {
        public void Test()
        {
            string _strConn = "Data Source=192.168.11.128;Initial Catalog=PD_ShopDB;uid=sa;password=123;";
            string _strSQL = "SELECT BrandID,BrandName,IsEnable,BrandEnName,BigLogo,SmllLogo,BrandStory,BrandLink,IsDelete,CreateDate  FROM Brands  WITH(NOLOCK)";

            using (SqlConnection connection = new SqlConnection(_strConn))
            {
                connection.Open();
                var brand = connection.Query<Class1>(_strSQL).ToList();
            }
        }
    }
}
