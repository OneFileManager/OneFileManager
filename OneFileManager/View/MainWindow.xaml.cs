﻿using OneFileManager.Commands;
using OneFileManager.Core.Model;
using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace OneFileManager.View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        /// <summary>
        /// 页面信息
        /// </summary>
        public ObservableCollection<TabPage> TabViewModelList { get; set; } = new ObservableCollection<TabPage>();

        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;//指定上下文否则绑定无效

            // this.tabControl.ItemsSource = TabViewModelList;
        }

        private void MainWindow_OnInitialized(object? sender, EventArgs e)
        {
            //初始化命令绑定
            InitCommandBindings();
        }

        private void DiskTreeControl_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            TreeViewItem treeViewItem =(TreeViewItem) ((TreeView)e.Source).SelectedItem;

            TabPage tabPage = new TabPage();
            tabPage.Display = DisplayType.Disk;
            tabPage.Path = treeViewItem.Tag as string;
            TabViewModelList.Add(tabPage);

            StackPanel stackPanel=new StackPanel();
        }

        private void InitCommandBindings()
        {
            var openNewTabCommand = new CommandBinding(OpenNewTabCommand.OpenNewTab);
            openNewTabCommand.Executed += OpenNewTabCommand_Executed;
            this.CommandBindings.Add(openNewTabCommand);
        }

        private void OpenNewTabCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            string path = @"C:\";
            if (e.Parameter != null && e.Parameter.GetType() == typeof(FileListViewNode))
            {
                FileListViewNode fileListViewNode = e.Parameter as FileListViewNode;
                if (fileListViewNode != null)
                {
                    switch (fileListViewNode.FileType)
                    {
                        case FileType.File:
                            path = Path.GetDirectoryName(fileListViewNode.FullName);
                            break;

                        case FileType.Directory:
                            path = fileListViewNode.FullName;
                            break;

                        case FileType.Volume:
                            break;

                        case FileType.Mtp:
                            break;

                        case FileType.Unknown:
                            break;

                        default:
                            break;
                    }
                }
            }
            TabViewModelList.Add(new TabPage()
            {
                Display = DisplayType.Disk,
                Path = path,
            });
            tabControl.SelectedIndex = tabControl.Items.Count - 1;
        }

        protected override void OnContentRendered(EventArgs e)
        {
            base.OnContentRendered(e);
        }

        private void Window_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            TabPage tabPage = new TabPage();
            tabPage.Display = DisplayType.Disk;
            tabPage.Path = @"C:\";
            TabViewModelList.Add(tabPage);

            this.tabControl.SelectedIndex = 0;
        }

        //初始化相关“查看”选项
        private void InitViewChecks()
        {
        }

        private void TabControl_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Console.WriteLine("");
        }

    
    }
}