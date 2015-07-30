using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace UMMC_tk_network_test_tool
{

    public class Results
    {


        //Data
        private String techName;
        private String requestNum;
        private String downloadSpeed;
        private String uploadSpeed;
        private String portErrors;

        //ASUO data
        private String tariffPlanCheck;
        private String portSpeed;
        private String LinkStatus;
        private String cableLength;


        public Results() { 
            tariffPlanCheck = "Нет информации";
            portSpeed = "Нет информации";
            LinkStatus ="Нет информации";
            cableLength = "Нет информации";
            portErrors = "Нет информации";
        }


        public String TariffPlanCheck
        {
            get { return tariffPlanCheck; }
            set { tariffPlanCheck = value; }
        }
        

        public String PortSpeed
        {
            get { return portSpeed; }
            set { portSpeed = value; }
        }
        

        public String LinkStatus1
        {
            get { return LinkStatus; }
            set { LinkStatus = value; }
        }
        

        public String PortErrors
        {
            get { return portErrors; }
            set { portErrors = value; }
        }
       

        public String CableLength
        {
            get { return cableLength; }
            set { cableLength = value; }
        }
        

        //commutators chain..



        //Getters Setters
        public String TechName
        {
            get { return techName; }
            set { techName = value; }
        }
        public String RequestNum
        {
            get { return requestNum; }
            set { requestNum = value; }
        }
        public String DownloadSpeed
        {
            get { return downloadSpeed; }
            set { downloadSpeed = value; }
        }
       

        public Dictionary<String, Dictionary<String, String>> localhosts_results = new Dictionary<String, Dictionary<String, String>>();
        public Dictionary<String, Dictionary<String, String>> remotehosts_results = new Dictionary<String, Dictionary<String, String>>();
        public Dictionary<String, Dictionary<String, String>> dns_servers = new Dictionary<String, Dictionary<String, String>>();



        public JObject serializeRezults() {

            JObject results = new JObject();
            results.Add("Technician Name", this.TechName);
            results.Add("Request Number", this.RequestNum);


            JObject jlocalHosts = new JObject();
            
            JObject jRemoteHosts = new JObject();
            JObject jDNSservers = new JObject();

            foreach (KeyValuePair<string, Dictionary<string, string>> entry in localhosts_results)
            {
                JObject host = new JObject();
                foreach (KeyValuePair<string, string> subEntry in entry.Value) {
                    host.Add(subEntry.Key, subEntry.Value);
                }
                jlocalHosts.Add(entry.Key,  host);
            }

            foreach (KeyValuePair<string, Dictionary<string, string>> entry in remotehosts_results)
            {
                JObject host = new JObject();
                foreach (KeyValuePair<string, string> subEntry in entry.Value)
                {
                    host.Add(subEntry.Key, subEntry.Value);
                }
                jRemoteHosts.Add(entry.Key, host);
            }

            foreach (KeyValuePair<string, Dictionary<string, string>> entry in dns_servers)
            {
                JObject host = new JObject();
                foreach (KeyValuePair<string, string> subEntry in entry.Value)
                {
                    host.Add(subEntry.Key, subEntry.Value);
                }
                jDNSservers.Add(entry.Key, host);
            }

            results.Add("Local hosts", jlocalHosts);
            results.Add("Remote hosts", jRemoteHosts);
            results.Add("DNS servers", jDNSservers);


            return results;

        }
        


    }
}
