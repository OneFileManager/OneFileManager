using OneFileManager.Model;
using System;
using System.Collections.Generic;
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

namespace OneFileManager.View
{
    /// <summary>
    /// FileListViewControl.xaml 的交互逻辑
    /// </summary>
    public partial class FileExplorerView:UserControl
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

        }
    }
}
