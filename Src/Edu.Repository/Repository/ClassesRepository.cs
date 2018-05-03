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
    internal class ClassesRepository: BaseRepository, IClassesRepository
    {
        public CommandResult<int> AddAttendClass(AddAttendClassArgs args)
        {
            try
            {
                var result = ContainerFactory<ISqlExcuteContext>.Instance.ExcuteQueryProcedure<int>(args.SchoolId, "add_attend_class", args);
                if (result.Code == 200 && result.Items.Count > 0)
                {
                    return CommandResult.Success(result.Items[0]);
                }
                return CommandResult.Failure<int>();
            }
            catch (Exception e)
            {
                LogHelper.Error(this.GetType(), "班级管理-添加上课时间，SchoolId:" + args.SchoolId + ",学校编号:" + args.SchoolId, e);
                return CommandResult.Failure<int>(e.ToString());
            }
        }

        public CommandResult<int> AddClass(AddClassesArgs args)
        {
            try
            {
                var result = ContainerFactory<ISqlExcuteContext>.Instance.ExcuteQueryProcedure<int>(args.SchoolId, "add_classes", args);
                if (result.Code == 200 && result.Items.Count > 0)
                {
                    return CommandResult.Success(result.Items[0]);
                }
                return CommandResult.Failure<int>();
            }
            catch (Exception e)
            {
                LogHelper.Error(this.GetType(), "班级管理-添加班级，SchoolId:" + args.SchoolId + ",学校编号:" + args.SchoolId, e);
                return CommandResult.Failure<int>(e.ToString());
            }
        }

        public CommandResult<int> DeleteAttendClass(DeleteObjectArgs args)
        {
            try
            {
                var result = ContainerFactory<ISqlExcuteContext>.Instance.ExcuteProceDure(args.SchoolId, "delete_attend_class", args);
                return result;
            }
            catch (Exception e)
            {
                LogHelper.Error(this.GetType(), "班级管理-删除课时失败，AttendClassId:" + args.ObjectId, e);
                return CommandResult.Failure<int>(e.ToString());
            }
        }

        public CommandResult<int> DeleteClass(DeleteObjectArgs args)
        {
            try
            {
                var result = ContainerFactory<ISqlExcuteContext>.Instance.ExcuteProceDure(args.SchoolId, "delete_class", args);
                return result;
            }
            catch (Exception e)
            {
                LogHelper.Error(this.GetType(), "班级管理-删除班级失败，ClassId:" + args.ObjectId, e);
                return CommandResult.Failure<int>(e.ToString());
            }
        }

        public QueryResult<AttendClass> GetAttendClassesByClassId(GetAttendByClassIdArgs args)
        {
            try
            {
                var result =
                    ContainerFactory<ISqlExcuteContext>.Instance.ExcuteQueryProcedure<AttendClass>(args.SchoolId, "get_attend_class_by_class_id",
                        args);
                return result;
            }
            catch (Exception e)
            {
                LogHelper.Error(this.GetType(), "通过班级ID获取课时列表失败", e);
                return QueryResult.Failure<AttendClass>(e.ToString());
            }
        }

        public QueryResult<Classes> GetClassesBySchoolId(GetObjectByIdArgs args)
        {
            try
            {
                var result =
                    ContainerFactory<ISqlExcuteContext>.Instance.ExcuteQueryProcedure<Classes>(args.SchoolId, "get_class_by_school_id",
                        args);
                return result;
            }
            catch (Exception e)
            {
                LogHelper.Error(this.GetType(), "通过学校ID获取班级列表失败", e);
                return QueryResult.Failure<Classes>(e.ToString());
            }
        }

        public CommandResult<int> UpdateAttendClass(UpdateAttendClassArgs args)
        {
            try
            {
                var result = ContainerFactory<ISqlExcuteContext>.Instance.ExcuteProceDure(args.SchoolId, "update_attend_class", args);
                return result;
            }
            catch (Exception e)
            {
                LogHelper.Error(this.GetType(), "班级管理-编辑课时失败，AttendClassId:" + args.AttendClassId, e);
                return CommandResult.Failure<int>(e.ToString());
            }
        }

        public CommandResult<int> UpdateClass(UpdateClassesArgs args)
        {
            try
            {
                var result = ContainerFactory<ISqlExcuteContext>.Instance.ExcuteProceDure(args.SchoolId, "update_class", args);
                return result;
            }
            catch (Exception e)
            {
                LogHelper.Error(this.GetType(), "班级管理-编辑班级失败，ClassId:" + args.ClassId, e);
                return CommandResult.Failure<int>(e.ToString());
            }
        }
    }
}
