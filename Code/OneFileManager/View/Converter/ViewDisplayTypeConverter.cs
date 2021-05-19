using OneFileManager.Config;
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
    public class ViewDisplayTypeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            ViewDisplayType  viewDisplay=(ViewDisplayType)value  ;
            return (int) viewDisplay;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int selectIndex=(int)value;
            ViewDisplayType viewDisplay=(ViewDisplayType)selectIndex;
            return viewDisplay;

        }
    }
}
