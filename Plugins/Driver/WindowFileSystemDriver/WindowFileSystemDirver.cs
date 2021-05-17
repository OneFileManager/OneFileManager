using OneFileManager.Core.AbstractInterface.FileSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowFileSystemDriver
{
    public class WindowFileSystemDirver : AbstractLocalVirtualFileSystemDriver
    {
        
        public override FileSystemType FileSystemType =>  FileSystemType.Local;

        public WindowFileSystemDirver(string json)
        {

        }

    }
}
