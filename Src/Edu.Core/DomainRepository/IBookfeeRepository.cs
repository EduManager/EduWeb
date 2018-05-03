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
        /// 获取全部教材杂费
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        QueryResult<Bookfee> GetFeeBySchoolId(GetObjectByIdArgs args);

        /// <summary>
        /// 添加教材杂费
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        CommandResult<int> AddBookfee(AddBookfeeArgs args);

        /// <summary>
        /// 删除教材杂费
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        CommandResult<int> DeleteBookfee(DeleteObjectArgs args);

        /// <summary>
        /// 编辑教材杂费
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        CommandResult<int> UpdateBookfee(UpdateBookfeeArgs args);
    }
}
