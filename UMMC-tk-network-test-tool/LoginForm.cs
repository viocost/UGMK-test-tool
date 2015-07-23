using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace UMMC_tk_network_test_tool
{
    public partial class Login_form : Form
    {
        public Login_form()
        {
            InitializeComponent();
            
            
            
        }
        private string login = "login";
        private string password = "password";
        
        private String server_ip = "localhost";
        private String server_port = "8080";
      



        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //check server
        //    Thread checkServer = new Thread(check_server_connection);
           



           

            if (this.login_text_box.Text.Equals(this.login) && this.password_text_box.Text.Equals(this.password))
            {
                // invoke main test form
                //RADIUS LOGIN


             
               



                this.Hide();

                // send request to a server ask for test parameters!



                main_test_form MainTest = new main_test_form(this.technician_full_name.Text, this.service_request_num.Text);
                MainTest.Closed += (s, args) => this.Close();
                MainTest.Show();
                
               
            }
            else
            {
                DialogResult dialogResult = MessageBox.Show("Имя или паполь введены неверно!", "Отказ", MessageBoxButtons.OK);
            }


            

        }

        private async Task check_server_connection()
        {
           
            String server = server_ip + ":" + server_port + "/pingServer!";

            

            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync(server);
            if (response.IsSuccessStatusCode)
            {
                //SET FLAG TO TRUE

            }
            else
            {
                Console.WriteLine("Something went wrong...");
                MessageBox.Show("Отсутствует соединение со шлюзом!");

                MessageBox.Show("Отсутствует соединение с сервером!");

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Popup_exit exit = new Popup_exit();
            exit.ShowDialog();

        }

        private void login_text_box_TextChanged(object sender, EventArgs e)
        {
            if (login_text_box.Text == "" || password_text_box.Text == "" || technician_full_name.Text == "" || service_request_num.Text == "")
            {
                this.Ok.Enabled = false;} else {
                    this.Ok.Enabled = true;
            }
        }

        private void password_text_box_TextChanged(object sender, EventArgs e)
        {
            if (login_text_box.Text == "" || password_text_box.Text == "" || technician_full_name.Text == "" || service_request_num.Text == "" )
            {
                this.Ok.Enabled = false;
            }
            else
            {
                this.Ok.Enabled = true;
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void technician_full_name_TextChanged(object sender, EventArgs e)
        {
            if (login_text_box.Text == "" || password_text_box.Text == "" || technician_full_name.Text == "" || service_request_num.Text == "")
            {
                this.Ok.Enabled = false;
            }
            else
            {
                this.Ok.Enabled = true;
            }
        }

        private void Login_form_Load(object sender, EventArgs e)
        {

        }

        private void service_request_num_TextChanged(object sender, EventArgs e)
        {
            if (login_text_box.Text == "" || password_text_box.Text == "" || technician_full_name.Text == "" || service_request_num.Text == "")
            {
                this.Ok.Enabled = false;
            }
            else
            {
                this.Ok.Enabled = true;
            }
            int n;
            bool isNumeric = int.TryParse(service_request_num.Text, out n);
            if (!isNumeric)
            {
                service_request_num.ResetText();
                MessageBox.Show("Номер заявки должен содержать только цифры!");
            }
        }

        private void CheckEnter(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                // Enter key pressed
                this.Ok.PerformClick();


            }
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            
            
        }

    }
}
