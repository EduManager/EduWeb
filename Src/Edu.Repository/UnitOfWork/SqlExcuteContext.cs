using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Edu.Core.DomainRepository;
using Edu.Infrastructure.Sql;
using Edu.Model;
using MySql.Data.MySqlClient;

namespace Edu.Repository.UnitOfWork
{
    public class SqlExcuteContext : ISqlExcuteContext
    {
        private readonly string _strConn = "Data Source=127.0.0.1;Initial Catalog=edu;uid=root;password=jerry123;";
       
        public QueryResult<T> Query<T>(string sqlStr,object paras = null) where T : DomainEntity
        {
            List<T> result = new List<T>();
            using (IDbConnection connection = new MySqlConnection(_strConn))
            {
                connection.Open();
                result = connection.Query<T>(sqlStr, param:paras)
                .ToList();
            }
            return QueryResult.Success<T>(result);
        }

        public QueryResult<T> RunProcedure<T>(string procName, object paras = null)
        {
            List<T> result = new List<T>();
            using (IDbConnection connection = new MySqlConnection(_strConn))
            {
                connection.Open();
                result = connection.Query<T>(procName, param: paras, commandType: CommandType.StoredProcedure)
                    .ToList();
            }
            return QueryResult.Success<T>(result);
        }
    }
}
