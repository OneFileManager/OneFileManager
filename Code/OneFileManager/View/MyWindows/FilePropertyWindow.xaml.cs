using OneFileManager.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace OneFileManager.View
{
    /// <summary>
    /// PropertyWindow.xaml 的交互逻辑
    /// </summary>
    public partial class FilePropertyWindow : Window
    {
        public FileListViewNode FileNode{get;set;}
        public FilePropertyWindow(FileListViewNode fileListViewNode)
        {
            this.FileNode=fileListViewNode;
            InitializeComponent();
            this.DataContext=FileNode;
            
        }
       
    }
}
