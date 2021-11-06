using OneFileManager.Core.AbstractInterface.FileSystem;
using System;

namespace WindowFileSystemDriver
{

    public class WindowFileSystemDirverFactory : IVirtualFileSystemDriverFactory
    {
        public string HeadAgreement => throw new NotImplementedException();

        string IVirtualFileSystemDriverFactory.GUID => throw new NotImplementedException();

        string IVirtualFileSystemDriverFactory.Name => throw new NotImplementedException();

        public IVirtualFileSystemDriver Instance(string json)
        {
           return new WindowFileSystemDirver( json);
        }

        string IVirtualFileSystemDriverFactory.Login()
        {
            throw new NotImplementedException();
        }
    }
}
