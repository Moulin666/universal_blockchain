using System;
using System.IO;
using System.Net.Sockets;
using System.Text;
using universal_blockchain.Encrypt;

namespace universal_blockchain.Client
{
    class Client_blc
    {
        private TcpClient _client;

        private StreamReader _sReader;
        private StreamWriter _sWriter;

        private Boolean _isConnected;

        public Client_blc(String ipAddress, int portNum)
        {
            _client = new TcpClient();
            _client.Connect(ipAddress, portNum);
            Console.WriteLine("Commected to server: "+ipAddress+":"+portNum.ToString());
           
        }

        public void HandleCommunication()
        {
            _sReader = new StreamReader(_client.GetStream(), Encoding.UTF8);
            _sWriter = new StreamWriter(_client.GetStream(), Encoding.UTF8);

            _isConnected = _client.Connected;
            String sData = null;
            while (_isConnected)
            {
                _isConnected = _client.Connected;
                if (_isConnected == false)
                {
                    break;
                }
                Console.Write("(Client)Введите ссобщение ");
                sData = TextEncryptor.Encrypt(Console.ReadLine(),Settings.node.node_encrypt_key);
                if (sData == "exit")
                {
                    
                    _sWriter.WriteLine(sData);
                    _sWriter.Flush();
                    break;
                }
                // write data and make sure to flush, or the buffer will continue to 
                // grow, and your data might not be sent when you want it, and will
                // only be sent once the buffer is filled.
                _sWriter.WriteLine(sData);
                _sWriter.Flush();

                // if you want to receive anything
                String sDataIncomming = TextEncryptor.Decrypt(_sReader.ReadLine(), Settings.node.node_private_key);
                Console.WriteLine("(Client)Answer from server: "+ sDataIncomming);
            }

            _sReader.Close();
            _sWriter.Close();
            Environment.Exit(-1);
        }
    }
}