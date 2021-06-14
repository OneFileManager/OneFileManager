using OneFileManager.Core.AbstractInterface.FileSystem;
using OneFileManager.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UpyunDriver;

namespace OneFileManager.Service
{
    /// <summary>
    /// 远程磁盘文件系统管理器
    /// </summary>
   public class RemoteDiskManager
    {
        public  List<IVirtualFileSystemDriverFactory> DriverFactories { get; set; } = new List<IVirtualFileSystemDriverFactory>();
        public  List<RemoteDriveInfo> remoteDriveInfos { get;set;}=new List<RemoteDriveInfo>();
        public  void Init()
        {
            IVirtualFileSystemDriverFactory upyun = new UpyunClientFactory();
            DriverFactories.Add(upyun);
        }
    }
}
