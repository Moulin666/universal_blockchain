using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace universal_blockchain.Nodes
{
	class Nodes_manager
    {
        static List<Node> nodes = new List<Node>();
        private string path = GetApplicationRoot() + "\\";
        
        public void load()
        {
            if (!File.Exists(path + "nodes.json"))
            {
                using (FileStream fs = File.Create(path + "nodes.json"))
                {
                    fs.Close();
                }
            }
            using (StreamReader file = File.OpenText(path + "nodes.json"))
            {
                string json = file.ReadToEnd();
                var ls = JsonConvert.DeserializeObject<List<Node>>(json);
                nodes = ls;
            }
            
        }

        public void Add(Node node)
        {
            if (nodes == null)
            {
                nodes = new List<Node>();
            }
            nodes.Add(node);
            
            
        }

        public void Save()
        {
            File.WriteAllText(path + "nodes.json", JsonConvert.SerializeObject(nodes));

        }

        public void Remove(string node_name)
        {


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
