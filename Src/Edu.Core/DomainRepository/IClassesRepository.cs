using Edu.Model;
using Edu.Model.Args;
using Edu.Model.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edu.Core.DomainRepository
{
    public interface IClassesRepository : IRepository
    {
        /// <summary>
        /// 获取全部数据
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        QueryResult<Classes> GetClassesBySchoolId(GetObjectByIdArgs args);

        QueryResult<AttendClass> GetAttendClassesByClassId(GetAttendByClassIdArgs args);

        CommandResult<int> AddClass(AddClassesArgs args);

        CommandResult<int> AddAttendClass(AddAttendClassArgs args);

        /// <summary>
        /// 删除课时
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        CommandResult<int> DeleteAttendClass(DeleteObjectArgs args);

        /// <summary>
        /// 编辑课时
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        CommandResult<int> UpdateAttendClass(UpdateAttendClassArgs args);

        /// <summary>
        /// 删除班级
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        CommandResult<int> DeleteClass(DeleteObjectArgs args);

        /// <summary>
        /// 编辑班级
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        CommandResult<int> UpdateClass(UpdateClassesArgs args);
    }
}
