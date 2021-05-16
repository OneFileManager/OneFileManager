using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using OneFileManager.Core.Model;

namespace OneFileManager.EverythingSDK
{
    public class SearchService
    {
        public List<SearchFile> GetSearchFile(string keyWord)
        {
            List<SearchFile> searchFiles=new List<SearchFile>();
            UInt32 i;

            // set the search
            Everything64.Everything_SetSearchW(keyWord);

            // use our own custom scrollbar... 			
            // Everything_SetMax(listBox1.ClientRectangle.Height / listBox1.ItemHeight);
            // Everything_SetOffset(VerticalScrollBarPosition...);

            // request name and size
            Everything64. Everything_SetRequestFlags(Everything64.EVERYTHING_REQUEST_FILE_NAME | Everything64.EVERYTHING_REQUEST_PATH | Everything64.EVERYTHING_REQUEST_DATE_MODIFIED | Everything64.EVERYTHING_REQUEST_SIZE);

            Everything64.Everything_SetSort(13);

            // execute the query
            Everything64.Everything_QueryW(true);

            // sort by path
            // Everything_SortResultsByPath();

            // clear the old list of results			
          
            // set the window title
            Everything64.Everything_GetNumResults();
        
            StringBuilder stringBuilder=new StringBuilder();
            // loop through the results, adding each result to the listbox.
            for (i = 0; i < Everything64.Everything_GetNumResults(); i++)
            {
                //修改日期
                long date_modified;
                Everything64.Everything_GetResultDateModified(i, out date_modified);
                //文件大小
                long size;
                Everything64.Everything_GetResultSize(i, out size);
                //完整路径
                StringBuilder fullnameBuilder=new StringBuilder(256);
                Everything64.Everything_GetResultFullPathName(i,fullnameBuilder,4096);
                //文件类型
                bool isFile= Everything64.Everything_IsFileResult(i);
                bool isFolder=Everything64.Everything_IsFolderResult(i);
                bool isVolume=Everything64.Everything_IsVolumeResult(i);
                FileType sResultType;
                if (isFile)
                {
                    sResultType = FileType.File;
                }
                else if (isFolder)
                {
                    sResultType = FileType.Directory;
                }else if (isVolume)
                {
                    sResultType = FileType.Volume;
                }else
                {
                    sResultType = FileType.Unknown;
                }
                //扩展名
                var  extension= Everything64.Everything_GetResultExtension(i);
                SearchFile searchFile=new SearchFile()
                {
                    FileName = Marshal.PtrToStringUni(Everything64.Everything_GetResultFileName(i)),
                    FullName = fullnameBuilder.ToString(),
                    FileType = sResultType,
                    Size = size,
                    DateModified = DateTime.FromFileTime(date_modified),
                    Extension = Marshal.PtrToStringUni(extension)
                };
                // add it to the list box				
                searchFiles.Add(searchFile);
            }

            return searchFiles;
        }

        public string GetVersion()
        {
            int v1=   Everything64.Everything_GetMajorVersion();//主版本号
            int v2=   Everything64.Everything_GetMinorVersion();//次版本号
            int v3=   Everything64.Everything_GetRevision();//修订版本号

            return $"{v1}.{v2}.{v3}";
        }
        public int GetBuildNumber()
        {
            int number=   Everything64.Everything_GetBuildNumber();

            return number;
        }
    }
}
