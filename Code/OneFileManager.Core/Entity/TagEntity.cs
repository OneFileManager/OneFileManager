using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneFileManager.Core.Entity
{

    public class TagEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int TagId { get; set; }
        public string Tag { get; set; }
        public string OriginalTag { get; set; }
        public string Path { get; set; }
        public string OriginalPath { get; set; }
      
       public TagEntity()
        {

        }
        public TagEntity(string tag,string path)
        {
            this.Tag=tag.ToLower();
            this.OriginalTag=tag;
            this.Path=path.ToLower();
            this.OriginalPath=path;
        }
    }
}
