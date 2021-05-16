using OneFileManager.Common.Utils;
using OneFileManager.Core.Model;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace OneFileManager.View.Converter
{
    /// <summary>
    /// 显示剩余可用空间和总空间
    /// </summary>
    public class LocalDriveInfoSpaceStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
          LocalDriveInfo localDriveInfo=value as LocalDriveInfo;
            return $"{FileUtil.GetFileSizeGB(localDriveInfo.AvailableFreeSpace)}可用 共{FileUtil.GetFileSizeGB(localDriveInfo.TotalSize)}";
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
