using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Edu.Model;
using Edu.Model.Args;
using Edu.Model.Core;

namespace Edu.Core.DomainRepository
{
    public interface IStudentRepository : IRepository
    {
        /// <summary>
        /// 通过分页获取学生信息列表
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        QueryResult<Student> GetUserInfoByPaging(GetObjectsByPagingArgs args);
    }
}
