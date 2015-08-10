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



public delegate void updateConsole(Color color, string text, Boolean newLine);
public delegate void updateProgressBar(int property);


namespace UMMC_tk_network_test_tool
{
    public partial class main_test_form : Form
    {
        private
            Client client;
      
            Results results;
            bool dataReceived = false;
           


        public main_test_form(String tech_name, String service_request_num)
        {
            InitializeComponent();
            
         

            //TODO
            //wait disable main form
            client = new Client(tech_name, service_request_num);
            results = new Results();
            results.TechName = tech_name;
            results.RequestNum = service_request_num;

   
     
            //SEND REQUEST TO A SERVER VIA JSON SERIALIZER
            //IF SERVER DOES NOT RESPOND - PING GATEWAY
            //DISPLAY RESULTS TO A USER


            //TODO GET RESPOND FROM A SERVER WITH PARAMETERS, PARSE THEM           
        }





        public delegate Task<int> runTest(main_test_form form);


        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        internal void enableBegin() {
            this.begin_test.Enabled = true;
        }
        
        
        private async void  beginTest_Click(object sender, EventArgs e)
        {
            Console.WriteLine("About to send data!");
            this.progressBar1.Value = 0;


            try
            {
                if (!dataReceived)
                {
                    await this.client.get_test_data(this, "http://localhost:8080/target", "message");
                    dataReceived = true;
                }
                this.begin_test.Enabled = false;


                await client.beginTest(this, results);

                await client.ASUO_request(this, results, "http://localhost:8080/getASUOdata");

                client.displayFinalResults(this, results);

            }
            catch (Exception ex) {
                updateConsole n = new updateConsole(this.outputToConsole);

                n(System.Drawing.Color.Red, "Не удалось соединиться с сервером.", true);
                Console.WriteLine(ex.ToString());
                Console.WriteLine("Something went wrong");
                return;
            }


        }

        private void run_the_test()
        {
           
            {
                this.begin_test.Enabled = false;
            }
            for (int i = 0; i < 5; i++)
            {
                
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

        private void Output_console_TextChanged(object sender, EventArgs e)
        {

        }

        private void outputConsole_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void ip_address_box_TextChanged(object sender, EventArgs e)
        {

        }

        internal void fillProgressBar(int property) {
            this.progressBar1.Step = property;

            this.progressBar1.PerformStep();
        }
        internal void outputToConsole (Color color, string text, Boolean newLine)
        {

            if (newLine)
            {
                outputConsole.SelectionFont = new Font("Tahoma", 10, FontStyle.Bold);
                outputConsole.SelectionColor = color;
               
                outputConsole.AppendText("\n"+text);
            }
            else
            {
                outputConsole.SelectionFont = new Font("Tahoma", 10, FontStyle.Bold);
                outputConsole.SelectionColor = color;
               
                outputConsole.AppendText(text);
            }
           

            
            
            
        }

        private void progressBar1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private async void button1_Click(object sender, EventArgs e)
        {
            await client.ASUO_request(this, results, "http://46.160.161.178:8080/getASUOdata");
        }
    }
}

