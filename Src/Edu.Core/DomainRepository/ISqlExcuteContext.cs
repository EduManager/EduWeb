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

        QueryResult<T> RunProcedure<T>(string procName, object paras = null);
    }
}
