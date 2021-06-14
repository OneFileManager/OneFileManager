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
        private   static CoreService coreService=new CoreService();
        public  RemoteDiskManager remoteDiskManager=new RemoteDiskManager();

        public static CoreService Instance()
        {

            return coreService;
        }
        public   void Init()
        {
           remoteDiskManager.Init();
        }
    }
}
