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
using Json;
using System.Diagnostics;
using System.Web;
using System.IO;
using System.Net.NetworkInformation;
using System.Threading;






namespace UMMC_tk_network_test_tool
{
    public class Client : Client_Side_Tests
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
        public Client(String tech_name, String service_request_num)
        {
            local_hosts2Ping = new List<IPAddress>();
            remote_hosts2Ping = new List<IPAddress>();
            dns_servers = new List<IPAddress>();
            results = new Results();
            this.set_tech_name(tech_name);
            this.set_service_request_number(service_request_num);
            this.parameters = new TestParameters();
        }



        private
        IPAddress default_gateway = IPAddress.Parse("192.168.0.1");
        List<IPAddress> local_hosts2Ping;
        List<IPAddress> remote_hosts2Ping;
        List<IPAddress> dns_servers;
        String technician_full_name;
        String service_request_number;
        Results results;
        String paramData;
        public TestParameters parameters;
       

        public
            //setters, adders
            void parse_set_default_gateway(String ip2parse)
        {
            try
            {
                this.default_gateway = IPAddress.Parse(ip2parse);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
            void set_default_gateway(IPAddress ip)
            {
                default_gateway = ip;
            }
            void add_ip_to_list(List<IPAddress> list, IPAddress address)
            {
                list.Add(address);
            }
            void set_tech_name(String name)
            {
                this.technician_full_name = name;
            }
            void set_service_request_number(String service_request_num)
            {
                this.service_request_number = service_request_num;
            }


        //getters
            String get_tech_name()
            {
                return technician_full_name;
            }
            String get_service_request_number()
            {
                return service_request_number;
            }
            IPAddress retrun_gateway()
            {
                return default_gateway;
            }


        
        public async Task<System.Net.NetworkInformation.PingReply> ping_test(IPAddress ip)
        {
            
            Console.WriteLine(ip.ToString());
            Ping pingSender = new Ping();
            string data = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";
            byte[] buffer = Encoding.ASCII.GetBytes(data);
            PingOptions options = new PingOptions(64, true);
            
            PingReply reply =  pingSender.Send(ip, 3000, buffer, options);
            return reply;
    
      }
        
        
        public String CheckSpeed()
        {
            const string tempfile = "tempfile.tmp";
            System.Net.WebClient webClient = new System.Net.WebClient();

            Console.WriteLine("Downloading file....");

            System.Diagnostics.Stopwatch sw = System.Diagnostics.Stopwatch.StartNew();
            webClient.DownloadFile("http://mirror.internode.on.net/pub/test/10meg.test", tempfile);
            sw.Stop();
            long speed;
            double result;
            FileInfo fileInfo = new FileInfo(tempfile);
            if (sw.Elapsed.Seconds != 0){              
                speed = (fileInfo.Length / sw.Elapsed.Seconds);
                result = (double)speed * 0.000008;
            }
            else
                result = 0;
            Console.WriteLine("Download duration: {0}", sw.Elapsed);
            Console.WriteLine("File size: {0} bytes", fileInfo.Length.ToString("N0"));
            try
            {
                FileInfo currentFile = new FileInfo(tempfile);
                currentFile.Delete();
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error on file: {0}\r\n   {1}", tempfile, ex.Message);
            }
            return result.ToString();   
        }




        public String json_encode(Object data)
        {

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

       
       
        


        public async Task<int> get_test_data(String server, String message)
        {
            var HTTPmessage = new Dictionary<String, String>{
                {"parameters","parameters"}
            };

            var content = new FormUrlEncodedContent(HTTPmessage);

            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.PostAsync(server, content);
            if (response.IsSuccessStatusCode) {
                this.paramData = await response.Content.ReadAsStringAsync();
                Console.WriteLine("Success!\r\n" + this.paramData);
                this.parameters.parseJsonData(paramData);
               
            }
            else 
            { 
                Console.WriteLine("Something went wrong...");
                return -1;
            }
            return 0;
        }



        internal async Task<int> beginTest(main_test_form form)
        {

            updateConsole n = new updateConsole(form.outputToConsole);
            n(System.Drawing.Color.Black, "Тестируем...\r\n\r\n", true);
            
            n(System.Drawing.Color.Black, "Тестируем...\r\n\r\n", true);
            n(System.Drawing.Color.Black, "Проверяем локальные хосты...\r\n", true);
            

            await pingLocalHostsMain(form);

            n(System.Drawing.Color.Black, "\r\n\r\nПроверяем внешние хосты...\r\n", true);
            await pingRemotelHostsMain(form);
            n(System.Drawing.Color.Black, "Проверяем скорость...\r\n", true);
            String response = this.CheckSpeed();


            n(System.Drawing.Color.Black, "Скорость закачки: ", true);
            n(System.Drawing.Color.Green, response + " Мб/с", false);
            updateProgressBar g = new updateProgressBar(form.fillProgressBar);
            g(50);
            return 0;
        }

        private async Task<int> pingRemotelHostsMain(main_test_form form)
        {
            for (int i = 0; i < this.parameters.remotehostsR1.Count(); i++)
            {
                int fraction;
                try
                {
                    fraction = 50 / this.parameters.remotehostsR1.Count();
                }
                catch (Exception e)
                {

                    fraction = 50;
                }
                updateProgressBar g = new updateProgressBar(form.fillProgressBar);
                g(fraction);
                String host = this.parameters.remotehostsR1[i].ToString();

                long roundTrip = 0;

                int count = 0;
                int failures = 0;
                for (int j = 0; j < 5; j++)
                {
                    PingReply reply = await ping_test(this.parameters.remotehostsR1[i]);
                    if (reply.Status == IPStatus.Success)
                    {
                        roundTrip += reply.RoundtripTime;
                        count++;

                    }
                    else
                    {
                        failures++;
                    }
                    Thread.Sleep(500);
                }

                updateConsole n = new updateConsole(form.outputToConsole);

                n(System.Drawing.Color.Black, " ", true);
                n(System.Drawing.Color.Black, "Хост: " + host, true);
                n(System.Drawing.Color.Red, "Ошибок: " + failures + " || ", true);
                if (count > 0)
                    n(System.Drawing.Color.Green, "Среднее время отклика: " + ((roundTrip * 1.0) / count) + "мс", false);
                else
                    n(System.Drawing.Color.Red, "Хост не ответил ни разу.", false);

            }
            form.enableBegin();
            return 0;
        }





        private async Task<int> pingLocalHostsMain(main_test_form form)
        {
            for (int i = 0; i < this.parameters.localhostsR1.Count(); i++)
            {
                int fraction;
                try
                {
                   fraction  = 50 / this.parameters.localhostsR1.Count();
                }
                catch (Exception e)
                {

                    fraction = 50;
                }
                updateProgressBar g = new updateProgressBar(form.fillProgressBar);
                g(fraction);
                String host = this.parameters.localhostsR1[i].ToString();

                long roundTrip = 0;

                int count = 0;
                int failures = 0;
                for (int j = 0; j < 5; j++)
                {
                    PingReply reply = await ping_test(this.parameters.localhostsR1[i]);
                    if (reply.Status == IPStatus.Success)
                    {
                        roundTrip += reply.RoundtripTime;
                        count++;

                    }
                    else
                    {
                        failures++;
                    }
                    Thread.Sleep(2000);
                }
                updateConsole n = new updateConsole(form.outputToConsole);
                n(System.Drawing.Color.Black, " ", true);
                n(System.Drawing.Color.Black, "Хост: " + host, true);
                n(System.Drawing.Color.Red, "Ошибок: " + failures + " || ", true);
                if (count > 0)
                    n(System.Drawing.Color.Green, "Среднее время отклика: " + ((roundTrip * 1.0) / count) + "мс", false);
                else
                    n(System.Drawing.Color.Red, "Хост не ответил ни разу.", false);
                
            }
           
            return 0;
        }
    }
        
           
    
}
