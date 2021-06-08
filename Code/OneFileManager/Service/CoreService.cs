using OneFileManager.Core.AbstractInterface.FileSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UpyunDriver;

namespace OneFileManager.Service
{
  public  class CoreService
    {
        public static List<IVirtualFileSystemDriverFactory> DriverFactories { get; set; }=new List<IVirtualFileSystemDriverFactory>();

        public static  void Init()
        {
            IVirtualFileSystemDriverFactory upyun=new UpyunClientFactory();
            DriverFactories.Add(upyun);


        }
    }
}
