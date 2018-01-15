using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Edu.Infrastructure.Helper;
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
    }
}
