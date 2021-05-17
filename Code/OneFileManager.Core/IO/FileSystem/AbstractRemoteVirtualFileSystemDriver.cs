using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneFileManager.Core.AbstractInterface.FileSystem
{
    /// <summary>
    /// 远程虚拟文件系统抽象
    /// </summary>
    public abstract class AbstractRemoteVirtualFileSystemDriver : IVirtualFileSystemDriver
    {
        public abstract FileSystemType FileSystemType { get; }
    }
}
