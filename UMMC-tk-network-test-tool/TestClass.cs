using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json.Linq;

namespace UMMC_tk_network_test_tool
{
    [TestClass]
    public class ClientTest
    {
        [TestMethod]
        public void json_encode()
        {
            
           Client client = new Client("Ivanov", "123");
           Results results = new Results();
           for (int i = 0; i < 20; i++)
           {
               String num = Convert.ToString(i);
               String rem = Convert.ToString(i + 100);
               

           } 
           String result = client.json_encode(results);
           Console.WriteLine(results);
        }



       

      


        [TestMethod]
        public void test_json_inResults() {
            Results results = new Results();
            results.RequestNum = "1544";
            results.TechName = "Иванов Иван Иваныч";
            results.DownloadSpeed = "15mb/s";
            JObject data = results.serializeRezults();
            Console.WriteLine(data.ToString());


        }



        [TestMethod]
        public void send_data_to_server() {

            Client client = new Client("Ivanov", "123");
            client.get_test_data("http://localhost:8080/target", "message");
            
        
        }
        [TestMethod]
        public void test_parse() {
            Client client = new Client("Ivanov", "123");
            client.parameters.parseJsonData("123");

            Console.WriteLine(client.parameters.clientIP);
            Console.WriteLine(client.parameters.DNSservers);
            Console.WriteLine(client.parameters.remotehostsR1);
            Console.WriteLine(client.parameters.localhostsR1);

        
        }
    }
}