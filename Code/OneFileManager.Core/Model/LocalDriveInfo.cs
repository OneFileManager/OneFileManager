using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneFileManager.Core.Model
{
    public class LocalDriveInfo
    {
       public string  VolumeLabel{ get;set;}
        public string ImagePath { get; set; }
        public string Name { get; set; }
        public string LocalDriveName{ get;set;}
        /// <summary>
        /// 可用空间
        /// </summary>
        public long AvailableFreeSpace{get;set;}
        /// <summary>
        /// 总共空间
        /// </summary>
        public long TotalSize{get;set;}
        /// <summary>
        /// 空间比例 100%就是全部用完
        /// </summary>
        public int RatioOfSpace{ get;set;}

        public LocalDriveInfo(String Name)
        {
            this.LocalDriveName=$"本地磁盘({Name})";
            this.ImagePath= "/Resources/UI/Default/LocalDrive.png";
            this.AvailableFreeSpace=100;
            this.TotalSize=100;
            this.RatioOfSpace=60;
        }
        public LocalDriveInfo(DriveInfo driveInfo)
        {

            string label=string.IsNullOrEmpty(driveInfo.VolumeLabel)?"本地磁盘":driveInfo.VolumeLabel;

            
            this.Name=driveInfo.Name;
            this.VolumeLabel=label;
            this.LocalDriveName=$"{label}({driveInfo.Name})";
            this.ImagePath= "/Resources/UI/Default/LocalDrive.png";
            this.AvailableFreeSpace=driveInfo.AvailableFreeSpace;
            this.TotalSize=driveInfo.TotalSize;
            this.RatioOfSpace=(int)((((double)driveInfo.TotalSize-(double)driveInfo.AvailableFreeSpace)/(double)driveInfo.TotalSize)*100);
            Console.WriteLine("");
        }
    }
}
