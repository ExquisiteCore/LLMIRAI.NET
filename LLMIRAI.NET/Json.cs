using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Text.Json.Serialization;

namespace XianYu;

internal struct OriginalData
{
}
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
    public static void remove_xboxid(string a)
    {
        string json = File.ReadAllText("plugins/xiangyplugins/QQ_data.json");
        JArray jarr = new JArray() ;
        jarr = JArray.Parse(json);
        
        IList<JToken> _ILIST = new List<JToken>(); //存储需要删除的项
        JArray _JARRAY = new JArray();

        foreach (var ss in jarr) //查找某个字段与值
        {
            if ((((JObject)ss)["XboxId"]).ToString() == $"{a}")
            {
                _ILIST.Add(ss);
            }
        }
        foreach (var item in _ILIST)  //移除mJObj  有效
        {
            jarr.Remove(item);
        }
        var path = @"plugins/xiangyplugins/QQ_data.json";
        string convertString = Convert.ToString(jarr);//将json装换为string
        File.WriteAllText(path, convertString,System.Text.Encoding.UTF8);//将内容写进jon文件中
    }
    public static bool Get_User(string a)
    {
        string json = File.ReadAllText("plugins/xiangyplugins/QQ_data.json");
        JArray jarr = new JArray() ;
        jarr = JArray.Parse(json);
        foreach (var j in jarr)
        {
            string QQ = j["QQ"].ToString();
            if (QQ == $"{a}")
            {
                return true;
            }
        }
        return false;
    }
    public static void Add_User(string QQ , string xboxid)
    {
        string json = File.ReadAllText("plugins/xiangyplugins/QQ_data.json");
        JArray jarr = new JArray() ;
        jarr = JArray.Parse(json);
        var mark = new JObject { { "QQ", $"{QQ}" },{"XboxId",$"{xboxid}"} };
        jarr.Add(mark);
        var path = @"plugins/xiangyplugins/QQ_data.json";
        string convertString = Convert.ToString(jarr);//将json装换为string
        File.WriteAllText(path, convertString,System.Text.Encoding.UTF8);//将内容写进jon文件中
    }
}