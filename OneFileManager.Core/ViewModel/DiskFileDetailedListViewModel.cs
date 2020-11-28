using System;
using System.Collections.Generic;
using System.Text;

namespace OneFileManager.ViewModel
{
    class DiskFileDetailedListViewModel
    {   
        private string filepath;
        private string fileName;
        private   DateTime  modifiedDate;
        private string  fileType;
        private long fileSize;

        public string Filepath { get => filepath; set => filepath = value; }
        public string FileName { get => fileName; set => fileName = value; }
        public DateTime ModifiedDate { get => modifiedDate; set => modifiedDate = value; }
        public string FileType { get => fileType; set => fileType = value; }
        public long FileSize { get => fileSize; set => fileSize = value; }
    }
}
