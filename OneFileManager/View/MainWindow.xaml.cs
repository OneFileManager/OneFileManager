using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using HandyControl.Controls;
using HandyControl.Data;
using OneFileManager.Commands;
using OneFileManager.Core.Model;
using OneFileManager.EverythingSDK;
using TabItem = HandyControl.Controls.TabItem;

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

        private void InitCommandBindings()
        {
            var openNewTabCommand=new CommandBinding(CustomCommands.OpenNewTab);
            openNewTabCommand.Executed += OpenNewTabCommand_Executed;
            this.CommandBindings.Add(openNewTabCommand);

        }

        private void OpenNewTabCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            TabViewModelList.Add(new TabPage()
            {
                Display = DisplayType.Disk,
                Path = @"C:\",
            });
            tabControl.SelectedIndex=tabControl.Items.Count-1;
        }

        protected override void OnContentRendered(EventArgs e)
        {
            base.OnContentRendered(e);
        }

        private void Window_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            TabPage tabPage=new TabPage();
            tabPage.Display = DisplayType.Disk;
            tabPage.Path = @"D:\";
            TabViewModelList.Add(tabPage);

    

     
            this.tabControl.SelectedIndex=0;
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