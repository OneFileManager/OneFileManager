using System;
using OneFileManager.Core.Model;

namespace OneFileManager.EverythingSDK
{
    public class SearchFile
    {
        public string FileName { get; internal set; }
        public string FullName { get; internal set; }
        public FileType FileType { get; internal set; }
        public long Size { get; internal set; }
        public DateTime DateModified { get; internal set; }
        public  string Extension { get; set; }
        public FileListViewNode ToFileListViewNode()
        {
            string imagePath;
            switch (this.FileType)
            {
                case FileType.File:
                    imagePath = "/Resources/UI/Default/File.png";
                    break;
                case FileType.Directory:
                    imagePath = "/Resources/UI/Default/FolderOrange.png";
                    break;
                default:
                    imagePath = "/Resources/UI/Default/File.png";
                    break;

            }
            FileListViewNode file=new FileListViewNode()
            {
                ImagePath=imagePath,
                FileType= this.FileType,
                Name=this.FileName,
                FullName = this.FullName,
                LastWriteTime = this.DateModified.ToString("G"),
                Extension = this.Extension, 
                Length = this.Size
            };
            return file;
        }
    }
}