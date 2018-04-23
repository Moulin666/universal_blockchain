using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace universal_blockchain.Models
{
    class Message
    {
        public int type_message { get; set; }
        public string message { get; set; }
    }
}