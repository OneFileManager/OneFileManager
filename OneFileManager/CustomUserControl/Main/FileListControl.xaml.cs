using OneFileManager.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace OneFileManager.CustomUserControl.Main
{
    /// <summary>
    /// FileListView.xaml 的交互逻辑
    /// </summary>
    public partial class FileListControl : UserControl
    {
        public FileListControl()
        {
            InitializeComponent();
        }


        List<FileInfo> fileList = new List<FileInfo>();
        public void ShowFilesList(string path)
        {
            var files = Directory.GetFiles(path);
            
            fileList.Clear();
            foreach (var item in files)
            {
                var fileinfo=new FileInfo(item);
                var fileModel=new FileModel(fileinfo.Name);
                fileList.Add(fileinfo);
                Console.WriteLine(  fileinfo.Name);

            }
            lvwFiles.ItemsSource= fileList;

        }

        private void UserControl_Initialized(object sender, EventArgs e)
        {
            ShowFilesList(@"C:\Windows\System32");
        }
    }
}
