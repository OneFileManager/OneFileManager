using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneFileManager.Common.Utils
{
    public class FileUtil
    {
        /// <summary>
        /// 将字节单位转换为GB和MB的字符串形式
        /// </summary>
        /// <param name="byteSize"></param>
        /// <returns></returns>
        public string GetFileSize(long byteSize)
        {
            const int GB = 1024 * 1024 * 1024;
            const int MB = 1024 * 1024;
            const int KB = 1024;
            if (byteSize / GB >= 1)
            {
                return Math.Round(byteSize / (float)GB, 2) + "GB";
            }
            if (byteSize / MB >= 1)
            {
                return Math.Round(byteSize / (float)MB, 2) + "MB";
            }
            if (byteSize / KB >= 1)
            {
                return Math.Round(byteSize / (float)KB, 2) + "KB";
            }
            return byteSize + "B";
        }

    }
}
