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
        private readonly string _strConn = "Server=mxgumwcmyyqv.mysql.sae.sina.com.cn;Port=10270;Database=edu; User=wangjj;Password=jerry123;";
        

        public QueryResult<T> Query<T>(string sqlStr, object paras = null) where T : DomainEntity
        {
            List<T> result = new List<T>();
            using (IDbConnection connection = new MySqlConnection(_strConn))
            {
                connection.Open();
                result = connection.Query<T>(sqlStr, param: paras)
                    .ToList();
            }
            return QueryResult.Success<T>(result);
        }

        public QueryResult<T> ExcuteQueryProcedure<T>(string procName, object paras = null)
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

        public CommandResult<object> ExcuteScalarProceDure(string procName, object paras = null)
        {
            object result;
            using (IDbConnection connection = new MySqlConnection(_strConn))
            {
                connection.Open();
                result = connection.ExecuteScalar(procName, param: paras, commandType: CommandType.StoredProcedure);
            }
            return CommandResult.Success(result);
        }

        public CommandResult<int> ExcuteProceDure(string procName, object paras = null)
        {
            int result = -1;
            using (IDbConnection connection = new MySqlConnection(_strConn))
            {
                connection.Open();
                result = connection.Execute(procName, param: paras, commandType: CommandType.StoredProcedure);
            }
            return CommandResult.Success(result);
        }
    }
}
