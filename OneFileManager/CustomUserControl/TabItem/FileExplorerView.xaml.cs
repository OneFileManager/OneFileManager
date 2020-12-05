using System;
using OneFileManager.CustomUserControl.Main;
using OneFileManager.Core.Model;
using OneFileManager.Utils;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using HandyControl.Data;
using OneFileManager.EverythingSDK;

namespace OneFileManager.View
{
    /// <summary>
    /// FileListViewControl.xaml 的交互逻辑
    /// </summary>
    public partial class FileExplorerView : UserControl
    {
        public static readonly DependencyProperty SourceProperty = DependencyProperty.Register(
            "Source",
            typeof(string),
            typeof(FileExplorerView),
            new PropertyMetadata(@"F:\",ChangeSource)
        );
        public FileExplorerView()
        {
            InitializeComponent();
          
        }
        private static  void ChangeSource(DependencyObject obj, DependencyPropertyChangedEventArgs r)
        {
            FileExplorerView fileView = (FileExplorerView) obj;
            fileView.Source = (string)r.NewValue;
            fileView.fileListControl.Navigate( fileView.Source);
        }
        public string Source
        {
            get => (string)GetValue(SourceProperty);
            set => SetValue(SourceProperty, value);
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
        private void DoGOBack(object sender, System.Windows.RoutedEventArgs e)
        {
            GoBack();
        }
        private void DoGoForward(object sender, System.Windows.RoutedEventArgs e)
        {
           GoForward();

        }

        private void SearchBar_OnSearchStarted(object? sender, FunctionEventArgs<string> e)
        {
            SearchService searchService=new SearchService();
            var files= searchService.GetSearchFile(e.Info);
            if (files.Count>0)
            {
                MessageBox.Show(files[0].FullName);
            }
            MessageBox.Show(searchService.GetVersion()+"");
            MessageBox.Show(searchService.GetBuildNumber()+"");

        }

        public bool CanGoBack()
        {
            return this.fileListControl.CanGoBack;
        }
        public bool CanGoForward()
        {
            return this.fileListControl.CanGoForward;
        }
        public void GoBack()
        {
             this.fileListControl.GoBack( );
        }
        public void GoForward()
        {
             this.fileListControl.GoForward();
        }
        public void Navigate(string path)
        {
             this.fileListControl.Navigate(path);
        }


        private void UserControl_Initialized(object sender, System.EventArgs e)
        { 
            fileListControl.PropertyChanged += FileListControl_PropertyChanged;
        }

        private void FileListControl_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName.Equals("DirectoryPath"))
            {
                if ( this.Source != this.fileListControl.DirectoryPath)
                {
                    this.Source = this.fileListControl.DirectoryPath;
                }
       
            }
            
        }

        private void DiskTreeControl_OnSelectedDiskChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            TreeViewItem treeViewItem = (TreeViewItem) e.NewValue;
           
            this.fileListControl.Navigate(treeViewItem.Tag as string);
        }

        private void DoReLoad(object sender, RoutedEventArgs e)
        {
            this.fileListControl.Refresh(true);
        }

        private void UIElement_OnKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key==Key.Enter)
            {
                string path = pathBox.Text;
                if (Directory.Exists(path))
                {
                    this.fileListControl.Navigate(path );
                }
            }
        }
    }
}