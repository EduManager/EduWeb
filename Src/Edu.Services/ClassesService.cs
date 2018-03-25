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
    public class ClassesService
    {
        #region Singletonton

        private static ClassesService _instance = new ClassesService();

        private ClassesService()
        {

        }

        public static ClassesService Instance => _instance ?? (_instance = new ClassesService());

        #endregion

        /// <summary>
        /// 获取全部教材杂费
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public QueryResult<Classes> GetClassesBySchoolId(GetObjectByIdArgs args)
        {
            ArgumentHelper.Require(args.SchoolId, "SchoolId", Arguments.Positive);

            return ContainerFactory<IClassesRepository>.Instance.GetClassesBySchoolId(args);
        }
    }
}
