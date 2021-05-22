using Microsoft.EntityFrameworkCore;
using OneFileManager.Core.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneFileManager.DB
{
public class SQLLite3Context : DbContext
    {

        public DbSet<TagEntity> TagTable { get; set; }
       
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            var file = Path.Combine("OneFileManager.db");
                file = Path.GetFullPath(file);
             options.UseSqlite($"Data Source={file}");
        }
            
    }

   
}
