using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace OneFileManager.Security.Tests
{
    [TestClass]
    public class Rfc2898Tests
    {
        [TestMethod]
        public void GetSecretkeyTest()
        {
            var pwd = "12345678";
            var key1 = Rfc2898.GetSecretkey(pwd, 256);
            var key2 = Rfc2898.GetSecretkey(pwd, 256);
            var hex1 = HexUtil.ByteArrayToHexString(key1);
            var hex2 = HexUtil.ByteArrayToHexString(key2);
            Console.WriteLine(hex1);
            Console.WriteLine(hex2);
            if (!hex1.Equals(hex2))
            {
                Assert.Fail("密钥生成失败");
            }

        }
    }
}