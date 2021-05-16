using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using OneFileManager.Core.Model;

namespace OneFileManager.TemplateSelector
{
    class TabViewDataTemplateSelector:DataTemplateSelector
    {
        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            var fe = container as FrameworkElement;
            var tabViewModel = item as TabPage;
            DataTemplate dt = null;
            if (tabViewModel != null && fe != null)
            {
                switch (tabViewModel.Display)
                {
                    case DisplayType.Disk:
                        dt = fe.FindResource("Disk") as DataTemplate;
                        break;
                    case DisplayType.Mtp:
                        break;
                    case DisplayType.Webpage:
                        dt = fe.FindResource("Webpage") as DataTemplate;
                        break;
                    case DisplayType.SearchView:
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
            return dt;
        }
    }
}
