using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace OneFileManager.Common.Utils
{
    public class FolderUtil
    {
        public static class KnownFolder
        {
            public static readonly Guid Downloads = new Guid("374DE290-123F-4565-9164-39C4925E467B");
        }

        [DllImport("shell32.dll", CharSet = CharSet.Unicode)]
        private static extern int SHGetKnownFolderPath([MarshalAs(UnmanagedType.LPStruct)] Guid rfid, uint dwFlags, IntPtr hToken, out string pszPath);

        public static string GetDownloadFoler()
        {
            string downloads;
            SHGetKnownFolderPath(KnownFolder.Downloads, 0, IntPtr.Zero, out downloads);
            return downloads;
        }
    }
}