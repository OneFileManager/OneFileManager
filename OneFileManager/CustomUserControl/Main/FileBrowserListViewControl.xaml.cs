using OneFileManager.Core.Model;
using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace OneFileManager.CustomUserControl.Main
{
    /// <summary>
    ///     FileListView.xaml 的交互逻辑
    /// </summary>
    public partial class FileListControl : UserControl, INotifyPropertyChanged
    {
        private ObservableCollection<FileListViewNode> fileList = new ObservableCollection<FileListViewNode>();

        private DoublyLinkedListNode historyNode;
        private DoublyLinkedListNode nowNode;

        public FileListControl()
        {
            InitializeComponent();
        }

        public string DirectoryPath
        {
            get => nowNode == null ? null : nowNode.Path;
            set
            {
                if (value.Equals(nowNode.Path))
                {
                    Refresh(true);
                }
                else
                {
                    Navigate(value);
                    if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs("DirectoryPath"));
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public bool CanGoBack
        {
            get => nowNode.PreNode != null;
        }

        public bool CanGoForward
        {
            get => nowNode.NextNode != null;
        }

        public void GoBack()
        {
            if (CanGoBack)
            {
                nowNode = nowNode.PreNode;
                ShowFilesList(nowNode.Path);
                if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs("DirectoryPath"));
                if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs("CanGoForward"));
                if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs("CanGoBack"));
            }
        }

        public void GoForward()
        {
            if (CanGoForward)
            {
                nowNode = nowNode.NextNode;
                ShowFilesList(nowNode.Path);
            }

            if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs("DirectoryPath"));
            if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs("CanGoForward"));
            if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs("CanGoBack"));
        }

        public void Navigate(string path)
        {
            if (Directory.Exists(path))
            {
                if (nowNode == null)
                {
                    var secondNode = new DoublyLinkedListNode
                    {
                        Path = path,
                        PreNode = null
                    };
                    nowNode = secondNode;
                    ShowFilesList(path);
                }
                else
                {
                    var secondNode = new DoublyLinkedListNode
                    {
                        Path = path,
                        PreNode = nowNode
                    };
                    nowNode.NextNode = secondNode;
                    nowNode = secondNode;
                    ShowFilesList(path);
                }

                if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs("DirectoryPath"));
                if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs("CanGoForward"));
                if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs("CanGoBack"));
            }
        }

        public void Refresh(bool noCache)
        {
            ShowFilesList(nowNode.Path);
        }

        public void ShowFilesList(string path)
        {
            //清除视图
            fileList.Clear();
            var dirs = Directory.GetDirectories(path);

            foreach (var item in dirs)
            {
                var dirInfo = new DirectoryInfo(item);
                var flvm = new FileListViewNode(dirInfo);
                fileList.Add(flvm);
            }

            var files = Directory.GetFiles(path);
            foreach (var item in files)
            {
                var fileinfo = new FileInfo(item);
                var flm = new FileListViewNode(fileinfo);
                fileList.Add(flm);
            }
        }

        private void UserControl_Initialized(object sender, EventArgs e)
        {
            fileListGView.ItemsSource = fileList;
            // ShowFilesList(@"C:\");
            // historyNode = new DoublyLinkedListNode
            // {
            //     Path = @"C:\"
            // };
            // nowNode = historyNode;
        }

        private void lvwFiles_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var file = fileListGView.SelectedItem as FileListViewNode;
            if (file == null) return;

            switch (file.FileType)
            {
                case FileType.File:
                    break;

                case FileType.Directory:
                    Navigate(file.FullName);

                    break;
            }
        }

        private void DoCopyFile(object sender, RoutedEventArgs e)
        {
            if (fileListGView.SelectedItems.Count > 0)
            {
                var files = new StringCollection();

                foreach (var item in fileListGView.SelectedItems)
                {
                    var node = item as FileListViewNode;
                    ;
                    files.Add(node.FullName);
                }

                Clipboard.SetFileDropList(files);
            }
        }

        private void DoPasteFile(object sender, RoutedEventArgs e)
        {
            var files = Clipboard.GetFileDropList();
            if (files.Count > 0)
                foreach (var item in files)
                {
                    var directory = new DirectoryInfo(DirectoryPath);

                    if (File.Exists(item))
                    {
                        var file = new FileInfo(item);
                        var destFileName = directory.FullName + "\\" + file.Name;
                        File.Copy(item, destFileName);
                    }
                    else if (Directory.Exists(item))
                    {
                        var dir = new DirectoryInfo(item);
                        CopyFolder(item, directory.FullName + "\\" + dir.Name);
                    }
                    else
                    {
                        MessageBox.Show("文件不存在");
                    }
                }

            Refresh(true);
        }

        /// <summary>
        /// Copy one folder to a new folder. if destDir is not exists, then create it.
        /// </summary>
        /// <param name="sourceDir"></param>
        /// <param name="destDir"></param>
        private void CopyFolder(string sourceDir, string destDir)
        {
            if (!Directory.Exists(destDir))
            {
                Directory.CreateDirectory(destDir);
            }

            try
            {
                string[] fileList = Directory.GetFiles(sourceDir, "*");
                foreach (string f in fileList)
                {
                    // Remove path from the file name.
                    string fName = f.Substring(sourceDir.Length + 1);

                    // Use the Path.Combine method to safely append the file name to the path.
                    // Will overwrite if the destination file already exists.
                    File.Copy(Path.Combine(sourceDir, fName), Path.Combine(destDir, fName), true);
                }
            }
            catch (DirectoryNotFoundException dirNotFound)
            {
                MessageBox.Show(dirNotFound.Message);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }
        private void DoOpenFileWithExplorer(object sender, RoutedEventArgs e)
        {
            if (fileListGView.SelectedItems.Count > 0)
            {
                foreach (var item in fileListGView.SelectedItems)
                {
                    var node = item as FileListViewNode;
                    System.Diagnostics.Process.Start("explorer.exe", node.FullName);
                }
            }
        }
        private void DoOpenFile(object sender, RoutedEventArgs e)
        {
            if (fileListGView.SelectedItems.Count > 0)
            {
                foreach (var item in fileListGView.SelectedItems)
                {
                    var node = item as FileListViewNode;
                    System.Diagnostics.Process.Start("explorer.exe", node.FullName);
                }
            }
        }

        private void DoOpenFolderWithNewTab(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("此功能未实现");
        }
            private void DoOpenFolderWithNewWindow(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("此功能未实现");
        }
        private void DoSynchronizationAndBackup(object sender, RoutedEventArgs e)
        {
          MessageBox.Show("此功能未实现");
        }

        private void DoOpenWith(object sender, RoutedEventArgs e)
        {
           
            MessageBox.Show("此功能未实现");
        }
        private void DoCut(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("此功能未实现");
        }

        private void DoDelete(object sender, RoutedEventArgs e)
        {
            if (fileListGView.SelectedItems.Count > 0)
            {
                try
                {
                    foreach (var item in fileListGView.SelectedItems)
                    {
                        var node = item as FileListViewNode;
                        File.Delete(node.FullName);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                 Refresh(true);
            }

        }

        private void DoRename(object sender, RoutedEventArgs e)
        {
          MessageBox.Show("此功能未实现");
        }

        private void DoRapidSharing(object sender, RoutedEventArgs e)
        {
         MessageBox.Show("此功能未实现");
        }

        private void DoFileEncryption(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("此功能未实现");
        }
        /// <summary>
        /// 擦除文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DoEraseFile(object sender, RoutedEventArgs e)
        {
          MessageBox.Show("此功能未实现");
        }
        /// <summary>
        /// 批量命名
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DoBatchRenaming(object sender, RoutedEventArgs e)
        {
           MessageBox.Show("此功能未实现");
        }
        /// <summary>
        /// 文件转换
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DoFileConversion(object sender, RoutedEventArgs e)
        {
          MessageBox.Show("此功能未实现");
        }
        /// <summary>
        /// 属性
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DoOpenProperty(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("此功能未实现");
        }
    }
}