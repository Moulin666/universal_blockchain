using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using universal_blockchain.Models;

namespace universal_blockchain.Logic
{
    class App_logic
    {
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

    }
}