using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminApp
{

    public class RDPClient
    {
        public string connectionString { get; set; }
        public string ip { get; set; }

    public RDPClient(string connectionString, string ip)
        {
            this.connectionString = connectionString;
            this.ip = ip;
        }

        public override string ToString()
        {
            return "Ip: " + this.ip;
        }
    }
}
