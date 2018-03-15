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
  public  class BookfeeService
    {
        #region Singletonton

        private static BookfeeService _instance = new BookfeeService();

        private BookfeeService()
        {

        }

        public static BookfeeService Instance => _instance ?? (_instance = new BookfeeService());

        #endregion

        /// <summary>
        /// 获取全部教材杂费
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public QueryResult<Bookfee> GetFeeBySchoolId(GetObjectByIdArgs args)
        {
            ArgumentHelper.Require(args.SchoolId, "SchoolId", Arguments.Positive);

            return ContainerFactory<IBookfeeRepository>.Instance.GetFeeBySchoolId(args);
        }

        /// <summary>
        /// 添加教材杂费
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public CommandResult<int> AddBookfee(AddBookfeeArgs args)
        {
            ArgumentHelper.Require(args.SchoolId, "SchoolId", Arguments.Positive);
            ArgumentHelper.Require(args.CourseId, "CourseId", Arguments.Positive);
            ArgumentHelper.Require(args.FeeName, "FeeName", Arguments.NotEmptyOrWhitespace);
            ArgumentHelper.Require(args.Feetype, "Feetype", Arguments.Positive);
            ArgumentHelper.Require(args.Integration, "Integration", Arguments.Positive);
            ArgumentHelper.Require(args.Price, "Price", Arguments.Positive);

            return ContainerFactory<IBookfeeRepository>.Instance.AddBookfee(args);
        }

        /// <summary>
        /// 删除教材杂费
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public CommandResult<int> DeleteBookfee(DeleteBookfeeArgs args)
        {
            ArgumentHelper.Require(args.SchoolId, "SchoolId", Arguments.Positive);
            ArgumentHelper.Require(args.FeeId, "FeeId", Arguments.Positive);
            ArgumentHelper.Require(args.ModifyBy, "ModifyBy", Arguments.Positive);

            return ContainerFactory<IBookfeeRepository>.Instance.DeleteBookfee(args);
        }

        /// <summary>
        /// 编辑教材杂费
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public CommandResult<int> UpdateBookfee(UpdateBookfeeArgs args)
        {
            ArgumentHelper.Require(args.FeeId, "FeeId", Arguments.Positive);
            ArgumentHelper.Require(args.SchoolId, "SchoolId", Arguments.Positive);
            ArgumentHelper.Require(args.CourseId, "CourseId", Arguments.Positive);
            ArgumentHelper.Require(args.FeeName, "FeeName", Arguments.NotEmptyOrWhitespace);
            ArgumentHelper.Require(args.Feetype, "Feetype", Arguments.Positive);
            ArgumentHelper.Require(args.Integration, "Integration", Arguments.Positive);
            ArgumentHelper.Require(args.Price, "Price", Arguments.Positive);
            ArgumentHelper.Require(args.ModifyBy, "ModifyBy", Arguments.Positive);

            return ContainerFactory<IBookfeeRepository>.Instance.UpdateBookfee(args);
        }

    }
}
