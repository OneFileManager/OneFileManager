using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneFileManager.Core.AbstractInterface.FileSystem
{
    /// <summary>
    /// 本地虚拟文件系统接口
    /// </summary>
    public abstract class AbstractLocalVirtualFileSystemDriver : IVirtualFileSystemDriver
    {
        public abstract FileSystemType FileSystemType { get; }
    }
}
