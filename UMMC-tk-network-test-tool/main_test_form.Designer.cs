namespace UMMC_tk_network_test_tool
{
    partial class main_test_form
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
            this.Output_console = new System.Windows.Forms.TextBox();
            this.ping_settings = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.begin_test = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.Network_test = new System.Windows.Forms.CheckBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // Output_console
            // 
            this.Output_console.Location = new System.Drawing.Point(12, 309);
            this.Output_console.Multiline = true;
            this.Output_console.Name = "Output_console";
            this.Output_console.ReadOnly = true;
            this.Output_console.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.Output_console.Size = new System.Drawing.Size(898, 130);
            this.Output_console.TabIndex = 0;
            // 
            // ping_settings
            // 
            this.ping_settings.Location = new System.Drawing.Point(12, 14);
            this.ping_settings.Name = "ping_settings";
            this.ping_settings.Size = new System.Drawing.Size(163, 23);
            this.ping_settings.TabIndex = 1;
            this.ping_settings.Text = "Настройки PING теста";
            this.ping_settings.UseVisualStyleBackColor = true;
            // 
            // comboBox1
            // 
            this.comboBox1.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(693, 14);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(217, 21);
            this.comboBox1.TabIndex = 2;
            this.comboBox1.Text = "<Выбрать город>";
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // begin_test
            // 
            this.begin_test.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.begin_test.ForeColor = System.Drawing.Color.DarkGreen;
            this.begin_test.Location = new System.Drawing.Point(337, 268);
            this.begin_test.Name = "begin_test";
            this.begin_test.Size = new System.Drawing.Size(220, 35);
            this.begin_test.TabIndex = 3;
            this.begin_test.Text = "Начать тест!";
            this.begin_test.UseVisualStyleBackColor = true;
            this.begin_test.Click += new System.EventHandler(this.beginTest_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 60);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(163, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "Настройки теста 1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(12, 107);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(163, 23);
            this.button2.TabIndex = 5;
            this.button2.Text = "Настройки теста 2";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(12, 157);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(163, 23);
            this.button3.TabIndex = 6;
            this.button3.Text = "Настройки теста 3";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // Network_test
            // 
            this.Network_test.AutoSize = true;
            this.Network_test.Location = new System.Drawing.Point(693, 60);
            this.Network_test.Name = "Network_test";
            this.Network_test.Size = new System.Drawing.Size(76, 17);
            this.Network_test.TabIndex = 7;
            this.Network_test.Text = "Тест сети";
            this.Network_test.UseVisualStyleBackColor = true;
            this.Network_test.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(693, 93);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(177, 17);
            this.checkBox2.TabIndex = 8;
            this.checkBox2.Text = "Проверить настройки тарифа";
            this.checkBox2.UseVisualStyleBackColor = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::UMMC_tk_network_test_tool.Properties.Resources.UGMK_Telecom_LOGO_bxbnnjqarg_qftpwxxuajoencab_2;
            this.pictureBox1.Location = new System.Drawing.Point(372, 14);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(143, 80);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 9;
            this.pictureBox1.TabStop = false;
            // 
            // main_test_form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(922, 451);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.checkBox2);
            this.Controls.Add(this.Network_test);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.begin_test);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.ping_settings);
            this.Controls.Add(this.Output_console);
            this.Name = "main_test_form";
            this.Text = "УГМК Телеком | Утилита для теста оборудования";
            this.Load += new System.EventHandler(this.main_test_form_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox Output_console;
        private System.Windows.Forms.Button ping_settings;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button begin_test;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.CheckBox Network_test;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}