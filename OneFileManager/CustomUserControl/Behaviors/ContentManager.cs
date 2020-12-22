using System;
using System.Windows.Controls;
using System.Windows.Data;

namespace OneFileManager.CustomUserControl.Behaviors
{
    public class ContentManager
    {
        private readonly TabControl _tabControl;
        private Decorator _border;

        public ContentManager(System.Windows.Controls.TabControl tabControl, Decorator border)
        {
            _tabControl = tabControl;
            _border = border;
            _tabControl.SelectionChanged += (sender, args) => { UpdateSelectedTab(); };
        }

        public void ReplaceContainer(Decorator newBorder)
        {
            if (Object.ReferenceEquals(_border, newBorder))
            {
                return;
            }

            _border.Child = null; // detach any tab content that old border may hold
            _border = newBorder;
        }

        public void UpdateSelectedTab()
        {
            _border.Child = GetCurrentContent();
        }

        private ContentControl GetCurrentContent()
        {
            object item = _tabControl.SelectedItem;
            if (item == null)
            {
                return null;
            }

            System.Windows.DependencyObject tabItem = _tabControl.ItemContainerGenerator.ContainerFromItem(item);
            if (tabItem == null)
            {
                return null;
            }

            ContentControl cachedContent = TabContent.GetInternalCachedContent(tabItem);
            if (cachedContent == null)
            {
                cachedContent = new ContentControl
                {
                    DataContext = item,
                    ContentTemplate = TabContent.GetTemplate(_tabControl),
                    ContentTemplateSelector = TabContent.GetTemplateSelector(_tabControl)
                };

                cachedContent.SetBinding(ContentControl.ContentProperty, new Binding());
                TabContent.SetInternalCachedContent(tabItem, cachedContent);
            }

            return cachedContent;
        }
    }
}