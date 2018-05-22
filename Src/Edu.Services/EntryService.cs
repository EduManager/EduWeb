using Edu.Core.DomainRepository;
using Edu.Infrastructure.Common;
using Edu.Model;
using Edu.Model.Args;
using Edu.Model.Core;
using Edu.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edu.Services
{
   public class EntryService
    {
        #region Singletonton

        private static EntryService _instance = new EntryService();

        private EntryService()
        {

        }

        public static EntryService Instance => _instance ?? (_instance = new EntryService());

        #endregion


        /// <summary>
        /// 添加报名信息
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public CommandResult<int> AddEntry(AddEntryArgs args)
        {
            ArgumentHelper.Require(args.SchoolId, "SchoolId", Arguments.Positive);
            ArgumentHelper.Require(args.CreateBy, "CreateBy", Arguments.Positive);
            ArgumentHelper.Require(args.ModifyBy, "ModifyBy", Arguments.Positive);

            return ContainerFactory<IEntryRepository>.Instance.AddEntry(args);
        }

        /// <summary>
        /// 添加缴费
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public CommandResult<int> AddAccount(AddAccountArgs args)
        {
            ArgumentHelper.Require(args.SchoolId, "SchoolId", Arguments.Positive);
            ArgumentHelper.Require(args.CreateBy, "CreateBy", Arguments.Positive);
            ArgumentHelper.Require(args.ModifyBy, "ModifyBy", Arguments.Positive);

            return ContainerFactory<IEntryRepository>.Instance.AddAccount(args);
        }
        /// <summary>
        /// 通过分页获取学生信息列表
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public QueryResult<Entry> GetEntryListByPaging(GetObjectsByPagingArgs args)
        {
            ArgumentHelper.Require(args.SchoolId, "SchoolId", Arguments.Positive);
            ArgumentHelper.Require(args.PageSize, "PageSize", Arguments.Positive);
            ArgumentHelper.Require(args.PageIndex, "PageIndex", Arguments.Positive);

            return ContainerFactory<IEntryRepository>.Instance.GetEntryListByPaging(args);
        }

    }
}
