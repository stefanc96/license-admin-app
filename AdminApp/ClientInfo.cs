using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminApp
{
    class ClientInfo
    {
        string ip;
        string PK;
        public ClientInfo(string ip, string PK)
        {
            this.ip = ip;
            this.PK = PK;
        }
    }
 
}
