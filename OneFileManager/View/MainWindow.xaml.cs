using System;
using System.Collections.ObjectModel;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using HandyControl.Controls;
using HandyControl.Data;
using OneFileManager.Core.Model;
using OneFileManager.EverythingSDK;

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
        public ObservableCollection<TabPage> TabViewModelList { get; set; } 

        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;//指定上下文否则绑定无效

            if (TabViewModelList==null)
            {
                TabViewModelList  = new ObservableCollection<TabPage>();
            }

          

            // this.tabControl.ItemsSource = TabViewModelList;

        }
      
        private void MainWindow_OnInitialized(object? sender, EventArgs e)
        {


        }

        protected override void OnContentRendered(EventArgs e)
        {
            base.OnContentRendered(e);
        }

        private void Window_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            for (int i = 0; i < 10; i++)
            {
                TabPage tabPage=new TabPage();
                tabPage.Display = DisplayType.Disk;
                tabPage.Header ="文件浏览标签"+i;
                tabPage.Path = @"D:\";
                TabViewModelList.Add(tabPage);
            }
            TabPage webModel=new TabPage();
            webModel.Display = DisplayType.Webpage;
            webModel.Header ="网页浏览标签";
            webModel.Path = @"https://www.morenote.top/";
            TabViewModelList.Add(webModel);

            Thread rThread=new Thread(() =>
            {
              
                Thread.Sleep(5000);
                TabViewModelList[0].Path =@"F:\";

            });
            rThread.Start();

     
            this.tabControl.SelectedIndex=0;
        }

        //初始化相关“查看”选项
        private void InitViewChecks()
        {
        }

        private void DoGOBack(object sender, System.Windows.RoutedEventArgs e)
        {
            //fileExplorerView.GoBack();
        }
        private void DoGoForward(object sender, System.Windows.RoutedEventArgs e)
        {
           // fileExplorerView.GoForward();

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
   
    }
}