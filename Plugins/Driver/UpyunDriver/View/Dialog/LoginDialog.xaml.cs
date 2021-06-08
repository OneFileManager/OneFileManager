using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using UpyunDriver.Model;

namespace UpyunDriver.View.Dialog
{
    /// <summary>
    /// LoginDialog.xaml 的交互逻辑
    /// </summary>
    public partial class LoginDialog : Window
    {

        public LoginInfo LoginInfo { get;set;}
        public string loginJson { get;set;}
        public LoginDialog()
        {
            InitializeComponent();
        }

        private void OkClick(object sender, RoutedEventArgs e)
        {

            this.LoginInfo = new LoginInfo()
            {
                BucketName=this.UpyunBucketBox.Text,
                UserName=this.UpyunUsernameBox.Text,
                Password=this.UpyunSecretBox.Password
            };
            this.loginJson=System.Text.Json.JsonSerializer.Serialize(this.LoginInfo);

            this.DialogResult=true;
            this.Close();
        }

        private void CancelClick(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
            this.Close();

        }
    }
}
