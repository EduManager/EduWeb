using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Edu.Core.DomainRepository;
using Edu.Infrastructure.Common;
using Edu.Model;
using Edu.Model.Core;
using Edu.Repository;

namespace Edu.Services
{
    public class MenuService
    {
        #region Singletonton

        private static MenuService _instance = new MenuService();

        private MenuService()
        {

        }

        public static MenuService Instance => _instance ?? (_instance = new MenuService());

        #endregion

        /// <summary>
        /// 获取菜单内容
        /// </summary>
        /// <returns></returns>
        public QueryResult<Menu> GetMenu()
        {
            return ContainerFactory<IMenuRepository>.Instance.GetMenu();
        }
    }
}
