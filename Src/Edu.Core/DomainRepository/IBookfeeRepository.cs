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
   public interface IBookfeeRepository : IRepository
    {
        /// <summary>
        /// 获取校区列表
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        QueryResult<Bookfee> GetFeeBySchoolId(GetObjectByIdArgs args);

        ///// <summary>
        ///// 添加校区
        ///// </summary>
        ///// <param name="args"></param>
        ///// <returns></returns>
        //CommandResult<int> AddCampus(AddCampusArgs args);

        ///// <summary>
        ///// 删除校区
        ///// </summary>
        ///// <param name="args"></param>
        ///// <returns></returns>
        //CommandResult<int> DeleteCampus(DeleteCampusArgs args);

        ///// <summary>
        ///// 编辑校区
        ///// </summary>
        ///// <param name="args"></param>
        ///// <returns></returns>
        //CommandResult<int> UpdateCampus(UpdateCampusArgs args); 
    }
}
