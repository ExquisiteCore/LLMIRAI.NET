using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace PluginMain;

class ReadJson //读取配置文件
{
    public static bool Get_identify()
    {
        StreamReader reader = File.OpenText("plugins/xiangyplugins/Function.json");
        JsonTextReader jsonTextReader = new JsonTextReader(reader);
        JObject jsonObject = (JObject)JToken.ReadFrom(jsonTextReader);
        string server = jsonObject["identify"].ToString();
        reader.Close();
        return bool.Parse(server);
    }

    public static bool Get_apply()
    {
        StreamReader reader = File.OpenText("plugins/xiangyplugins/Function.json");
        JsonTextReader jsonTextReader = new JsonTextReader(reader);
        JObject jsonObject = (JObject)JToken.ReadFrom(jsonTextReader);
        string server = jsonObject["apply"].ToString();
        reader.Close();
        return bool.Parse(server);
    }
    public static bool Get_MOTD()
    {
        StreamReader reader = File.OpenText("plugins/xiangyplugins/Function.json");
        JsonTextReader jsonTextReader = new JsonTextReader(reader);
        JObject jsonObject = (JObject)JToken.ReadFrom(jsonTextReader);
        string server = jsonObject["MOTD"].ToString();
        reader.Close();
        return bool.Parse(server);
    }
    public static bool Get_whitelist()
    {
        StreamReader reader = File.OpenText("plugins/xiangyplugins/Function.json");
        JsonTextReader jsonTextReader = new JsonTextReader(reader);
        JObject jsonObject = (JObject)JToken.ReadFrom(jsonTextReader);
        string server = jsonObject["whitelist"].ToString();
        reader.Close();
        return bool.Parse(server);
    }

    public static string Get_Admin()
    {
        StreamReader reader = File.OpenText("plugins/xiangyplugins/config.json");
        JsonTextReader jsonTextReader = new JsonTextReader(reader);
        JObject jsonObject = (JObject)JToken.ReadFrom(jsonTextReader);
        string server = jsonObject["Admin"].ToString();
        reader.Close();
        return server;
    }

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
    public static string Get_group()
    {
        StreamReader reader = File.OpenText("plugins/xiangyplugins/config.json");
        JsonTextReader jsonTextReader = new JsonTextReader(reader);
        JObject jsonObject = (JObject)JToken.ReadFrom(jsonTextReader);
        string server = jsonObject["group"].ToString(); //user ,passwd 类似
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
    
    public static string Get_Answer()
    {
        StreamReader reader = File.OpenText("plugins/xiangyplugins/Function.json");
        JsonTextReader jsonTextReader = new JsonTextReader(reader);
        JObject jsonObject = (JObject)JToken.ReadFrom(jsonTextReader);
        string server = jsonObject["Answer"].ToString(); //user ,passwd 类似
        reader.Close();
        return server;
    }
    
    public static string Get_Question()
    {
        StreamReader reader = File.OpenText("plugins/xiangyplugins/Function.json");
        JsonTextReader jsonTextReader = new JsonTextReader(reader);
        JObject jsonObject = (JObject)JToken.ReadFrom(jsonTextReader);
        string server = jsonObject["Question"].ToString(); //user ,passwd 类似
        reader.Close();
        return server;
    }
}