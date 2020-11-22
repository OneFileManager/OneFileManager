using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using OneFileManager.Model;

namespace OneFileManager.CustomUserControl.Main
{
    /// <summary>
    ///     FileListView.xaml 的交互逻辑
    /// </summary>
    public partial class FileListControl : UserControl, INotifyPropertyChanged
    {
        private readonly ObservableCollection<FileListViewNode> fileList = new ObservableCollection<FileListViewNode>();

        private DoublyLinkedListNode historyNode;
        private DoublyLinkedListNode nowNode;


        public FileListControl()
        {
            InitializeComponent();
        }

        public string DirectoryPath
        {
            get => nowNode.Path;
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

        public bool CanGoBack()
        {
            return nowNode.PreNode != null;
        }

        public bool CanGoForward()
        {
            return nowNode.NextNode != null;
        }

        public void GoBack()
        {
            if (CanGoBack())
            {
                nowNode = nowNode.PreNode;
                ShowFilesList(nowNode.Path);
                if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs("DirectoryPath"));
            }
        }

        public void GoForward()
        {
            if (CanGoForward())
            {
                nowNode = nowNode.NextNode;
                ShowFilesList(nowNode.Path);
            }

            if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs("DirectoryPath"));
        }

        public void Navigate(string path)
        {
            if (Directory.Exists(path))
            {
                var secondNode = new DoublyLinkedListNode();
                secondNode.Path = path;
                secondNode.PreNode = nowNode;
                nowNode.NextNode = secondNode;
                nowNode = secondNode;
                ShowFilesList(path);
                if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs("DirectoryPath"));
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
            lvwFiles.ItemsSource = fileList;
            ShowFilesList(@"C:\");
            historyNode = new DoublyLinkedListNode();
            historyNode.Path = @"C:\";
            nowNode = historyNode;
        }

        private void lvwFiles_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var file = lvwFiles.SelectedItem as FileListViewNode;
            if (file == null) return;
            switch (file.FileType)
            {
                case FileListViewNode.FileListViewNodeType.File:
                    break;

                case FileListViewNode.FileListViewNodeType.Directory:
                    Navigate(file.FullName);

                    break;
            }
        }

        private void DoCopyFile(object sender, RoutedEventArgs e)
        {
            
        }
    }
}