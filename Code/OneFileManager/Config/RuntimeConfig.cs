using OneFileManager.Core.AbstractInterface.FileSystem;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneFileManager.Config
{
    /// <summary>
    /// 运行时配置
    /// </summary>
    public class RuntimeConfig : INotifyPropertyChanged
    {
        private static RuntimeConfig runtimeConfig = new RuntimeConfig();
        private static Object lockObj=new Object();
        

        public static RuntimeConfig Instance
        {
            get
            {
                lock (lockObj)
                {
                    return runtimeConfig;
                }
                
            }
        }

        private DisplayOptionConfig displayOptionConfig=new DisplayOptionConfig();

        public DisplayOptionConfig DisplayOptionConfig
        {
            get { return displayOptionConfig; }
            set
            {
                this.displayOptionConfig = value;
                if (PropertyChanged != null)
                {
                    this.PropertyChanged.Invoke(this, new PropertyChangedEventArgs("DisplayOptionConfig"));
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}