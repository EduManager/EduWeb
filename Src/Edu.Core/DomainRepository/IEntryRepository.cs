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
   public interface IEntryRepository : IRepository
    {
        /// <summary>
        /// 添加报名信息
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        CommandResult<int> AddEntry(AddEntryArgs args);

        /// <summary>
        /// 添加报名费用
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        CommandResult<int> AddAccount(AddAccountArgs args);

    }
}
