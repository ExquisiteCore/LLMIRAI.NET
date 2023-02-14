using System;
using LiteLoader;
using LiteLoader.NET;
using LiteLoader.AllowList;
using System.Reactive.Linq;
using Mirai.Net.Sessions;
using LiteLoader.Event;

namespace PluginMain
{
    class Botqq
    {
        public MiraiBot bot = new MiraiBot 
        { 
            Address = "localhost:8080",
            QQ = "3389583001",
            VerifyKey = "123456789"
        };
        public async Task V()
        {
            await bot.LaunchAsync();
            Console.WriteLine("启动异步");
            
            while (true)
            {
                if (Console.ReadLine() == "exit")
                {
                    return;
                }
            }
        }
    }
    public class Plugin
    {
        //插件入口函数
        public static void OnPostInit()
        {
            //提供插件名、插件描述、插件版本等信息
            LLAPI.RegisterPlugin("咸鱼Plugin","一个机器人插件",new LiteLoader.Version(1,0,0));
            Console.WriteLine("咸鱼Plugin启动");
            Botqq a = new Botqq();
            Task.Run(a.V);
        }
    }
}
//AllowListManager add = new AllowListManager();
//Console.WriteLine(add.AllowList);
//add.Add("xiaolong61042");