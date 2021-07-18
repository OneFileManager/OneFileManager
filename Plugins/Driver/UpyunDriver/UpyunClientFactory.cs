using OneFileManager.Core.AbstractInterface.FileSystem;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UpyunDriver.View.Dialog;

namespace UpyunDriver
{
    public class UpyunClientFactory : IVirtualFileSystemDriverFactory
    {
        public string HeadAgreement => "upyun";

        public string GUID => "{1222A68D-267A-4956-8387-51FD32E1E20D}";

        public string Name => "又拍云对象存储";

        public IVirtualFileSystemDriver Instance(string token)
        {
            return new UpyunClient("");
        }

        public string Login()
        {
            LoginDialog loginDialog=new LoginDialog();
            loginDialog.WindowStartupLocation=System.Windows.WindowStartupLocation.CenterScreen;
            var result= loginDialog.ShowDialog();
            if (result!=null&&result.Value)
            {
                string json=loginDialog.loginJson;
                return json;
            }
            else
            {
                return null;
            }
        }
    }
}
