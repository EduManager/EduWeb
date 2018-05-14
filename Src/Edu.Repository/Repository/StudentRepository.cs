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
        public QueryResult<Student> GetStudentListByPaging(GetObjectsByPagingArgs args)
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

        public CommandResult<int> AddStudent(AddStudentArgs args)
        {
            try
            {
                var result = ContainerFactory<ISqlExcuteContext>.Instance.ExcuteQueryProcedure<int>(0, "add_student", args);
                if (result.Code == 200 && result.Items.Count > 0)
                {
                    return CommandResult.Success(result.Items[0]);
                }
                return CommandResult.Failure<int>();
            }
            catch (Exception e)
            {
                LogHelper.Error(this.GetType(), "学生模块-添加学生失败，Name:" + args.Name + ",学校编号:" + args.SchoolId, e);
                return CommandResult.Failure<int>(e.ToString());
            }
        }

        public CommandResult<int> DeleteStudent(DeleteObjectArgs args)
        {
            try
            {
                var result = ContainerFactory<ISqlExcuteContext>.Instance.ExcuteProceDure(0, "delete_student", args);
                return result;
            }
            catch (Exception e)
            {
                LogHelper.Error(this.GetType(), "学生模块-删除学生失败，StudentId:" + args.ObjectId, e);
                return CommandResult.Failure<int>(e.ToString());
            }
        }

        public CommandResult<Student> GetStudentById(GetObjectByIdArgs args)
        {
            try
            {
                var result =
                    ContainerFactory<ISqlExcuteContext>.Instance.ExcuteQueryProcedure<Student>(0,
                        "get_student_by_id", args);
                if (result.Code == 200)
                    return CommandResult.Success(result.Items.FirstOrDefault());
                return CommandResult.Failure<Student>();
            }
            catch (Exception e)
            {
                LogHelper.Error(this.GetType(), "学生模块--通过ID获取学生信息失败", e);
                return CommandResult.Failure<Student>();
            }
        }

    }
}
