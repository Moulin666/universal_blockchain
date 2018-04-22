using System;
using System.Diagnostics;
using System.Threading;
using log4net;
using universal_blockchain.Nodes;
using universal_blockchain.Server;
using universal_blockchain.Client;
using System.Net;

namespace universal_blockchain
{
	class Program
    {
		private static ILog log { get; set; }

		static void Main(string[] args)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            Node node = new Node
            {
                node_name = "Test",
                node_region = "MSK",
                node_type = "Master",
                node_encrypt_key = "",
                node_ip = "192.168.1.100"
            };
            Settings.save(node);
            Settings.load();
            log = Configuration.GetLogger();
			log.Info("Application started");
            
            TcpServer tcpServer = new TcpServer(5000,IPAddress.Parse(Settings.node.node_ip));
            Thread ServerThread = new Thread(tcpServer.LoopClients);
            ServerThread.Start();

            Console.WriteLine("Multi-Threaded TCP Server");
            Console.WriteLine("Provide IP:");
            String ip = Console.ReadLine();

            Console.WriteLine("Provide Port:");
            int port = Int32.Parse(Console.ReadLine());

            Client_blc _client = new Client_blc(ip,port);
            Thread ClientThread = new Thread(_client.HandleCommunication);
            ClientThread.Start();

            //Start server non-blocking

            //Regular console code

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
            /*Nodes_manager nodes = new Nodes_manager();
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
            nodes.Save();*/
            sw.Stop();
            Console.WriteLine("Ready "+ (sw.ElapsedMilliseconds/1000.0).ToString()+"s");
            Console.ReadKey();
            
        }

        
    }
}
