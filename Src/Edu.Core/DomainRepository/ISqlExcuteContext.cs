using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Edu.Model;
using RepositoryEF.Core.Data;

namespace Edu.Core.DomainRepository
{
    public interface ISqlExcuteContext : IUnitOfWork
    {
        QueryResult<T> Query<T>(string sqlStr, object paras = null) where T : DomainEntity;

        /// <summary>
        /// 执行查询select类型的存储过程
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="procName"></param>
        /// <param name="paras"></param>
        /// <returns></returns>
        QueryResult<T> ExcuteQueryProcedure<T>(string procName, object paras = null);

        /// <summary>
        /// 执行返回第一行第一列类型的存储过程
        /// </summary>
        /// <param name="procName"></param>
        /// <param name="paras"></param>
        /// <returns></returns>
        CommandResult<object> ExcuteScalarProceDure(string procName, object paras = null);

        /// <summary>
        /// 执行add\update\delete类型的存储过程
        /// </summary>
        /// <param name="procName"></param>
        /// <param name="paras"></param>
        /// <returns></returns>
        CommandResult<int> ExcuteProceDure(string procName, object paras = null);
    }
}
