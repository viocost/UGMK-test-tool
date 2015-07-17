using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using System.Net.NetworkInformation;
using System.Net;





namespace UMMC_tk_network_test_tool
{
    public partial class main_test_form : Form
    {
        private
            Client client;
           


        public main_test_form(String tech_name, String service_request_num)
        {
            InitializeComponent();

            //TODO
            //wait disable main form
            
            
            client = new Client(tech_name, service_request_num);
            
            //TODO

            if (client.request_parameters())
            {
                if (client.check_gateway())
                {
                    MessageBox.Show("Отсутствует соединение со шлюзом!");
                }
                else
                {
                    MessageBox.Show("Отсутствует соединение с сервером!"); 
                }
            }


            
            //SEND REQUEST TO A SERVER VIA JSON SERIALIZER
            //IF SERVER DOES NOT RESPOND - PING GATEWAY
            //DISPLAY RESULTS TO A USER


            //TODO GET RESPOND FROM A SERVER WITH PARAMETERS, PARSE THEM

           
            
        }

        // Ping procedure
        public void LocalPing ()
        {
            // Ping's the local machine.
            Ping pingSender = new Ping ();
            IPAddress address = IPAddress.Parse("185.13.132.211");

            PingReply reply = client.ping_test(IPAddress.Parse("192.168.1.1"));
                //pingSender.Send (address);

            if (reply.Status == IPStatus.Success)
            {
                lock (this){
                this.Output_console.AppendText("Address: " + reply.Address.ToString() + "\r\n");
                this.Output_console.AppendText("RoundTrip time: " + reply.RoundtripTime + "\r\n");
                this.Output_console.AppendText("Time to live: " + reply.Options.Ttl + "\r\n");
                this.Output_console.AppendText("Don't fragment: " + reply.Options.DontFragment + "\r\n");
                this.Output_console.AppendText("Buffer size: " + reply.Buffer.Length + "\r\n\r\n");
                this.Output_console.AppendText("=============================\r\n\r\n");
                }
            }
            else
            {
                this.Output_console.AppendText ("Error occured");
            } 
         }




        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void beginTest_Click(object sender, EventArgs e)
        {
            Console.WriteLine("About to send data!");
            this.client.get_test_data("http://localhost:8080/target", "message");
            
        }

        private void run_the_test()
        {
           
            {
                this.begin_test.Enabled = false;
            }
            for (int i = 0; i < 5; i++)
            {
                LocalPing();
                System.Threading.Thread.Sleep(2000);
            }
           
            {
                this.begin_test.Enabled = true;
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void main_test_form_Load(object sender, EventArgs e)
        {

        }

        }
}

