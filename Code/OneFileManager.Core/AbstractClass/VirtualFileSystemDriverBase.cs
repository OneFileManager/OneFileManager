using OneFileManager.Core.AbstractInterface.FileSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneFileManager.Core.AbstractClass
{
    /// <summary>
    /// 虚拟文件系统驱动器基类
    /// </summary>
    public abstract class VirtualFileSystemDriverBase : IVirtualFileSystemDriver
    {
        public abstract FileSystemType FileSystemType { get; }
    }
}
