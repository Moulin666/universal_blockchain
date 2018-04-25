using System;
using System.Diagnostics;
using System.Net;
using System.Threading;
using log4net;
using universal_blockchain.Encrypt;
using universal_blockchain.Logic;
using universal_blockchain.Server;

namespace universal_blockchain
{
	class Program
    {
		private static ILog log { get; set; }

		static void Main(string[] args)
        {
            log = Configuration.GetLogger();
            Stopwatch sw = new Stopwatch();
            sw.Start();
            App_logic.init();
            log.Info("Init sucess");

            var ecrpt_msg = RSA_encrypt.Encryption(Console.ReadLine());
            Console.WriteLine(ecrpt_msg);
            Console.WriteLine(RSA_encrypt.Decryption(ecrpt_msg));

            sw.Stop();
            Console.WriteLine("Ready "+ (sw.ElapsedMilliseconds/1000.0).ToString()+"s");
            Console.ReadKey();

            
        }

        
    }
}
