using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneFileManager.Core.Model
{
    public class RemoteDriveInfo
    {

        /// <summary>
        /// 卷标
        /// </summary>
       public string  VolumeLabel{ get;set;}
        /// <summary>
        /// 界面显示图标
        /// </summary>
        public string ImagePath { get; set; }
        /// <summary>
        /// 磁盘名称 严谨意义
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 远程磁盘名称 随意命名
        /// </summary>
        public string RemoteDriveName{ get;set;}
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
        /// <summary>
        /// 登录认证凭证
        /// </summary>
        public string Token { get;set;}
        /// <summary>
        /// 文件系统驱动工厂类的GUID
        /// </summary>
        public string FileSystemDriverFactoryGUID { get;set;}
        /// <summary>
        /// 文件系统驱动类的GUID
        /// </summary>
        public string FileSystemDriverGUID { get;set;}
        /// <summary>
        /// 协议头
        /// </summary>
        public string HeadAgreement { get;set;}
        /// <summary>
        /// 主机地址
        /// </summary>
        public string hostAddress { get;set;}


        public RemoteDriveInfo(String Name)
        {
            this.RemoteDriveName = $"本地磁盘({Name})";
            this.ImagePath= "/Resources/UI/Default/LocalDrive.png";
            this.AvailableFreeSpace=100;
            this.TotalSize=100;
            this.RatioOfSpace=60;
        }
        public RemoteDriveInfo(DriveInfo driveInfo)
        {

            string label=string.IsNullOrEmpty(driveInfo.VolumeLabel)?"本地磁盘":driveInfo.VolumeLabel;

            this.Name=driveInfo.Name;
            this.VolumeLabel=label;
            this.RemoteDriveName = $"{label}({driveInfo.Name})";
            this.ImagePath= "/Resources/UI/Default/LocalDrive.png";
            this.AvailableFreeSpace=driveInfo.AvailableFreeSpace;
            this.TotalSize=driveInfo.TotalSize;
            this.RatioOfSpace=(int)((((double)driveInfo.TotalSize-(double)driveInfo.AvailableFreeSpace)/(double)driveInfo.TotalSize)*100);
            Console.WriteLine("");
        }
    }
}
