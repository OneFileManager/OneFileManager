using Microsoft.VisualStudio.TestTools.UnitTesting;
using OneFileManager.FileSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneFileManager.FileSystem.Tests
{
    [TestClass()]
    public class GetNetSharesTests
    {
        [TestMethod()]
        public void EnumNetSharesTest()
        {
            GetNetShares getNetShares=new GetNetShares();
            var list=   getNetShares.EnumNetShares("");
            foreach (var item in list)
            {
                global::System.Console.WriteLine(item);

            }
        }
    }
}