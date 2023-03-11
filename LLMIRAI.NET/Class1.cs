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

using LiteLoader.Logger;

namespace PluginMain
{

    public class Plugin
    {
        public static Logger cw = new("LLMIRAI.NET");
        //插件入口函数 
        public static void OnPostInit()
        {
  
            //提供插件名、插件描述、插件版本等信息
            LLAPI.RegisterPlugin("咸鱼Plugin","一个机器人插件",new LiteLoader.Version(1,0,0));
            cw.Info.WriteLine("咸鱼Plugin启动");
            cw.Info.WriteLine("功能默认全部开启,请在plugins/xiangyplugins里的Function.json进行功能开关");

            //initialization init = new initialization();
            //检查配置文件
            initialization.init();

            //启动BOT[xiangyplugins]
            cw.Info.WriteLine($"Address:  {ReadJson.Get_Address()}");
            cw.Info.WriteLine($"BOT QQ:   {ReadJson.Get_QQ()}");
            cw.Info.WriteLine($"VerifyKey:{ReadJson.Get_VerifyKey()}");
            Bot bot = new Bot();
            Task.Run(bot.Start);
        }
    }
}
