using OneFileManager.Core.AbstractInterface.FileSystem;
using OneFileManager.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UpYunLibrary;

namespace UpyunDriver
{
    public class UpyunClient : IVirtualFileSystemDriver
    {
        public  FileSystemType FileSystemType => FileSystemType.Remote;
        private UpYun upyun;
        public UpyunClient(string jsonConfig)
        {

        }
        public List<FileListViewNode> ReadDir(string url)
        {
            var list= upyun.ReadDir(url);
            var files=new List<FileListViewNode>();
            foreach (var item in list)
            {
                FileType fileType = item.Filetype.Equals("file") ? FileType.File : FileType.Directory;
                FileListViewNode fileListViewNode = new FileListViewNode()
                {
                    Name = item.Filename,
                    FileType=fileType,
                    Length= item.Size,
                    FullName=url+item.Filename
                };

                files.Add(fileListViewNode);
            }
            return files;
            
        }


    }
}
