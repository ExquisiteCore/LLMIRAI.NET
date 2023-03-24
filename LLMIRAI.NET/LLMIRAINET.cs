using System;
using LiteLoader;
using LiteLoader.NET;
using System.IO;
using System.Text;

using Newtonsoft.Json; 
using Newtonsoft.Json.Linq;


using LiteLoader.DynamicCommand;
using LiteLoader.Logger;
using System.Collections.Generic;
using System.Data;
using System.Net.Mime;
using Version = System.Version;


namespace XianYu
{
    //使用PluginMainAttribute提供插件名称
    [PluginMain("LLMIRAINET")]
    public class LLMIRAINET : IPluginInitializer
    {
        public static Logger cw = new("LLMIRAI.NET");
        //提供插件描述
        public string Introduction => "基于Liteloader.NET的QQBot";

        //提供插件额外信息
        public Dictionary<string, string> MetaData => new()
        {
            {"Something", "..."},
            {"foo", "bar"}
        };

        //提供插件版本信息
        public Version Version => new(2, 3, 3);
        
        public void OnInitialize()
        {
            LLAPI.RegisterPlugin("咸鱼Plugin", "一个机器人插件", new LiteLoader.Version(1, 0, 0));
            cw.Info.WriteLine("咸鱼Plugin启动");
            cw.Info.WriteLine("功能默认全部开启,请在plugins/xiangyplugins里的Function.json进行功能开关");

            //initialization init = new initialization();
            //检查配置文件
            initialization.init();

            //启动BOT[xiangyplugins]
            //bool t = Get_identify();
            //cw.Info.WriteLine(t);
            cw.Info.WriteLine("**************************");
            cw.Info.WriteLine($"Address:  {ReadJson.Get_Address()}");
            cw.Info.WriteLine($"BOT QQ:   {ReadJson.Get_QQ()}");
            cw.Info.WriteLine($"VerifyKey:{ReadJson.Get_VerifyKey()}");
            cw.Info.WriteLine("**************************");
            Bot bot = new Bot();
            Task.Run(bot.Start);
        }
        
        

    }
}