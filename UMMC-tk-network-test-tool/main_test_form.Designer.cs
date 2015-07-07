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
            this.SuspendLayout();
            // 
            // Output_console
            // 
            this.Output_console.Location = new System.Drawing.Point(12, 309);
            this.Output_console.Multiline = true;
            this.Output_console.Name = "Output_console";
            this.Output_console.ReadOnly = true;
            this.Output_console.Size = new System.Drawing.Size(898, 130);
            this.Output_console.TabIndex = 0;
            // 
            // ping_settings
            // 
            this.ping_settings.Location = new System.Drawing.Point(12, 12);
            this.ping_settings.Name = "ping_settings";
            this.ping_settings.Size = new System.Drawing.Size(163, 23);
            this.ping_settings.TabIndex = 1;
            this.ping_settings.Text = "Настройки для PING теста";
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
            this.begin_test.Location = new System.Drawing.Point(372, 268);
            this.begin_test.Name = "begin_test";
            this.begin_test.Size = new System.Drawing.Size(230, 35);
            this.begin_test.TabIndex = 3;
            this.begin_test.Text = "Начать тест!";
            this.begin_test.UseVisualStyleBackColor = true;
            this.begin_test.Click += new System.EventHandler(this.button1_Click);
            // 
            // main_test_form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(922, 451);
            this.Controls.Add(this.begin_test);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.ping_settings);
            this.Controls.Add(this.Output_console);
            this.Name = "main_test_form";
            this.Text = "УГМК Телеком | Утилита для теста оборудования";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox Output_console;
        private System.Windows.Forms.Button ping_settings;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button begin_test;
    }
}