using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneFileManager.Core.AbstractInterface.FileSystem
{
    /// <summary>
    /// 虚拟文件系统驱动接口工厂
    /// </summary>
    public interface IVirtualFileSystemDriverFactory
    {
        public string GUID{ get;}
        /// <summary>
        ///  返回虚拟文件系统提供器支持的协议头 比如file:///D:/的file
        /// </summary>
        public string HeadAgreement{get;}
        public string Name { get;}
        /// <summary>
        /// 登录或者创建配置文件
        /// </summary>
        /// <returns></returns>
        public string Login();
        /// <summary>
        /// 要求返回一个IVirtualFileSystemDriver的实例
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public IVirtualFileSystemDriver Instance(string token);


    }
}