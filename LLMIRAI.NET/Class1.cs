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
            
            bot.MessageReceived
                .OfType<FriendMessageReceiver>()
                .Subscribe(x =>
                {
                    string plain = x.MessageChain.GetPlainMessage();
                    if (plain.Contains("添加白名单"))
                    {
                        string xboxid = plain.Substring("添加白名单".Length); //("查询玩家");
                        if (xboxid == String.Empty)
                        {
                            x.SendMessageAsync("使用方式：添加白名单[xboxid]");
                            return;
                        }                            
                        else
                        {
                            AllowListManager add = new AllowListManager();
                            add.Add(xboxid);
                            Console.WriteLine(xboxid);
                            x.SendMessageAsync($"已经添加{xboxid}的白名单");
                            Console.WriteLine($"已经添加{xboxid}的白名单");
                            return;
                        }
                    }
                    if (plain.Contains("查看白名单"))
                    {
                        string xboxid = plain.Substring("添加白名单".Length); //("查询玩家");
                        if (xboxid == String.Empty)
                        {
                            AllowListManager witlist = new AllowListManager();
                            x.SendMessageAsync($"ac{witlist.AllowList}");
                            return;
                        }
                    }
                    if (plain.Contains("删除白名单"))
                    {
                        string xboxid = plain.Substring("删除白名单".Length); //("查询玩家");
                        if (xboxid == String.Empty)
                        {
                            x.SendMessageAsync("使用方式：删除白名单[xboxid]");
                            return;
                        }                            
                        else
                        {
                            AllowListManager mov = new AllowListManager();
                            mov.Remove(xboxid);
                            x.SendMessageAsync($"已经删除{xboxid}的白名单");
                            Console.WriteLine($"已经删除{xboxid}的白名单");
                            return;
                        }
                    }
                    
                });
            
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
