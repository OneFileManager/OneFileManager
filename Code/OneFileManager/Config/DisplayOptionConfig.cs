using OneFileManager.Core.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneFileManager.Config
{
    public class DisplayOptionConfig : INotifyPropertyChanged
    {
        private ViewDisplayType viewDisplayType=ViewDisplayType.List;

        public ViewDisplayType ViewDisplayType
        {
            get { return viewDisplayType; }
            set
            {
                viewDisplayType = value;

                if (PropertyChanged != null)
                {
                    this.PropertyChanged.Invoke(this, new PropertyChangedEventArgs("ViewDisplayType"));
                }
            }
        }

        private bool? displayHiddenObjects=false;

        public bool? DisplayHiddenObjects
        {
            get { return displayHiddenObjects; }
            set
            {
                this.displayHiddenObjects = value;
                if (PropertyChanged != null)
                {
                    this.PropertyChanged.Invoke(this, new PropertyChangedEventArgs("DisplayHiddenObjects"));
                }
            }
        }

        private bool? displayExtension=true;

        public bool? DisplayExtension
        {
            get { return displayExtension; }
            set
            {
                this.displayExtension = value;
                if (PropertyChanged != null)
                {
                    this.PropertyChanged.Invoke(this, new PropertyChangedEventArgs("DisplayExtension"));
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}