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
  public  class CampusService
    {
        #region Singletonton

        private static CampusService _instance = new CampusService();

        private CampusService()
        {

        }

        public static CampusService Instance => _instance ?? (_instance = new CampusService());

        #endregion

        /// <summary>
        /// 获取角色菜单列表
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public QueryResult<Campus> GetCampusBySchoolId(GetObjectByIdArgs args)
        {
            ArgumentHelper.Require(args.Id, "SchoolId", Arguments.Positive);

            return ContainerFactory<ICampusRepository>.Instance.GetCampusBySchoolId(args);
        }

    }
}
