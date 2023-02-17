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
using LiteLoader.Logger;

namespace PluginMain
{

    public class Plugin
    {
        public static Logger LLMIRAINET = new("LLMIRAI.NET");
        //插件入口函数 
        public static void OnPostInit()
        {
  
            //提供插件名、插件描述、插件版本等信息
            LLAPI.RegisterPlugin("咸鱼Plugin","一个机器人插件",new LiteLoader.Version(1,0,0));
            LLMIRAINET.Info.WriteLine("咸鱼Plugin启动");
            LLMIRAINET.Info.WriteLine("功能默认全部开启,请在plugins/xiangyplugins里的Function.json控制功能开关");
            
            //文件路径
            var Functionpath = @"plugins/xiangyplugins/Function.json";
            var path = @"plugins/xiangyplugins/config.json";
            var qp = @"plugins/xiangyplugins";
            
            if (Directory.Exists(qp))
            {
                LLMIRAINET.Info.WriteLine("配置文件存放目录存在");
            }
            else
            {
                LLMIRAINET.Info.WriteLine("没有xiangyplugins文件夹先建一个");
                Directory.CreateDirectory(qp);
            }
            
            
            if (File.Exists(Functionpath))
            {
                LLMIRAINET.Info.WriteLine("好耶有功能文件！");
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
                Plugin.LLMIRAINET.Info.WriteLine("好耶有配置文件！");
            }
            else//初始化BOT
            {
                LLMIRAINET.Info.WriteLine("奶奶滴没有检查到配置文件！");
                LLMIRAINET.Info.WriteLine("开始初始化");
                LLMIRAINET.Info.WriteLine("请输入mirai-htttp配置的adapter默认情况下为localhost:8080");
                string address = Console.ReadLine();
                LLMIRAINET.Info.WriteLine("请输入你BOT的QQ号");
                string qq = Console.ReadLine();
                LLMIRAINET.Info.WriteLine("请输入VerifyKey(详见mirai_http配置文件)");
                string verifykey = Console.ReadLine();
                LLMIRAINET.Info.WriteLine("请输入管理员的QQ号");
                string admin = Console.ReadLine();
                LLMIRAINET.Info.WriteLine("请输入服务器的群号");
                string group = Console.ReadLine();
                
                //实例化配置文件参数
                config movie = new config
                {
                    Address = address,
                    QQ = qq,
                    VerifyKey= verifykey,
                    Admin = admin,
                    group = group
                };
                File.WriteAllText(path, JsonConvert.SerializeObject(movie));
            }
            //启动BOT[xiangyplugins]
            LLMIRAINET.Info.WriteLine($"Address:  {ReadJson.Get_Address()}");
            LLMIRAINET.Info.WriteLine($"BOT QQ:   {ReadJson.Get_QQ()}");
            LLMIRAINET.Info.WriteLine($"VerifyKey:{ReadJson.Get_VerifyKey()}");
            Bot bot = new Bot();
            Task.Run(bot.Start);
        }
    }
}
