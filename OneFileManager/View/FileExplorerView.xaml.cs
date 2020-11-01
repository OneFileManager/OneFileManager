using OneFileManager.Model;
using OneFileManager.Utils;
using System.IO;
using System.Windows;
using System.Windows.Controls;

namespace OneFileManager.View
{
    /// <summary>
    /// FileListViewControl.xaml 的交互逻辑
    /// </summary>
    public partial class FileExplorerView : UserControl
    {
        public FileExplorerView()
        {
            InitializeComponent();
        }

        //当前路径
        private readonly string curFilePath = "";

        //当前选中的树节点（目录节点）
        private System.Windows.Forms.TreeNode curSelectedNode = null;

        //是否移动文件
        private readonly bool isMove = false;

        //待复制并粘贴的文件\文件夹的源路径
        private readonly string[] copyFilesSourcePaths = new string[200];

        //用户的历史访问路径的第一个路径节点
        private DoublyLinkedListNode firstPathNode = new DoublyLinkedListNode();

        //当前路径节点
        private DoublyLinkedListNode curPathNode = null;

        //要搜索的文件名
        private readonly string fileName;

        //是否第一次初始化tvwDirectory
        private readonly bool isInitializeTvwDirectory = true;

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            InitDisplay();
        }

        //初始化管理器界面的显示（初始化左窗体的驱动器树形视图和右窗体的文件列表视图）
        private void InitDisplay()
        {
            myComputer.Items.Clear();
            TreeViewItem recentFilesNode = new TreeViewItem() { Header = "最近访问" };
            myComputer.Items.Add(recentFilesNode);
            recentFilesNode.Tag = "最近访问";

            // recentFilesNode.ImageIndex = IconsIndexes.RecentFiles;
            //recentFilesNode.SelectedImageIndex = IconsIndexes.RecentFiles;

            DriveInfo[] driveInfos = DriveInfo.GetDrives();
         
            foreach (DriveInfo info in driveInfos)
            {
                   TreeViewItem driveNode = null;

                switch (info.DriveType)
                {
                    //固定磁盘
                    case DriveType.Fixed:

                        //显示的名称
                        driveNode = new TreeViewItem()
                        {
                            Header = "本地磁盘(" + info.Name.Split('\\')[0] + ")",
                            Tag = info.Name
                        };
                        myComputer.Items.Add(driveNode);
                        //真正的路径

                        // driveNode.ImageIndex = IconsIndexes.FixedDrive;
                        //driveNode.SelectedImageIndex = IconsIndexes.FixedDrive;

                        break;

                    //光驱
                    case DriveType.CDRom:

                        //显示的名称
                        //driveNode = tvwDirectory.Nodes.Add("光驱(" + info.Name.Split('\\')[0] + ")");
                             driveNode = new TreeViewItem()
                        {
                            Header = "光驱(" + info.Name.Split('\\')[0] + ")",
                            Tag = info.Name
                        };
                         myComputer.Items.Add(driveNode);
                        //真正的路径
                        //driveNode.Tag = info.Name;

                        // driveNode.ImageIndex = IconsIndexes.CDRom;
                        // driveNode.SelectedImageIndex = IconsIndexes.CDRom;

                        break;

                    //可移动磁盘
                    case DriveType.Removable:

                        //显示的名称
                        // driveNode = tvwDirectory.Nodes.Add("可移动磁盘(" + info.Name.Split('\\')[0] + ")");
                               driveNode = new TreeViewItem()
                        {
                            Header = "可移动磁盘(" + info.Name.Split('\\')[0] + ")",
                            Tag = info.Name
                        };
                         myComputer.Items.Add(driveNode);
                        //真正的路径
                        //driveNode.Tag = info.Name;

                        //driveNode.ImageIndex = IconsIndexes.RemovableDisk;
                        // driveNode.SelectedImageIndex = IconsIndexes.RemovableDisk;

                        break;
                }
            }
        }

    }
}