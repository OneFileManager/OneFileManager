using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneFileManager.Core.Plugins
{
    /// <summary>
    /// 插件描述信息
    /// </summary>
    public class PluginInfo
    {
        /// <summary>
        /// 插件名称
        /// </summary>
        public string PluginName { get;set;}
        /// <summary>
        /// 作者名称
        /// </summary>
        public string Author { get;set;}
        /// <summary>
        /// 版本号
        /// </summary>
        public string Version { get;set;}
        /// <summary>
        ///  远程文件系统工厂类 完全限定名 可选
        /// </summary>
        public List<string> RemoteVirtualFileSystemDriverFactory { get;set;}
        /// <summary>
        /// 本地文件系统工厂类 完全限定名 可选
        /// </summary>
        public List<string> LocalVirtualFileSystemDriverFactory { get;set;}
        /// <summary>
        /// 注册事件
        /// </summary>
        public Dictionary<string, List<string>> EventTable { get;set;}
        /// <summary>
        /// 注册UI
        /// </summary>
        public List<RegisteredUI> UITable { get;set;}
        /// <summary>
        /// 注册管道
        /// </summary>
        public List<string> Pipeline { get;set;}
        /// <summary>
        /// 过滤器
        /// </summary>
        public List<string> Filters { get;set;}

    }
}
