using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
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

        



        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.login_text_box.Text.Equals(this.login) && this.password_text_box.Text.Equals(this.password))
            {
                // invoke main test form
                
                this.Hide();
                main_test_form MainTest = new main_test_form();
                MainTest.Closed += (s, args) => this.Close();
                MainTest.Show();
                
               
            }
            else
            {
                DialogResult dialogResult = MessageBox.Show("Имя или паполь введены неверно!", "Отказ", MessageBoxButtons.OK);
            }


            

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Popup_exit exit = new Popup_exit();
            exit.ShowDialog();

        }

        private void login_text_box_TextChanged(object sender, EventArgs e)
        {
            if (login_text_box.Text == "" || password_text_box.Text == "") {
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

        }
    }
}
