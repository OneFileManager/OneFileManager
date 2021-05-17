using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneFileManager.Core.AbstractInterface.FileSystem
{
    /// <summary>
    /// 虚拟文件系统驱动器
    /// 要求完成对文件系统（本地硬盘、FTP、SMB、对象储存服务、云盘服务）的抽象
    /// </summary>
    public interface IVirtualFileSystemDriver
    {
        public FileSystemType FileSystemType{get;}
    }

}
