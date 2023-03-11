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
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.IO;
using System.Text;
using Flurl;
using Flurl.Http;

namespace PluginMain
{ 
    public class initialization
    {
        
        /// <summary>
        /// 检查配置文件
        /// </summary>
        public static void init()
        {
            var Functionpath = @"plugins/xiangyplugins/Function.json";
            var path = @"plugins/xiangyplugins/config.json";
            var qp = @"plugins/xiangyplugins";

            if (Directory.Exists(qp))
            {
                Plugin.cw.Info.WriteLine("配置文件存放目录存在");
            }
            else
            {
                Plugin.cw.Info.WriteLine("没有配置文件存放目录,勉强给你建一个吧");
                Directory.CreateDirectory(qp);
            }


            if (File.Exists(Functionpath))
            {
                Plugin.cw.Info.WriteLine("好耶有功能文件！");
            }
            else
            {
                Function function = new Function
                {
                    identify = true,
                    apply = true,
                    whitelist = true,
                    MOTD = true,
                    Question = "你的入群问题",
                    Answer = "你的入群答案"
                };
                File.WriteAllText(Functionpath, JsonConvert.SerializeObject(function));
            }

            if (File.Exists("plugins/xiangyplugins/config.json"))
            {
                Plugin.cw.Info.WriteLine("好耶有配置文件！");
            }
            else //初始化BOT
            {
                Plugin.cw.Info.WriteLine("奶奶滴没有检查到配置文件！");
                Plugin.cw.Info.WriteLine("开始初始化");
                Plugin.cw.Info.WriteLine("请输入mirai-htttp配置的adapter默认情况下为localhost:8080");
                string address = Console.ReadLine();
                Plugin.cw.Info.WriteLine("请输入你BOT的QQ号");
                string qq = Console.ReadLine();
                Plugin.cw.Info.WriteLine("请输入VerifyKey(详见mirai_http配置文件)");
                string verifykey = Console.ReadLine();
                Plugin.cw.Info.WriteLine("请输入管理员的QQ号");
                string admin = Console.ReadLine();
                Plugin.cw.Info.WriteLine("请输入服务器的群号");
                string group = Console.ReadLine();

                //实例化配置文件参数
                config movie = new config
                {
                    Address = address,
                    QQ = qq,
                    VerifyKey = verifykey,
                    Admin = admin,
                    group = group
                };
                File.WriteAllText(path, JsonConvert.SerializeObject(movie));
            }
        }
    }

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