using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace OneFileManager.ViewModel
{
    internal class DiskTreeNodeItemViewModel : INotifyPropertyChanged
    {
        private string icon;
        public string Icon
        {
            get => icon; set
            {
                icon = value;

                if (PropertyChanged != null)
                {
                    PropertyChanged.Invoke(this, new PropertyChangedEventArgs("Icon"));

                }
            }
        }
        public string EditIcon { get; set; }
        public string DisplayName { get; set; }
        public string Name { get; set; }

        public List<DiskTreeNodeItemViewModel> Children { get; set; }
        public DiskTreeNodeItemViewModel()
        {
            Children = new List<DiskTreeNodeItemViewModel>();
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
