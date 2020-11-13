using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneFileManager.Model
{
    public class FileModel
    {
        public string Name{get;set; }
        
        
        public  FileModel(string name)
        {
            this.Name=name;
        }
    }
}
