using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Edu.Model.Args;
using Edu.Services;
using NUnit.Framework;

namespace Edu.Test
{
    public class BusinessTest
    {

        [Test]
        public void AddRoleMenuArgsTest()
        {
            RoleMenuService.Instance.AddRoleMenu(new AddRoleMenuArgs()
            {
                RoleId = 1,
                CreateBy = 1,
                ModifyBy = 1,
                MenuId = 1
            });
        }

        [Test]
        public void GetUserInfoByPagingTest()
        {
            UserService.Instance.GetUserInfoByPaging(new GetUserInfoByPagingArgs()
            {
                PageIndex = 1,
                PageSize = 10,
                OrderBy = "",
                WhereStr = ""
            });
        }
    }
}
