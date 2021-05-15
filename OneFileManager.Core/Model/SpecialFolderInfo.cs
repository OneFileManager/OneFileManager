using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneFileManager.Core.Model
{
    /// <summary>
    /// 特殊文件夹信息(库文件夹)
    /// </summary>
    public class SpecialFolderInfo
    {
        public string ImagePath { get; set; }
        public string Name { get; set; }
        public string FolderPath { get; set; }

        public long? Length { get; set; }

        public SpecialFolderInfo()
        {
        }

        public SpecialFolderInfo(FileInfo fileInfo)
        {
            this.ImagePath = "/Resources/UI/Default/File.png";
            this.Name = fileInfo.Name;
            this.FolderPath = fileInfo.FullName;
            this.Length = fileInfo.Length;
        }

        public SpecialFolderInfo(string name, string imagePath, Environment.SpecialFolder specialFolder)
        {
            this.ImagePath = imagePath;

            this.Name = name;

            this.Length = null;
            this.FolderPath = System.Environment.GetFolderPath(specialFolder);
        }

        public SpecialFolderInfo(string name, string imagePath, string folderPath)
        {
            this.ImagePath = imagePath;

            this.Name = name;

            this.Length = null;
            this.FolderPath = folderPath;
        }

        public SpecialFolderInfo(DirectoryInfo directoryInfo)
        {
            this.ImagePath = "/Resources/UI/Default/FolderOrange.png";
            this.Name = directoryInfo.Name;
            this.FolderPath = directoryInfo.FullName;

            this.Length = null;
        }
    }
}