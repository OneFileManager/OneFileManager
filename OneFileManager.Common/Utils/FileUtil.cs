using System;
using System.Text;
using System.Text.RegularExpressions;

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
        /// <summary>
        /// 检查文件名的合法
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static bool CheckFileName(string fileName)

        {
            if (string.IsNullOrWhiteSpace(fileName))
            {
                return false;

            }
            StringBuilder description = new StringBuilder();

            Boolean opResult = Regex.IsMatch(fileName, @"(?!((^(con)$)|^(con)\\..*|(^(prn)$)|^(prn)\\..*|(^(aux)$)|^(aux)\\..*|(^(nul)$)|^(nul)\\..*|(^(com)[1-9]$)|^(com)[1-9]\\..*|(^(lpt)[1-9]$)|^(lpt)[1-9]\\..*)|^\\s+|.*\\s$)(^[^\\\\\\/\\:\\<\\>\\*\\?\\\\\\""\\\\|]{1,255}$)");

            if (!opResult)
            {
              return false;
            }

       

            return opResult;
        }
    }
}