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
  public  class StudentService
    {
        #region Singletonton

        private static StudentService _instance = new StudentService();

        private StudentService()
        {

        }

        public static StudentService Instance => _instance ?? (_instance = new StudentService());

        #endregion

        /// <summary>
        /// 通过分页获取学生信息列表
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public QueryResult<Student> GetUserInfoByPaging(GetObjectsByPagingArgs args)
        {
            ArgumentHelper.Require(args.SchoolId, "SchoolId", Arguments.Positive);
            ArgumentHelper.Require(args.PageSize, "PageSize", Arguments.Positive);
            ArgumentHelper.Require(args.PageIndex, "PageIndex", Arguments.Positive);

            return ContainerFactory<IStudentRepository>.Instance.GetUserInfoByPaging(args);
        }

    }
}
