using System;
using System.Diagnostics;
using universal_blockchain.Nodes;
namespace universal_blockchain
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Diagnostics.Stopwatch sw = new Stopwatch();
            sw.Start();
            //Start server non-blocking

            //Regular console code
            Settings settings = new Settings();
            /*Node node = new Node
            {
                node_name = "Test",
                node_region = "MSK",
                node_type = "Master",
                node_encrypt_key = ""
            };
            settings.load();
            Console.WriteLine(settings.node.node_name);
            Console.WriteLine(settings.node.node_region);
            Console.WriteLine(settings.node.node_type);
            Console.WriteLine(settings.node.node_ip);
            Console.WriteLine(settings.node.node_encrypt_key);
            Console.ReadKey();*/
            Nodes_manager nodes = new Nodes_manager();
            nodes.load();
            
            for (int i =0;i<100000;i++)
            {
                Node node1 = new Node();
                node1.node_name = "Name:"+i.ToString();
                node1.node_region = "MSK";
                node1.node_type = "Slave";
                node1.node_ip = i.ToString() + "." + i.ToString() + "." + i.ToString() + "." + i.ToString();
                nodes.Add(node1);

            }
            nodes.Save();
            sw.Stop();
            Console.WriteLine("Ready "+ (sw.ElapsedMilliseconds/1000.0).ToString()+"s");
            Console.ReadKey();
        }
    }
}
