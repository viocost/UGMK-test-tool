using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Net;


namespace UMMC_tk_network_test_tool
{
    interface Client_Side_Tests
    {
        PingReply ping_test(IPAddress ip);
        
        
    }
}
