using Newtonsoft.Json;
using System.IO;
using universal_blockchain.Nodes;
using System.Text.RegularExpressions;
using System;

namespace universal_blockchain
{
	public class Settings
    {
        public static Node node = new Node();
        static string path = GetApplicationRoot() + "";
    
        public static void save()
        {
            using (StreamWriter file = File.CreateText(path+"settings.json"))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(file, node);
            }

        }

        public static void load()
        {
            if (!File.Exists(path + "settings.json"))
            {
                using (FileStream fs = File.Create(path + "nodes.json"))
                {
                    fs.Close();
                }
                Console.WriteLine("Введите имя ноды");
                node.node_name = Console.ReadLine();

                Console.WriteLine("Введите ip");
                node.node_ip = Console.ReadLine();

                Console.WriteLine("Введите регион");
                node.node_region = Console.ReadLine();

                Console.WriteLine("Введите тип");
                node.node_type = Console.ReadLine();

                node.node_is_online = "true";
                save();

            }
            else
            {
                using (StreamReader file = File.OpenText(path + "settings.json"))
                {
                    JsonSerializer serializer = new JsonSerializer();
                    node = (Node)serializer.Deserialize(file, typeof(Node));

                }
            }
            
        }

        public static string GetApplicationRoot()
        {
            var exePath = Path.GetDirectoryName(System.Reflection
                              .Assembly.GetExecutingAssembly().CodeBase);
            Regex appPathMatcher = new Regex(@"(?<!fil)[A-Za-z]:\\+[\S\s]*?(?=\\+bin)");
            var appRoot = appPathMatcher.Match(exePath).Value;
            return appRoot;
        }
    }


}
