using OneFileManager.Commands;
using OneFileManager.Core.Model;
using OneFileManager.CustomUserControl.Main;
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
        }
        private void Window_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            TabPage tabPage = new TabPage();
            tabPage.Display = DisplayType.Disk;
            tabPage.Path = @"C:\";
       
            this.tabControl.SelectedIndex = 0;


            HandyControl.Controls.TabItem tabItem1=new  HandyControl.Controls.TabItem();
 
            tabItem1.Header="Home";
            HomeView homeView=new HomeView();
            tabItem1.Content=homeView;

            tabControl.Items.Add(tabItem1);

            FileExplorerView fileExplorerView=new FileExplorerView();
            HandyControl.Controls.TabItem tabItem2=new  HandyControl.Controls.TabItem();
                    


         
        }

        private void DiskTreeControl_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            TreeViewItem treeViewItem =(TreeViewItem) ((TreeView)e.Source).SelectedItem;

            TabPage tabPage = new TabPage();
            tabPage.Display = DisplayType.Disk;
            tabPage.Path = treeViewItem.Tag as string;
          

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