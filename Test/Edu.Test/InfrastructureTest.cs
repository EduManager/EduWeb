using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Edu.Infrastructure.Helper;
using Edu.Model.Args;
using Edu.Services;
using NUnit.Framework;

namespace Edu.Test
{
    public class InfrastructureTest
    {
        [Test]
        public void TestLog()
        {
            LogHelper.Error(this.GetType(), "erw", null);
        }
        [Test]
        public void Entry()
        {
            var id = Guid.NewGuid().ToString().Replace("-", "");
            var s = id.Length;
        }
        [Test]
        public void Test()
        {
            RoleMenuService.Instance.AddRoleMenu(new AddRoleMenuArgs()
            {
                RoleId = 1,
                CreateBy = 1,
                ModifyBy = 1,
                MenuId = 1
            });
        }
    }
}
