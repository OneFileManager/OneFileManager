using OneFileManager.Core.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace OneFileManager.View
{
    /// <summary>
    /// HomeView.xaml 的交互逻辑
    /// </summary>
    public partial class HomeView : UserControl
    {
        public ObservableCollection<FileListViewNode> kuObservableCollection=new ObservableCollection<FileListViewNode>();
        public ObservableCollection<LocalDriveInfo> LocalDriveInfoObservableCollection=new ObservableCollection<LocalDriveInfo>();

        public HomeView()
        {
            InitializeComponent();
             DataContext = this;//指定上下文否则绑定无效
            this.ku.ItemsSource = kuObservableCollection;
            this.localDrive.ItemsSource=LocalDriveInfoObservableCollection;
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            //初始化库
            kuObservableCollection.Add(new FileListViewNode("桌面",@"/Resources/UI/Default/MyComputer.png"));
            kuObservableCollection.Add(new FileListViewNode("下载",@"/Resources/UI/Default/Download.png"));
            kuObservableCollection.Add(new FileListViewNode("文档",@"/Resources/UI/Default/Documents.png"));
            kuObservableCollection.Add(new FileListViewNode("图片",@"/Resources/UI/Default/Picture.png"));
            kuObservableCollection.Add(new FileListViewNode("音乐",@"/Resources/UI/Default/Music.png"));
            kuObservableCollection.Add(new FileListViewNode("视频",@"/Resources/UI/Default/Video.png"));
            //初始化磁盘

            DriveInfo[] driveInfos = DriveInfo.GetDrives();
            foreach (var item in driveInfos)
            {
                LocalDriveInfoObservableCollection.Add(new LocalDriveInfo(item));
            }
          
        }
    }
}
