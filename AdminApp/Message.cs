using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminApp
{
    class Message
    {
        public string info;
        public string[] targets;

        public Message(string info, string[] targets)
        {
            this.info = info;
            this.targets = targets;
        }
    }
}
