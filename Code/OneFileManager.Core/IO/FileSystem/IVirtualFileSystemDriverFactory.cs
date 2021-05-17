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
        
        /// <summary>
        ///  返回虚拟文件系统提供器支持的协议头 比如file:///D:/的file
        /// </summary>
        public string HeadAgreement{get;}
        
        public IVirtualFileSystemDriver Instance(string json);


    }
}