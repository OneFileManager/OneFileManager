using OneFileManager.Commands;
using OneFileManager.Core.Model;
using OneFileManager.Service;
using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace OneFileManager.View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
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
            //初始化HomeView
            TagService tagService=new TagService();
            tagService.IsExist("","");
        }

        private void Window_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            

           

            HandyControl.Controls.TabItem tabItem1 = new HandyControl.Controls.TabItem();

            tabItem1.Header = "Home";
            HomeView homeView = new HomeView();
            tabItem1.Content = homeView;

            tabControl.Items.Add(tabItem1);


               HandyControl.Controls.TabItem tabItem2 = new HandyControl.Controls.TabItem();

            tabItem2.Header = "Home";
            EdgeWebView2 edgeWebView2=new EdgeWebView2();

            tabItem2.Content = edgeWebView2;

            tabControl.Items.Add(tabItem2);


           

           
        }

        private void DiskTreeControl_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            TreeViewItem treeViewItem = (TreeViewItem)((TreeView)e.Source).SelectedItem;

            TabPage tabPage = new TabPage();
            tabPage.Display = TabDisplayType.Disk;
            tabPage.Path = treeViewItem.Tag as string;

            StackPanel stackPanel = new StackPanel();
        }

        private void InitCommandBindings()
        {
            var openNewTabCommand = new CommandBinding(MyViewNavigationCommands.OpenNewTab);
            openNewTabCommand.Executed += OpenNewTabCommand_Executed;
            this.CommandBindings.Add(openNewTabCommand);

            CommandBinding openLocalDriverCommandBinding = new CommandBinding(MyViewNavigationCommands.OpenLocalDriver);
            openLocalDriverCommandBinding.Executed += OpenLocalDriverCommandBinding_Executed;
            this.CommandBindings.Add(openLocalDriverCommandBinding);

            CommandBinding openSpecialFolder=new CommandBinding(MyViewNavigationCommands.OpenSpecialFolder);
            openSpecialFolder.Executed += OpenSpecialFolder_Executed;
            this.CommandBindings.Add(openSpecialFolder);
        }

        private void OpenSpecialFolder_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            SpecialFolderInfo specialFolderInfo=e.Parameter as SpecialFolderInfo;
            
            HandyControl.Controls.TabItem tabItem2 = new HandyControl.Controls.TabItem();
            tabItem2.Header = specialFolderInfo.FolderPath;
            FileExplorerView fileExplorerView = new FileExplorerView();
            tabItem2.Content = fileExplorerView;
            fileExplorerView.Navigate(specialFolderInfo.FolderPath);
            tabControl.Items.Add(tabItem2);
            tabControl.SelectedIndex=tabControl.Items.Count-1;//选择最后一个
            
        }

        private void OpenLocalDriverCommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            LocalDriveInfo driveInfo=e.Parameter as LocalDriveInfo;
                
            HandyControl.Controls.TabItem tabItem2 = new HandyControl.Controls.TabItem();
            tabItem2.Header = driveInfo.Name;
            FileExplorerView fileExplorerView = new FileExplorerView();
            tabItem2.Content = fileExplorerView;
            fileExplorerView.Navigate(driveInfo.Name);
            tabControl.Items.Add(tabItem2);
           tabControl.SelectedIndex=tabControl.Items.Count-1;//选择最后一个

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

            tabControl.SelectedIndex = tabControl.Items.Count - 1;
        }

        protected override void OnContentRendered(EventArgs e)
        {
            base.OnContentRendered(e);
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