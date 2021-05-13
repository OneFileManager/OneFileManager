using OneFileManager.Common.Utils;
using OneFileManager.Core.Model;
using OneFileManager.MyExtension.ImageExtension;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media.Imaging;

namespace OneFileManager.View.Converter
{
    public class FileIconConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            FileListViewNode fileListViewNode= value as FileListViewNode;
            if (fileListViewNode.FileType==FileType.Directory)
            {

                return fileListViewNode.ImagePath;

            }
            //todo:1处理图标性能问题
            //todo:2处理图标预览效果问题
           　BitmapImage img = ThumbnailHelper.GetInstance().GetBitmapThumbnail(fileListViewNode.FullName).ToBitmapImage();
            return img;
             

        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
