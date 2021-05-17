using OneFileManager.Core.AbstractInterface.FileSystem;
using System;

namespace WindowFileSystemDriver
{

    public class WindowFileSystemDirverFactory : IVirtualFileSystemDriverFactory
    {
        public string HeadAgreement => throw new NotImplementedException();

        public IVirtualFileSystemDriver Instance(string json)
        {
           return new WindowFileSystemDirver( json);
        }
    }
}
