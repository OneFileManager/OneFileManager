using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneFileManager.Core.Model
{
    public class LocalDriveInfo
    {
        public string ImagePath { get; set; }
        public string Name { get; set; }
        public string LocalDriveName{ get;set;}
        /// <summary>
        /// 可用空间
        /// </summary>
        public long SpaceAvailable{get;set;}
        /// <summary>
        /// 总共空间
        /// </summary>
        public long SpaceTotal{get;set;}
        /// <summary>
        /// 空间比例 100%就是全部用完
        /// </summary>
        public int RatioOfSpace{ get;set;}

        public LocalDriveInfo(String Name)
        {
            this.LocalDriveName=$"本地磁盘({Name})";
            this.ImagePath= "/Resources/UI/Default/LocalDrive.png";
            this.SpaceAvailable=100;
            this.SpaceTotal=100;
            this.RatioOfSpace=60;
        }
    }
}
