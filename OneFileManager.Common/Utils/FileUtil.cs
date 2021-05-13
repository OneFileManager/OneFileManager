using System;
using System.Drawing;
using System.Runtime.InteropServices;
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
        public static string GetFileSize(long? byteSize)
        {
            if (byteSize == null)
            {
                return "UnKnow";
            }
            const int GB = 1024 * 1024 * 1024;
            const int MB = 1024 * 1024;
            const int KB = 1024;
            if (byteSize / GB >= 1)
            {
                return Math.Round(byteSize.Value / (float)GB, 2) + "GB";
            }
            if (byteSize / MB >= 1)
            {
                return Math.Round(byteSize.Value / (float)MB, 2) + "MB";
            }
            if (byteSize / KB >= 1)
            {
                return Math.Round(byteSize.Value / (float)KB, 2) + "KB";
            }
            return byteSize + "B";
        }

        public static string GetFileSizeGB(long byteSize)
        {
            const int GB = 1024 * 1024 * 1024;
            const int MB = 1024 * 1024;
            const int KB = 1024;
            return Math.Round(byteSize / (float)GB, 2) + "GB";
            ;
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

        public static Icon GetExtractAssociatedIcon(string fileName)
        {
            Icon img = System.Drawing.Icon.ExtractAssociatedIcon(fileName);
            return img;
        }

        [DllImport("shell32.DLL", EntryPoint = "ExtractAssociatedIcon")]
        private static extern int ExtractAssociatedIconA(int hInst, string lpIconPath, ref int lpiIcon); //声明函数

     

        public static System.Drawing.Icon GetFileIcon(string path)
        {
            int RefInt = 0;
            System.IntPtr thisHandle = new IntPtr(ExtractAssociatedIconA(0, path, ref RefInt));
            return System.Drawing.Icon.FromHandle(thisHandle);
        }
    }
}