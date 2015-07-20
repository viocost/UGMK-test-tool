using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UMMC_tk_network_test_tool
{
    [TestClass]
    public class ClientTest
    {
        [TestMethod]
        public String json_encode()
        {
            
           Client client = new Client("Ivanov", "123");
           Results results = new Results();
           for (int i = 0; i < 20; i++)
           {
               String num = Convert.ToString(i);
               String rem = Convert.ToString(i + 100);
               results.localhosts_results.Add(num, num);
               results.remotehosts_results.Add(num, num);

           }
           results.SomeInt = 9999;
           results.someString = "HuivRot!";

           
           String result = client.json_encode(results);

           Console.WriteLine(results);
           return result;

        }

        [TestMethod]
        public void send_data_to_server() {

            Client client = new Client("Ivanov", "123");
            String data = this.json_encode();
            String respond = client.send_data_to_server("192.168.1.11", data);
            



        
        }
    }
}