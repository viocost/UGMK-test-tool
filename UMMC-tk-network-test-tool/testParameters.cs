using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;


namespace UMMC_tk_network_test_tool
{
    public class TestParameters
    {
        public List<IPAddress> localhostsR1;
        public List<IPAddress> remotehostsR1;
        public List<IPAddress> DNSservers;
        public String clientIP;
        public TestParameters() { 
            localhostsR1 = new List<IPAddress>();
            remotehostsR1 = new List<IPAddress>();
            DNSservers = new List<IPAddress>();
        }

        internal void parseJsonData(string testParams)
        {
           
            char[] delimiters = {',', ':' };
            char[] removeCrap = {'[', ']','"', '/', ':', '{', '}', '\\', '\r', '\n'};
            String[] parameters = testParams.Split(delimiters);
            List<String> trimmedParams = new List<String>();

            foreach( String s in parameters){
                
                trimmedParams.Add(s.Trim(removeCrap));
                           
            }

          
            int paramFlag = 0;
            for (int i = 0; i < trimmedParams.Count(); i++) {
                if(trimmedParams[i].Equals("clientIP")) {
                    paramFlag = 0;
                }
                else if (trimmedParams[i].Equals("DNS"))
                {
                    paramFlag = 1;
                }
                else if (trimmedParams[i].Equals("remotes"))
                {
                    paramFlag = 2;
                }
                else if (trimmedParams[i].Equals("locals"))
                {
                    paramFlag = 3;
                }

                else {
                    switch (paramFlag) { 
                        case 0:
                            this.clientIP = (trimmedParams[i]);
                            break;
                        case 1:
                            IPAddress ip = IPAddress.Parse (trimmedParams[i]);
                            this.DNSservers.Add(ip);
                            break;
                        case 2:
                            IPAddress ip1 = IPAddress.Parse(trimmedParams[i]);
                            this.remotehostsR1.Add(ip1);

                            break;
                        case 3:
                            IPAddress ip2 = IPAddress.Parse(trimmedParams[i]);
                            this.localhostsR1.Add(ip2);
                            break;
                    }
                
                }
            }



        }
            
  
    }
}
