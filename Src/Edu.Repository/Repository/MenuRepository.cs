using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Edu.Core.DomainRepository;
using Edu.Infrastructure.Helper;
using Edu.Model;
using Edu.Model.Core;

namespace Edu.Repository
{
    internal class MenuRepository : IMenuRepository
    {
        public QueryResult<Menu> GetMenu()
        {
            try
            {
                var result = ContainerFactory<ISqlExcuteContext>.Instance.ExcuteQueryProcedure<Menu>("get_menu");
                return result;
            }
            catch (Exception e)
            {
                LogHelper.Error(this.GetType(),"获取菜单列表失败",e);
                return QueryResult.Failure<Menu>(e.ToString());
            }
        }
    }
}
