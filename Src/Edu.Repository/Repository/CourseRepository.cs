using Edu.Core.DomainRepository;
using Edu.Infrastructure.Helper;
using Edu.Model;
using Edu.Model.Args;
using Edu.Model.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edu.Repository
{
    internal class CourseRepository : BaseRepository, ICourseRepository
    {
        public CommandResult<int> AddCourse(AddCourseArgs args)
        {
            try
            {
                var result = ContainerFactory<ISqlExcuteContext>.Instance.ExcuteQueryProcedure<int>(1, "add_course", args);
                if (result.Code == 200 && result.Items.Count > 0)
                {
                    return CommandResult.Success(result.Items[0]);
                }
                return CommandResult.Failure<int>();
            }
            catch (Exception e)
            {
                LogHelper.Error(this.GetType(), "课程管理-添加课程，SchoolId:" + args.SchoolId + ",学校编号:" + args.SchoolId, e);
                return CommandResult.Failure<int>(e.ToString());
            }
        }

        public CommandResult<int> AddCourseType(AddCourseTypeArgs args)
        {
            try
            {
                var result = ContainerFactory<ISqlExcuteContext>.Instance.ExcuteQueryProcedure<int>(1, "add_course_type", args);
                if (result.Code == 200 && result.Items.Count > 0)
                {
                    return CommandResult.Success(result.Items[0]);
                }
                return CommandResult.Failure<int>();
            }
            catch (Exception e)
            {
                LogHelper.Error(this.GetType(), "课程管理-添加课程类别，SchoolId:" + args.SchoolId + ",学校编号:" + args.SchoolId, e);
                return CommandResult.Failure<int>(e.ToString());
            }
        }

        public CommandResult<int> DeleteCourse(DeleteObjectArgs args)
        {
            try
            {
                var result = ContainerFactory<ISqlExcuteContext>.Instance.ExcuteProceDure(1, "delete_course", args);
                return result;
            }
            catch (Exception e)
            {
                LogHelper.Error(this.GetType(), "课程管理-删除课程，courseId:" + args.ObjectId, e);
                return CommandResult.Failure<int>(e.ToString());
            }
        }

        public CommandResult<int> DeleteCourseType(DeleteObjectArgs args)
        {
            try
            {
                var result = ContainerFactory<ISqlExcuteContext>.Instance.ExcuteProceDure(1, "delete_course_type", args);
                return result;
            }
            catch (Exception e)
            {
                LogHelper.Error(this.GetType(), "课程管理-删除课程类别，coursetypeId:" + args.ObjectId, e);
                return CommandResult.Failure<int>(e.ToString());
            }
        }

        public QueryResult<Course> GetCourseBySchoolId(GetObjectByIdArgs args)
        {
            try
            {
                var result =
                    ContainerFactory<ISqlExcuteContext>.Instance.ExcuteQueryProcedure<Course>(args.SchoolId, "get_course_by_school_id",
                        args);
                return result;
            }
            catch (Exception e)
            {
                LogHelper.Error(this.GetType(), "通过学校ID获取课程列表失败", e);
                return QueryResult.Failure<Course>(e.ToString());
            }
        }

        public QueryResult<CourseType> GetCourseTypeBySchoolId(GetObjectByIdArgs args)
        {
            try
            {
                var result =
                    ContainerFactory<ISqlExcuteContext>.Instance.ExcuteQueryProcedure<CourseType>(args.SchoolId, "get_coursetype_by_school_id",
                        args);
                return result;
            }
            catch (Exception e)
            {
                LogHelper.Error(this.GetType(), "通过学校ID获取课程类别列表失败", e);
                return QueryResult.Failure<CourseType>(e.ToString());
            }
        }

        public CommandResult<int> UpdateCourse(UpdateCourseArgs args)
        {
            try
            {
                var result = ContainerFactory<ISqlExcuteContext>.Instance.ExcuteProceDure(1, "update_course", args);
                return result;
            }
            catch (Exception e)
            {
                LogHelper.Error(this.GetType(), "课程管理-编辑课程，CourseId:" + args.CourseId, e);
                return CommandResult.Failure<int>(e.ToString());
            }
        }

        public CommandResult<int> UpdateCourseType(UpdateCourseTypeArgs args)
        {
            try
            {
                var result = ContainerFactory<ISqlExcuteContext>.Instance.ExcuteProceDure(1, "update_course_type", args);
                return result;
            }
            catch (Exception e)
            {
                LogHelper.Error(this.GetType(), "课程管理-编辑课程类别，CourseTypeId:" + args.CourseTypeId, e);
                return CommandResult.Failure<int>(e.ToString());
            }
        }
    }
}
