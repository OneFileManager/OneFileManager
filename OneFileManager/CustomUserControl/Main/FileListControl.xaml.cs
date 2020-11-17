using OneFileManager.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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


        ObservableCollection<FileListViewNode> fileList = new ObservableCollection<FileListViewNode>();
        public void ShowFilesList(string path)
        {
         
            //清除视图
            fileList.Clear();
            string[] dirs= Directory.GetDirectories(path);

            foreach (var item in dirs)
            {
                var dirInfo=new DirectoryInfo(item);
                var flvm=new FileListViewNode(dirInfo);
                fileList.Add(flvm);
            }

            var files = Directory.GetFiles(path);
            foreach (var item in files)
            {
                var fileinfo=new FileInfo(item);
                 var flm=new FileListViewNode(fileinfo);
                fileList.Add(flm);
            }
     
        }

        private void UserControl_Initialized(object sender, EventArgs e)
        {
            lvwFiles.ItemsSource = fileList;
            ShowFilesList(@"D:\");
        }

        private void lvwFiles_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var file=lvwFiles.SelectedItem as FileListViewNode;
            switch (file.FileType)
            {
                case FileListViewNode.FileListViewNodeType.File:
                    break;
                case FileListViewNode.FileListViewNodeType.Directory:
                    ShowFilesList(file.FullName);
                    break;
                default:
                    break;
            }

        }
    }
}
