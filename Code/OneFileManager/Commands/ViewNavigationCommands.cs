using System.Windows.Input;

namespace OneFileManager.Commands
{
    /// <summary>
    /// 视图导航命令
    /// </summary>
    public class MyViewNavigationCommands
    {
        static MyViewNavigationCommands()
        {
            var inputOpenNewTab = new InputGestureCollection();
            inputOpenNewTab.Add(new KeyGesture(Key.T, ModifierKeys.Control, "Ctrl+T"));
            OpenNewTab = new RoutedUICommand("OpenNewTab", "OpenNewTab", typeof(MyViewNavigationCommands), inputOpenNewTab);
            
            OpenSpecialFolder=new RoutedUICommand();
            OpenLocalDriver=new RoutedUICommand();

        }
        /// <summary>
        /// 新建标签页
        /// </summary>
        public static RoutedUICommand OpenNewTab { get; }
        /// <summary>
        /// 打开本地驱动器(用户库文件夹)
        /// </summary>
        public static RoutedUICommand OpenSpecialFolder { get; }
        /// <summary>
        /// 打开驱动器
        /// </summary>
        public static RoutedUICommand OpenLocalDriver { get; }
    }
}