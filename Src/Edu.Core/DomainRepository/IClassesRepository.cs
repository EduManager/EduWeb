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
    }
}
