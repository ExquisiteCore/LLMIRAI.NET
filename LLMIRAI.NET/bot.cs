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
using Mirai.Net.Data.Events.Concretes.Request;
using Mirai.Net.Sessions.Http.Managers;

namespace PluginMain
{

class Bot
    {
        
        public MiraiBot bot = new MiraiBot 
        { 
            Address = ReadJson.Get_Address(),
            QQ = ReadJson.Get_QQ(),
            VerifyKey = ReadJson.Get_VerifyKey()
        };
        public async Task Start()
        {
            await bot.LaunchAsync();
            Plugin.LLMIRAINET.Info.WriteLine("BOT开启");

            if (ReadJson.Get_whitelist()) //whitelist
            {
                Plugin.LLMIRAINET.Info.WriteLine("管理白名单功能已经开启");// if (x.FriendId == ReadJson.Get_Admin())
                bot.MessageReceived
                .OfType<FriendMessageReceiver>()
                .Subscribe(x =>
                {
                    if (x.FriendId == ReadJson.Get_Admin())
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
                                x.SendMessageAsync($"已经添加{xboxid}的白名单");
                                Plugin.LLMIRAINET.Info.WriteLine($"已经添加{xboxid}的白名单");
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
                                Plugin.LLMIRAINET.Info.WriteLine($"已经删除{xboxid}的白名单");
                                return;
                            }
                        }
                    }
                });
                
                bot.MessageReceived
                .OfType<GroupMessageReceiver>()
                .Subscribe(x =>
                {
                    if (x.Sender.Id == ReadJson.Get_Admin())
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
                                x.SendMessageAsync($"已经添加{xboxid}的白名单");
                                Plugin.LLMIRAINET.Info.WriteLine($"已经添加{xboxid}的白名单");
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
                                Plugin.LLMIRAINET.Info.WriteLine($"已经删除{xboxid}的白名单");
                                return;
                            }
                        }
                    }
                });
            }
            else { Plugin.LLMIRAINET.Info.WriteLine("管理白名单功能已经关闭"); }

            if (ReadJson.Get_MOTD())//MOTD
            {
                Plugin.LLMIRAINET.Info.WriteLine("MOTD功能已经开启");
                bot.MessageReceived
                    .OfType<GroupMessageReceiver>()
                    .Subscribe(x =>
                    {
                        string plain = x.MessageChain.GetPlainMessage();
                        if (plain.Contains("MOTDBE"))
                        {
                            string ip = plain.Substring("MOTDBE".Length);
                            if (ip == String.Empty)
                            {
                                x.SendMessageAsync("使用方式：MOTDBE[ip]");
                                return;
                            }
                            else
                            {
                                var image = new ImageMessage
                                {
                                    Url = $"https://motdbe.blackbe.work/status_img?host={ip}"
                                };
                                x.SendMessageAsync(image); 
                                return;
                            }
                        }
                        if (plain.Contains("MOTDJE"))
                        {
                            string ip = plain.Substring("MOTDJE".Length);
                            if (ip == String.Empty)
                            {
                                x.SendMessageAsync("使用方式：MOTDJE[ip]");
                                return;
                            }
                            else
                            {
                                var image = new ImageMessage
                                {
                                    Url = $"https://motdbe.blackbe.work/status_img/java?host={ip}"
                                };
                                x.SendMessageAsync(image);
                                return;
                            }
                        }
                    });
                    
                bot.MessageReceived
                    .OfType<FriendMessageReceiver>()
                    .Subscribe(x =>
                    {
                        string plain = x.MessageChain.GetPlainMessage();
                        if (plain.Contains("MOTDBE"))
                        {
                            string ip = plain.Substring("MOTDBE".Length);
                            if (ip == String.Empty)
                            {
                                x.SendMessageAsync("使用方式：MOTDBE[ip]");
                                return;
                            }
                            else
                            {
                                var image = new ImageMessage
                                {
                                    Url = $"https://motdbe.blackbe.work/status_img?host={ip}"
                                };
                                x.SendMessageAsync(image); 
                                return;
                            }
                        }
                        if (plain.Contains("MOTDJE"))
                        {
                            string ip = plain.Substring("MOTDJE".Length);
                            if (ip == String.Empty)
                            {
                                x.SendMessageAsync("使用方式：MOTDJE[ip]");
                                return;
                            }
                            else
                            {
                                var image = new ImageMessage
                                {
                                    Url = $"https://motdbe.blackbe.work/status_img/java?host={ip}"
                                };
                                x.SendMessageAsync(image);
                                return;
                            }
                        }
                    });
            }
            else { Plugin.LLMIRAINET.Info.WriteLine("MOTD功能已经关闭"); }

            if (ReadJson.Get_apply())
            {
                Plugin.LLMIRAINET.Info.WriteLine("申请白名单功能已经开启");
                bot.MessageReceived
                    .OfType<GroupMessageReceiver>()
                    .Subscribe(x =>
                    {
                        string plain = x.MessageChain.GetPlainMessage();
                        if (plain.Contains("申请白名单"))
                        {
                            string xboxid = plain.Substring("申请白名单".Length);
                            if (xboxid == String.Empty)
                            {
                                x.SendMessageAsync("使用方式：申请白名单[xboxid]");
                                return;
                            }
                            else
                            {
                                AllowListManager add = new AllowListManager();
                                add.Add(xboxid);
                                x.SendMessageAsync($"已经添加{xboxid}的白名单");
                                Console.WriteLine($"已经添加{xboxid}的白名单");
                                return;
                            }
                        }
                    });
            }
            else { Plugin.LLMIRAINET.Info.WriteLine("申请白名单功能已经关闭"); }

            if (ReadJson.Get_identify())
            {
                Plugin.LLMIRAINET.Info.WriteLine("入群审核功能已经开启");
                bot.EventReceived
                    .OfType<NewMemberRequestedEvent>()
                    .Subscribe(x =>
                    {
                        if (x.GroupId == ReadJson.Get_group())
                        {
                            x.ApproveAsync();
                            Plugin.LLMIRAINET.Info.WriteLine($"{x.FromId}{x.Nick}加群了");
                            bot.MessageReceived
                                .OfType<GroupMessageReceiver>()
                                .Subscribe(a =>
                                {
                                    var messageChain = new MessageChainBuilder()
                                        .At(x.FromId)
                                        .Plain("请回答问题")
                                        .Build();
                                    a.SendMessageAsync(ReadJson.Get_Question());
                                    a.SendMessageAsync("请谨慎回复,答错就踢了你");
                                    if (a.Sender.Id == x.FromId)
                                    {
                                        string Answer;
                                        Answer = a.MessageChain.GetPlainMessage();
                                        Plugin.LLMIRAINET.Info.WriteLine(Answer);
                                        if (Answer == ReadJson.Get_Answer())
                                        {
                                            a.SendMessageAsync($"{x.Nick}欢迎你的加入");
                                            return;
                                        }
                                        else
                                        {
                                            a.SendMessageAsync($"{x.Nick}你可以走了");
                                            GroupManager.KickAsync(x.FromId,x.GroupId);
                                            return;
                                        }
                                        return;
                                    }
                                });
                        }
                    });
            }
            else { Plugin.LLMIRAINET.Info.WriteLine("入群审核功能已经关闭"); }
            
            while (true)
            {
                if (Console.ReadLine() == "exit")
                {
                    return;
                }
            }
        }
    }
}