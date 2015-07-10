using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.NetworkInformation;
using System.Net;




namespace UMMC_tk_network_test_tool
{
    public partial class main_test_form : Form
    {
        public main_test_form()
        {
            InitializeComponent();
        }

        // Ping procedure
         public void LocalPing ()
        {
            // Ping's the local machine.
            Ping pingSender = new Ping ();
            IPAddress address = IPAddress.Parse("185.13.132.211");
            
            PingReply reply = pingSender.Send (address);

            if (reply.Status == IPStatus.Success)
            {
                
                this.Output_console.AppendText("Address: " + reply.Address.ToString() + "\r\n");
                this.Output_console.AppendText("RoundTrip time: " + reply.RoundtripTime + "\r\n");
                this.Output_console.AppendText("Time to live: " + reply.Options.Ttl + "\r\n");
                this.Output_console.AppendText("Don't fragment: " + reply.Options.DontFragment + "\r\n");
                this.Output_console.AppendText("Buffer size: " + reply.Buffer.Length + "\r\n\r\n");
                this.Output_console.AppendText("=============================\r\n\r\n");

            }
            else
            {
                this.Output_console.AppendText ("Error occured");
            } 
         }




        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            for (int i = 0; i < 5; i++)
            {
                LocalPing();
                System.Threading.Thread.Sleep(2000);
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        }
}

