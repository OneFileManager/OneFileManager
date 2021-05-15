using OneFileManager.Common.Utils;
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
        public ObservableCollection<SpecialFolderInfo> kuObservableCollection=new ObservableCollection<SpecialFolderInfo>();
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
           
          
        }

        private void UserControl_Initialized(object sender, EventArgs e)
        {
             //初始化库
            kuObservableCollection.Add(new SpecialFolderInfo("桌面",@"/Resources/UI/Default/MyComputer.png",Environment.SpecialFolder.DesktopDirectory));
            kuObservableCollection.Add(new SpecialFolderInfo("下载",@"/Resources/UI/Default/Download.png",FolderUtil.GetDownloadFoler()));
            kuObservableCollection.Add(new SpecialFolderInfo("文档",@"/Resources/UI/Default/Documents.png",Environment.SpecialFolder.MyDocuments));
            kuObservableCollection.Add(new SpecialFolderInfo("图片",@"/Resources/UI/Default/Picture.png",Environment.SpecialFolder.MyPictures));
            kuObservableCollection.Add(new SpecialFolderInfo("音乐",@"/Resources/UI/Default/Music.png",Environment.SpecialFolder.MyMusic));
            kuObservableCollection.Add(new SpecialFolderInfo("视频",@"/Resources/UI/Default/Video.png",Environment.SpecialFolder.MyVideos));
            //初始化磁盘

            DriveInfo[] driveInfos = DriveInfo.GetDrives();
            foreach (var item in driveInfos)
            {
                LocalDriveInfoObservableCollection.Add(new LocalDriveInfo(item));
            }
          
        }

       
    }
}
