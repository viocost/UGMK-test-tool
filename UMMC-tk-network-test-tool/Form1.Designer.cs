﻿namespace UMMC_tk_network_test_tool
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.password_text_box = new System.Windows.Forms.TextBox();
            this.login_text_box = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.Ok = new System.Windows.Forms.Button();
            this.Cancel = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.technician_full_name = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.service_request_num = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // password_text_box
            // 
            this.password_text_box.Location = new System.Drawing.Point(309, 209);
            this.password_text_box.Name = "password_text_box";
            this.password_text_box.Size = new System.Drawing.Size(512, 20);
            this.password_text_box.TabIndex = 0;
            this.password_text_box.UseSystemPasswordChar = true;
            this.password_text_box.TextChanged += new System.EventHandler(this.password_text_box_TextChanged);
            // 
            // login_text_box
            // 
            this.login_text_box.Location = new System.Drawing.Point(309, 146);
            this.login_text_box.Name = "login_text_box";
            this.login_text_box.Size = new System.Drawing.Size(512, 20);
            this.login_text_box.TabIndex = 1;
            this.login_text_box.TextChanged += new System.EventHandler(this.login_text_box_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(255, 149);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Логин:";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(248, 212);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Пароль:";
            // 
            // Ok
            // 
            this.Ok.Enabled = false;
            this.Ok.Location = new System.Drawing.Point(623, 277);
            this.Ok.Name = "Ok";
            this.Ok.Size = new System.Drawing.Size(75, 23);
            this.Ok.TabIndex = 4;
            this.Ok.Text = "Вход";
            this.Ok.UseVisualStyleBackColor = true;
            this.Ok.TextChanged += new System.EventHandler(this.login_text_box_TextChanged);
            this.Ok.Click += new System.EventHandler(this.button1_Click);
            // 
            // Cancel
            // 
            this.Cancel.Location = new System.Drawing.Point(746, 277);
            this.Cancel.Name = "Cancel";
            this.Cancel.Size = new System.Drawing.Size(75, 23);
            this.Cancel.TabIndex = 5;
            this.Cancel.Text = "Отмена";
            this.Cancel.UseVisualStyleBackColor = true;
            this.Cancel.Click += new System.EventHandler(this.button2_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::UMMC_tk_network_test_tool.Properties.Resources.UGMK_Telecom_LOGO_bxbnnjqarg_qftpwxxuajoencab_2;
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(141, 86);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            // 
            // technician_full_name
            // 
            this.technician_full_name.Location = new System.Drawing.Point(309, 81);
            this.technician_full_name.Name = "technician_full_name";
            this.technician_full_name.Size = new System.Drawing.Size(512, 20);
            this.technician_full_name.TabIndex = 7;
            this.technician_full_name.TextChanged += new System.EventHandler(this.technician_full_name_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(216, 84);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "ФИО техника:";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // service_request_num
            // 
            this.service_request_num.Location = new System.Drawing.Point(309, 277);
            this.service_request_num.Name = "service_request_num";
            this.service_request_num.Size = new System.Drawing.Size(163, 20);
            this.service_request_num.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(236, 280);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "№ заявки:";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(975, 329);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.service_request_num);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.technician_full_name);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.Cancel);
            this.Controls.Add(this.Ok);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.login_text_box);
            this.Controls.Add(this.password_text_box);
            this.Name = "Form1";
            this.Text = "УГМК Телеком | Утилита для тестирования сетей | Login:";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox password_text_box;
        private System.Windows.Forms.TextBox login_text_box;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button Ok;
        private System.Windows.Forms.Button Cancel;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox technician_full_name;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox service_request_num;
        private System.Windows.Forms.Label label4;
    }
}

