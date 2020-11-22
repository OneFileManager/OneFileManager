using System;

namespace OneFileManager
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        protected override void OnContentRendered(EventArgs e)
        {
            base.OnContentRendered(e);
        }

        private void Window_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
        }

        //初始化相关“查看”选项
        private void InitViewChecks()
        {
        }

        private void DoGOBack(object sender, System.Windows.RoutedEventArgs e)
        {
            fileExplorerView.GoBack();
        }
        private void DoGoForward(object sender, System.Windows.RoutedEventArgs e)
        {
            fileExplorerView.GoForward();

        }
      
    }
}