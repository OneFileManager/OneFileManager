using System.ComponentModel;
using System.IO;


namespace OneFileManager.Core.Model
{
    public class TabPage : INotifyPropertyChanged
    {
        private string path;
        private string header;
        public TabDisplayType Display { get; set; }

        
        public string Path
        {
            get => path;
            set
            {
                path = value;
               
                DirectoryInfo directoryInfo=new DirectoryInfo(Path);
                Header = directoryInfo.Name;
                if (PropertyChanged != null) PropertyChanged.Invoke(this, new PropertyChangedEventArgs("Path"));
            }
        }

        public string Header
        {
            get
            {
                
                return header;
            }
            set
            {
                header = value;
                if (PropertyChanged != null) PropertyChanged.Invoke(this, new PropertyChangedEventArgs("Header"));
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        public override string ToString()
        {
            return Path;
        }
    }
}