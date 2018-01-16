using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Edu.Core.DomainRepository;
using Edu.Model;
using Edu.Model.Bussiness;
using Edu.Model.Core;
using Edu.Model.Procedure;

namespace Edu.Repository
{
    internal class MenuRepository : IMenuRepository
    {
        public QueryResult<Menu> GetMenu()
        {
            var result = ContainerFactory<ISqlExcuteContext>.Instance.RunProcedure<Menu>("get_menu");
            return result;
        }
    }
}
