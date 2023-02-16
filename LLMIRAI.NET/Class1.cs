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
using LiteLoader.Form;

namespace PluginMain
{
    class ReadJson
    {
        public static string Get_Address()
        {
            StreamReader reader = File.OpenText("plugins/xiangyplugins/config.json");
            JsonTextReader jsonTextReader = new JsonTextReader(reader);
            JObject jsonObject = (JObject)JToken.ReadFrom(jsonTextReader);
            string server = jsonObject["Address"].ToString(); 
            reader.Close();
            return server;
        }
        public static string Get_QQ()
        {
            StreamReader reader = File.OpenText("plugins/xiangyplugins/config.json");
            JsonTextReader jsonTextReader = new JsonTextReader(reader);
            JObject jsonObject = (JObject)JToken.ReadFrom(jsonTextReader);
            string server = jsonObject["QQ"].ToString(); //user ,passwd 类似
            reader.Close();
            return server;
        }
        public static string Get_VerifyKey()
        {
            StreamReader reader = File.OpenText("plugins/xiangyplugins/config.json");
            JsonTextReader jsonTextReader = new JsonTextReader(reader);
            JObject jsonObject = (JObject)JToken.ReadFrom(jsonTextReader);
            string server = jsonObject["VerifyKey"].ToString(); //user ,passwd 类似
            reader.Close();
            return server;
        }
    }
    class Botqq
    {
        
        public MiraiBot bot = new MiraiBot 
        { 
            Address = ReadJson.Get_Address(),
            QQ = ReadJson.Get_QQ(),
            VerifyKey = ReadJson.Get_VerifyKey()
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
            
            if (File.Exists("plugins/xiangyplugins/config.json"))
            {
                Console.WriteLine("好耶有配置文件！");
                Botqq a = new Botqq();
                Task.Run(a.V);
                Console.WriteLine(ReadJson.Get_Address());
                Console.WriteLine(ReadJson.Get_QQ());
                Console.WriteLine(ReadJson.Get_VerifyKey());
            }
            else
            {
                var path = @"plugins/xiangyplugins/config.json";
                var qp = @"plugins/xiangyplugins";
                Console.WriteLine("奶奶滴没有检查到配置文件！");
                Console.WriteLine("开始初始化");
                Console.WriteLine("请输入mirai-htttp配置的adapter默认情况下为localhost:8080");
                string Address1 = Console.ReadLine();
                Console.WriteLine("请输入你BOT的QQ号");
                string QQ1 = Console.ReadLine();
                Console.WriteLine("请输入VerifyKey(详见mirai_http配置文件)");
                string VerifyKey1 = Console.ReadLine();
                if (Directory.Exists(qp))
                {
                    Console.WriteLine("没有xiangyplugins文件夹先建一个");
                }
                else
                {
                    Directory.CreateDirectory(qp);
                }
                data movie = new data
                {
                    Address= Address1,
                    QQ = QQ1,
                    VerifyKey= VerifyKey1
                };
                File.WriteAllText(path, JsonConvert.SerializeObject(movie));
                Botqq a = new Botqq();
                Task.Run(a.V);
                Console.WriteLine(ReadJson.Get_Address());
                Console.WriteLine(ReadJson.Get_QQ());
                Console.WriteLine(ReadJson.Get_VerifyKey());
            }
        }
        public class data
        {
            public string Address { get; set; }
            public string QQ { get; set; }
            public string VerifyKey { get; set; }
        }
        
    }
}
