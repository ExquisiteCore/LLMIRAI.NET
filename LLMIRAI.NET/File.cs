using System;
using LiteLoader;
using LiteLoader.NET;
using LiteLoader.AllowList;
using System.Reactive.Linq;
using Mirai.Net.Sessions;
using LiteLoader.Event;
using Mirai.Net.Data.Messages.Concretes;
using Mirai.Net.Data.Messages.Receivers;
using Mirai.Net.Utils.Scaffolds;

using System.IO;
using System.Text;
using Flurl;
using Flurl.Http;

namespace PluginMain
{
    

   
    public class config //配置文件参数
    { 
        public string Address { get; set; } 
        public string QQ { get; set; } 
        public string VerifyKey { get; set; } 
        public string Admin { get; set; }
        public string group { get; set; }
    }

    public class Function //配置文件参数
    {
        public bool identify { get; set; }
        public bool apply { get; set; }
        public bool whitelist { get; set; }
        public bool MOTD { get; set; }
        public string Question { get; set; }
        public string Answer { get; set; }
    }
}