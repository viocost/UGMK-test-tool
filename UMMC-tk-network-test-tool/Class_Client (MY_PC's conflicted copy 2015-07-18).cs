using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Windows.Forms;
using System.Net.Sockets;
using Newtonsoft.Json;
using System.Net.Http;
using System.Web.Http;



namespace UMMC_tk_network_test_tool
{
    public class Client: Client_Side_Tests
    {

        


        /* 1. Ping the gateway and server if ok
         * 2. send request for test data (list of ip adresses and dns servers
         * 3. Receive data from server parse it, fill data structures
         * 4. ping hosts
         * 5. Check DNS
         * 6. Measure speed
         * 7. Send results to server
         * 8. display results on the screen
         * */
        public Client(String tech_name, String service_request_num){
            local_hosts2Ping = new List<IPAddress>();
            remote_hosts2Ping = new List<IPAddress>();
            dns_servers = new List<IPAddress>();
            results = new Results();
            this.set_tech_name(tech_name);
            this.set_service_request_number(service_request_num);

        }



        private
            IPAddress default_gateway = IPAddress.Parse("192.168.0.1");
            List<IPAddress> local_hosts2Ping;
            List<IPAddress> remote_hosts2Ping;
            List<IPAddress> dns_servers;
            String technician_full_name;
            String service_request_number;
            Results results;

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
            void set_service_request_number(String service_request_num) {
                this.service_request_number = service_request_num;
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


            //TODO
            public bool request_parameters() {
               // throw new NotImplementedException();
                
                //Connect("192.168.1.11", "Wassup server?");
                return false;
            }

            //TODO
            public bool check_gateway() {
                throw new NotImplementedException();
            }

            //TODO


            public System.Net.NetworkInformation.PingReply ping_test(IPAddress ip)
            {
                throw new NotImplementedException();
            }





            public String json_encode(Object data) {
                
                String serialized = JsonConvert.SerializeObject(data);
                Console.WriteLine(serialized);
                return serialized;

            }

            static byte[] GetBytes(string str)
            {
                byte[] bytes = new byte[str.Length * sizeof(char)];
                System.Buffer.BlockCopy(str.ToCharArray(), 0, bytes, 0, bytes.Length);
                return bytes;
            }

            static string GetString(byte[] bytes)
            {
                char[] chars = new char[bytes.Length / sizeof(char)];
                System.Buffer.BlockCopy(bytes, 0, chars, 0, bytes.Length);
                return new string(chars);
            }


            public String send_data_to_server(String server, String message)
            {
                HttpClient client = new HttpClient();
                
                client.PostAsJsonAsync(server, message);


                return null;     
            }
    }
}
