using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Windows.Forms;

namespace UMMC_tk_network_test_tool
{
    class Client
    {
        private
            IPAddress default_gateway;
            List<IPAddress> local_hosts2Ping;
            List<IPAddress> remote_hosts2Ping;
            List<IPAddress> dns_servers;
            String technician_full_name;
            String service_request_number;
        

        public
            //setters, adders
            void parse_set_default_gateway(String ip2parse){
                try
                {
                    this.default_gateway = IPAddress.Parse(ip2parse);
                }
                catch(Exception e)
                {
                    MessageBox.Show(e.Message);
                }
            }
            void set_default_gateway(IPAddress ip){
                default_gateway = ip;
            }
            void add_ip_to_list(List<IPAddress> list, IPAddress address){
                list.Add(address);
            }
            void set_tech_name(String name) {
                this.technician_full_name = name;
            }
            
        
            //getters
            String get_tech_name() { 
                return technician_full_name;
            }
            String get_service_request_number(){
                return service_request_number;
            }
            IPAddress retrun_gateway() {
                return default_gateway;
            }
            



    }
}
