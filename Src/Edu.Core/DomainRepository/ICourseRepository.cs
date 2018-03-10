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
   public interface ICourseRepository : IRepository
    {
        /// <summary>
        /// 获取课程类别列表
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        QueryResult<CourseType> GetCourseTypeBySchoolId(GetObjectByIdArgs args);

        /// <summary>
        /// 添加课程类别
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        CommandResult<int> AddCourseType(AddCourseTypeArgs args);

        /// <summary>
        /// 删除课程类别
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        CommandResult<int> DeleteCourseType(DeleteCourseTypeArgs args);

        /// <summary>
        /// 编辑课程类别
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        CommandResult<int> UpdateCourseType(UpdateCourseTypeArgs args); 
    }
}
