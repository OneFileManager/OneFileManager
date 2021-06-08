using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneFileManager.Core.AbstractInterface.FileSystem
{
    /// <summary>
    /// 虚拟文件系统提供的特性
    /// </summary>
    public enum SupportFeature
    {
        DisplayIcon,DisplayName,DisplayFileSize,DisplayCreatTime,DisplayMD5,DisplaySHA1,DisplaySHA256,DisplaySHA512
    }
}
