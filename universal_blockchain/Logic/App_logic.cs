using log4net;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using universal_blockchain.Encrypt;
using universal_blockchain.Models;
using universal_blockchain.Server;

namespace universal_blockchain.Logic
{
    class App_logic
    {
        private static ILog log { get; set; }

        public void Proccesing(string encoming_msg)
        {
            var message = JsonConvert.DeserializeObject<Message>(encoming_msg);
            Response(message);
        }

        public string Response(Message message)
        {
            var answer = "Sucess";
            return answer;
        }

        public static void init()
        {
            log.Info("Application started");
            log = Configuration.GetLogger();
            Settings.load();
            log.Info("Settings load");
            RSA_encrypt.initialize();
            log.Info("Encrypt initializate");
            Console.WriteLine("Application started");

            try
            {
                TcpServer tcpServer = new TcpServer(5000, IPAddress.Parse(Settings.node.node_ip));
                Thread ServerThread = new Thread(tcpServer.LoopClients);
                ServerThread.Start();
            }
            catch (Exception e)
            {
                log.Fatal(e.ToString());
            }
        }
    }
}

/*
            Settings.load();
            log.Info("Settings load");
            log.Info("Application started");
            RSA_encrypt.initialize();
            log.Info("Encrypt initializate");
            Console.WriteLine("Application started");

            /*TcpServer tcpServer = new TcpServer(5000,IPAddress.Parse(Settings.node.node_ip));
            Thread ServerThread = new Thread(tcpServer.LoopClients);
            ServerThread.Start();
            log.Info("Server started");

            var ecrpt_msg = RSA_encrypt.Encryption(Console.ReadLine());
                Console.WriteLine(ecrpt_msg);
            Console.WriteLine(RSA_encrypt.Decryption(ecrpt_msg));
            /*TcpServer tcpServer = new TcpServer(5000,IPAddress.Parse(Settings.node.node_ip));
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
    