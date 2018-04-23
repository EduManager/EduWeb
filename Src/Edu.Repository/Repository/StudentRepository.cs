using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Edu.Core.DomainRepository;
using Edu.Infrastructure.Helper;
using Edu.Infrastructure.Sql;
using Edu.Model;
using Edu.Model.Args;
using Edu.Model.Core;

namespace Edu.Repository
{
    public class StudentRepository : IStudentRepository
    {
        public QueryResult<Student> GetUserInfoByPaging(GetObjectsByPagingArgs args)
        {
            try
            {
                DynamicParameters p = new DynamicParameters();
                p.Add("@p_school_id", args.SchoolId);
                p.Add("@p_page_size", args.PageSize);
                p.Add("@p_page_now", args.PageIndex);
                p.Add("@p_order_string", args.OrderBy);
                p.Add("@p_where_string", args.WhereStr);
                p.Add("@p_out_rows", null, DbType.Int32, ParameterDirection.Output);
                var result =
                    ContainerFactory<ISqlExcuteContext>.Instance.ExcuteQueryProcedure<Student>(args.SchoolId, "get_students_by_paging", p);
                args.RowsCount = p.Get<int>("@p_out_rows");
                return result;
            }
            catch (Exception e)
            {
                LogHelper.Error(this.GetType(), "学生模块--通过分页获取学生列表失败", e);
                return QueryResult.Failure<Student>(e.ToString());
            }
        }

    }
}
