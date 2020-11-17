using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneFileManager.Model
{
    public class FileListViewNode
    {
        public FileListViewNodeType FileType { get;set;}
        public string ImagePath { get;set;}
        public string Name { get;set;}
        public string FullName { get; set; }
        public string LastWriteTime { get;}
        public string Extension { get;}
        public string Length { get;}

     
        public enum FileListViewNodeType
        {
            File, Directory
        }
        public FileListViewNode(FileInfo fileInfo)
        {
            this.ImagePath="/Resources/UI/Default/File.png";
            this.FileType= FileListViewNodeType.File;
            this.Name=fileInfo.Name;
            this.FullName = fileInfo.FullName;
            this.LastWriteTime = fileInfo.LastWriteTime.ToString("G");
            this.Extension = fileInfo.Extension;
            this.Length = fileInfo.Length+"字节";
        }
        public FileListViewNode(DirectoryInfo directoryInfo)
        {
            this.ImagePath = "/Resources/UI/Default/FolderOrange.png";
            this.FileType = FileListViewNodeType.Directory;
            
            this.Name = directoryInfo.Name;
            this.FullName = directoryInfo.FullName;
            this.LastWriteTime = directoryInfo.LastWriteTime.ToString("G");
            this.Extension = "文件夹";
            this.Length = "未知";
        }
    }
}
