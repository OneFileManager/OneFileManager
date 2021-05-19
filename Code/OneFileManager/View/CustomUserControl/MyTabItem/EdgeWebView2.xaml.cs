using HandyControl.Data;
using OneFileManager.Core.Model;
using OneFileManager.EverythingSDK;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace OneFileManager.View
{
    /// <summary>
    /// FileListViewControl.xaml 的交互逻辑
    /// </summary>
    public partial class EdgeWebView2 : UserControl
    {
        public EdgeWebView2()
        {
            InitializeComponent();
        }

        private static void ChangeSource(DependencyObject obj, DependencyPropertyChangedEventArgs r)
        {
            FileExplorerView fileView = (FileExplorerView)obj;
            if (fileView.fileListControl.DirectoryPath == null || fileView.fileListControl.DirectoryPath != (string)r.NewValue)
            {
                fileView.Source = (string)r.NewValue;
                fileView.fileListControl.Navigate(fileView.Source);
            }
        }

        public string Source
        {
            get { return this.myWebBrowser.Source.ToString(); }
            set { this.myWebBrowser.CoreWebView2.Navigate(value); }
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
            SearchService searchService = new SearchService();
            var files = searchService.GetSearchFile(e.Info);
            if (files.Count > 0)
            {
                MessageBox.Show(files[0].FullName);
            }
            MessageBox.Show(searchService.GetVersion() + "");
            MessageBox.Show(searchService.GetBuildNumber() + "");
        }

        public bool CanGoBack()
        {

            return this.myWebBrowser.CanGoBack;
        }

        public bool CanGoForward()
        {
            return this.myWebBrowser.CanGoForward;
        }

        public void GoBack()
        {
            this.myWebBrowser.GoBack();
        }

        public void GoForward()
        {
            this.myWebBrowser.GoForward();
        }

        public void Navigate(string path)
        {
            this.myWebBrowser.CoreWebView2.Navigate(path);
        }

        private void UserControl_Initialized(object sender, System.EventArgs e)
        {
        }

        private void DoReLoad(object sender, RoutedEventArgs e)
        {
            this.myWebBrowser.CoreWebView2.Reload();
        }

        private void UIElement_OnKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                string path = pathBox.Text;
                if (Directory.Exists(path))
                {
                    this.myWebBrowser.CoreWebView2.Navigate(path);
                }
            }
        }

        /// <summary>
        /// 鼠标拖放时间
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UserControl_Drop(object sender, DragEventArgs e)
        {
            var strs = (string[])e.Data.GetData(DataFormats.FileDrop);

            MessageBox.Show("");
        }

        /// <summary>
        /// 鼠标拖放进入
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UserControl_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effects = DragDropEffects.Copy;
            }
            else
            {
                e.Effects = DragDropEffects.None;
            }
        }
    }
}