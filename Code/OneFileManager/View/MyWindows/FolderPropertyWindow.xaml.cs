using OneFileManager.Core.Entity;
using OneFileManager.Core.Model;
using OneFileManager.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace OneFileManager.View
{
    /// <summary>
    /// PropertyWindow.xaml 的交互逻辑
    /// </summary>
    public partial class FolderPropertyWindow : Window
    {
        public FileListViewNode FileNode { get; set; }
        private TagService tagService = new TagService();

        public FolderPropertyWindow(FileListViewNode fileListViewNode)
        {
            this.FileNode = fileListViewNode;
            InitializeComponent();
            this.DataContext = FileNode;
        }

        private void TagContainer_Selected(object sender, EventArgs e)
        {
        }

        private void TagContainer_Closing(object sender, EventArgs e)
        {
            var rea = e as RoutedEventArgs;
            HandyControl.Controls.Tag tag = (HandyControl.Controls.Tag)rea.OriginalSource;
            TagEntity tagEntity = tag.DataContext as TagEntity;

            tagService.Remove(tagEntity.Tag, tagEntity.Path);
        }

        private void TagContainer_Closed(object sender, EventArgs e)
        {
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            if (FileNode.Tags.Count >= 3)
            {
                MessageBox.Show("您最多可以为该文件夹指派三个标签");
                return;
            }
            var text = tagText.Text;
            if (string.IsNullOrEmpty(text))
            {
                return;
            }
            if (tagService.IsExist(text, FileNode.FullName))
            {
                return;
            }
            if (tagService.Add(text, FileNode.FullName))
            {
                FileNode.Tags.Add(new TagEntity(text, FileNode.FullName));
            }
        }
    }
}