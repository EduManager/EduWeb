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
            RoleMenuService.Instance.CreateOrUpdateRoleMenu(new CreateOrUpdateRoleMenuArgs()
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
            var t = UserService.Instance.GetUserInfoByPaging(new GetObjectsByPagingArgs()
            {
                PageIndex = 1,
                PageSize = 10,
                OrderBy = "",
                WhereStr = " where u.school_id  = 1"
            });
        }
    }
}
