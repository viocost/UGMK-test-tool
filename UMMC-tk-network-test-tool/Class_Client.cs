using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Windows.Forms;
using System.Net.Sockets;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
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
        
        
        public List<String> CheckSpeed(Results results)
        {



            ClassSpeedTest test = new ClassSpeedTest();
            List<string> result = test.runSpeedTest();
            try
            {
                results.DownloadSpeed = result[0];
            }
            catch (Exception ex) {
                Console.WriteLine("Didn't get the result. Error: " + ex);
            }

            //const string tempfile = "tempfile.tmp";
            //System.Net.WebClient webClient = new System.Net.WebClient();
            
            //Console.WriteLine("Downloading file....");

            //System.Diagnostics.Stopwatch sw = System.Diagnostics.Stopwatch.StartNew();
            //webClient.DownloadFile("http://mirror.internode.on.net/pub/test/10meg.test", tempfile);
            //sw.Stop();
            //long speed;
            //double result;
            //FileInfo fileInfo = new FileInfo(tempfile);
            //if (sw.Elapsed.Seconds != 0){              
            //    speed = (fileInfo.Length / sw.Elapsed.Seconds);
            //    result = (double)speed * 0.000008;
            //}
            //else
            //    result = 0;
            //Console.WriteLine("Download duration: {0}", sw.Elapsed);
            //Console.WriteLine("File size: {0} bytes", fileInfo.Length.ToString("N0"));
            //try
            //{
            //    FileInfo currentFile = new FileInfo(tempfile);
            //    currentFile.Delete();
            //}
            //catch (Exception ex)
            //{
            //    Debug.WriteLine("Error on file: {0}\r\n   {1}", tempfile, ex.Message);
            //}


            return result;   
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

       
       public async Task<Object> ASUO_request(main_test_form form, Results results, String server){
           //TODO 1
           // Serialize results and prepare HTTP message
           var message = results.serializeRezults();


           var httpWebRequest = (HttpWebRequest)WebRequest.Create(server);
           httpWebRequest.ContentType = "text/json";
           httpWebRequest.Method = "POST";
           

           
           using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
           {
               
               streamWriter.Write(message);
               streamWriter.Flush();
               streamWriter.Close();
           }

           var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();


           //Get test results back and display it on the output console

           using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
           {
               JObject result = JObject.Parse(streamReader.ReadToEnd());

               //{"Port speed":"auto","Port errors":"Error","Link status":"down"}
               results.PortSpeed = (String)result["Port speed"];
               results.PortErrors = (String)result["Port errors"];
               results.LinkStatus1 = (String)result["Link status"];

           }


          


           return null;
       }
        


        public async Task<int> get_test_data(main_test_form form, String server, String message)
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
                updateConsole n = new updateConsole(form.outputToConsole);
                n(System.Drawing.Color.Red, "\r\n\r\nНе получилось соединиться с сервером.", true);
                
                
                Console.WriteLine("Something went wrong...");
                return -1;

            }
            return 0;
        }



        internal async Task<int> beginTest(main_test_form form, Results results)
        {

            updateConsole n = new updateConsole(form.outputToConsole);

            n(System.Drawing.Color.Red, "Внимание!!! Процедура должна занять некоторое время.\r\nПожалуйста дождитесь окончания процедуры.", true);
            n(System.Drawing.Color.Black, "\r\nТестируем...\r\n\r\n", true);
            n(System.Drawing.Color.Black, "Проверяем локальные хосты...\r\n", true);
            

            await pingLocalHostsMain(form, results);

            n(System.Drawing.Color.Black, "\r\n\r\nПроверяем внешние хосты...\r\n", true);
            await pingRemotelHostsMain(form, results);
            n(System.Drawing.Color.Black, "\r\n\r\nПроверяем скорость...\r\n", true);
            List<String> response = this.CheckSpeed(results);


            n(System.Drawing.Color.Black, "Скорость закачки: ", true);
            n(System.Drawing.Color.Green, response[0] + " Мб/с", false);
            n(System.Drawing.Color.Black, "Скорость выкачки: ", true);
            n(System.Drawing.Color.Green, response[1] + " Мб/с", false);
            updateProgressBar g = new updateProgressBar(form.fillProgressBar);
            g(10);
            return 0;
        }



        private async Task<int> checkDNSServers(main_test_form form, Results results)
        {
            for (int i = 0; i < this.parameters.DNSservers.Count(); i++)
            {
                int fraction;
                try
                {
                    fraction = 15 / this.parameters.remotehostsR1.Count();
                }
                catch (Exception e)
                {
                    fraction = 15;
                }
                updateProgressBar g = new updateProgressBar(form.fillProgressBar);
                g(fraction);
                String host = this.parameters.remotehostsR1[i].ToString();
                results.remotehosts_results.Add(host, new Dictionary<String, String>());
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
                results.dns_servers[host].Add("Sent packets", count.ToString());
                results.dns_servers[host].Add("Errors", failures.ToString());
                results.dns_servers[host].Add("Average response time", ((roundTrip * 1.0) / count).ToString());

                updateConsole n = new updateConsole(form.outputToConsole);

                n(System.Drawing.Color.Black, " ", true);
                n(System.Drawing.Color.Black, "Сервер: " + host, true);
                n(System.Drawing.Color.Red, "Ошибок: " + failures + " || ", true);
                if (count > 0)
                    n(System.Drawing.Color.Green, "Среднее время отклика: " + ((roundTrip * 1.0) / count) + "мс", false);
                else
                    n(System.Drawing.Color.Red, "Сервер не ответил ни разу.", false);

            }
            
            return 0;
        }




        private async Task<int> pingRemotelHostsMain(main_test_form form, Results results)
        {
            for (int i = 0; i < this.parameters.remotehostsR1.Count(); i++)
            {
                int fraction;
                try
                {
                    fraction = 15 / this.parameters.remotehostsR1.Count();
                }
                catch (Exception e)
                {
                    fraction = 15;
                }
                updateProgressBar g = new updateProgressBar(form.fillProgressBar);
                g(fraction);
                String host = this.parameters.remotehostsR1[i].ToString();
                results.remotehosts_results.Add(host, new Dictionary<String, String>());
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
                results.remotehosts_results[host].Add("Sent packets", count.ToString());
                results.remotehosts_results[host].Add("Errors", failures.ToString());
                results.remotehosts_results[host].Add("Average response time", ((roundTrip * 1.0) / count).ToString());

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







        private async Task<int> pingLocalHostsMain(main_test_form form, Results results)
        {
            for (int i = 0; i < this.parameters.localhostsR1.Count(); i++)
            {
                int fraction;
                try
                {
                   fraction  = 15 / this.parameters.localhostsR1.Count();
                }
                catch (Exception e)
                {

                    fraction = 15;
                }
                updateProgressBar g = new updateProgressBar(form.fillProgressBar);
                g(fraction);
                String host = this.parameters.localhostsR1[i].ToString();
                results.localhosts_results.Add(host, new Dictionary<String, String>());

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

                    
                    
                    Thread.Sleep(500);
                }
                //Updating results
                results.localhosts_results[host].Add("Sent packets", count.ToString());
                results.localhosts_results[host].Add("Errors", failures.ToString());
                results.localhosts_results[host].Add("Average response time", ((roundTrip * 1.0) / count).ToString());


                //Updating console
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

        internal void displayFinalResults(main_test_form form, Results results)
        {
            updateConsole n = new updateConsole(form.outputToConsole);
            n(System.Drawing.Color.Black, "\r\nРезультаты из АСУО:\r\n\r\n", true);
            n(System.Drawing.Color.Black, "\r\nТарифный план: "+results.TariffPlanCheck, true);

         
            n(System.Drawing.Color.Black, "\r\nСкорость Порта: ", true);
            n(System.Drawing.Color.Green, results.PortSpeed, false);

            if (results.LinkStatus1.Contains("up"))
            {
                n(System.Drawing.Color.Black, "\r\nСтатус линка: ", true);
                n(System.Drawing.Color.Green, results.LinkStatus1, false);
            }
            else {
                n(System.Drawing.Color.Black, "\r\nСтатус линка: ", true);
                n(System.Drawing.Color.Red, results.LinkStatus1, false);          
            }



            if (results.PortErrors.Contains("Error"))
            {
                n(System.Drawing.Color.Black, "\r\nОшибки порта: ", true);
                n(System.Drawing.Color.Red, results.PortErrors, false);
            }
            else
            {

                n(System.Drawing.Color.Black, "\r\nОшибки порта: ", true);
                n(System.Drawing.Color.Green, results.PortErrors, false);
            }

            try {
                int cableLength = int.Parse(results.CableLength);
                if (cableLength <= 180)
                {
                    n(System.Drawing.Color.Black, "\r\nДлина кабеля: ", true);
                    n(System.Drawing.Color.Green, "ОК", false);
                }
                else throw new Exception();
 

            } catch {
                n(System.Drawing.Color.Black, "\r\nДлина кабеля: ", true);
                if (results.CableLength.Contains("Нет"))
                    n(System.Drawing.Color.Red, results.CableLength, false);
                else
                    n(System.Drawing.Color.Red, "Error", false);
            }





          

        }
    }
        
           
    
}
