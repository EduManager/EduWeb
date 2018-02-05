using System.Collections.Generic;
using System.Linq;
using Edu.Model;
using Edu.Model.Core;

namespace Edu.Core.DomainRepository
{
    public interface IMenuRepository : IRepository
    {
        /// <summary>
        /// 获取菜单内容
        /// </summary>
        /// <returns></returns>
        QueryResult<Menu> GetMenu();
    }
}
