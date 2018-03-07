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
        /// <summary>
        /// 执行Sql类型的存储过程（schoolid 为0表示使用0库，0库只能系统逻辑使用，业务逻辑下禁止使用0库）
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="schoolId"></param>
        /// <param name="sqlStr"></param>
        /// <param name="paras"></param>
        /// <returns></returns>
        QueryResult<T> Query<T>(int schoolId,string sqlStr, object paras = null) where T : DomainEntity;

        /// <summary>
        /// 执行查询select类型的存储过程（schoolid 为0表示使用0库，0库只能系统逻辑使用，业务逻辑下禁止使用0库）
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="schoolId"></param>
        /// <param name="procName"></param>
        /// <param name="paras"></param>
        /// <returns></returns>
        QueryResult<T> ExcuteQueryProcedure<T>(int schoolId, string procName, object paras = null);

        /// <summary>
        /// 执行返回第一行第一列类型的存储过程（schoolid 为0表示使用0库，0库只能系统逻辑使用，业务逻辑下禁止使用0库）
        /// </summary>
        /// <param name="schoolId"></param>
        /// <param name="procName"></param>
        /// <param name="paras"></param>
        /// <returns></returns>
        CommandResult<object> ExcuteScalarProceDure(int schoolId, string procName, object paras = null);

        /// <summary>
        /// 执行add\update\delete类型的存储过程（schoolid 为0表示使用0库，0库只能系统逻辑使用，业务逻辑下禁止使用0库）
        /// </summary>
        /// <param name="schoolId"></param>
        /// <param name="procName"></param>
        /// <param name="paras"></param>
        /// <returns></returns>
        CommandResult<int> ExcuteProceDure(int schoolId, string procName, object paras = null);
    }
}
