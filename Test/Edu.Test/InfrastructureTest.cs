﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Edu.Infrastructure.Database;
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
            var token = "c17e82c72ff74c2ea476006012345678";
            var key = token.Substring(0, 24);
            var id = token.Substring(24, 8);
            var s2 = DesEncryptHelper.Decrypt3Des("F+C/TtcK6W4=", key,CipherMode.ECB,id);
        }
        [Test]
        public void DbTest()
        {
           
        }
    }
}
