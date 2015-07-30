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
            this.begin_test = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.outputConsole = new System.Windows.Forms.RichTextBox();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // begin_test
            // 
            this.begin_test.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.begin_test.ForeColor = System.Drawing.Color.DarkGreen;
            this.begin_test.Location = new System.Drawing.Point(188, 14);
            this.begin_test.Name = "begin_test";
            this.begin_test.Size = new System.Drawing.Size(635, 81);
            this.begin_test.TabIndex = 3;
            this.begin_test.Text = "Начать тест!";
            this.begin_test.UseVisualStyleBackColor = true;
            this.begin_test.Click += new System.EventHandler(this.beginTest_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::UMMC_tk_network_test_tool.Properties.Resources.UGMK_Telecom_LOGO_bxbnnjqarg_qftpwxxuajoencab_2;
            this.pictureBox1.Location = new System.Drawing.Point(12, 14);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(143, 80);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 9;
            this.pictureBox1.TabStop = false;
            // 
            // outputConsole
            // 
            this.outputConsole.Location = new System.Drawing.Point(12, 114);
            this.outputConsole.Name = "outputConsole";
            this.outputConsole.ReadOnly = true;
            this.outputConsole.Size = new System.Drawing.Size(811, 269);
            this.outputConsole.TabIndex = 10;
            this.outputConsole.Text = "";
            this.outputConsole.TextChanged += new System.EventHandler(this.outputConsole_TextChanged);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(12, 410);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(811, 32);
            this.progressBar1.TabIndex = 13;
            this.progressBar1.Click += new System.EventHandler(this.progressBar1_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(735, 129);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 14;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // main_test_form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(836, 468);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.outputConsole);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.begin_test);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "main_test_form";
            this.Text = "УГМК Телеком | Утилита для теста оборудования";
            this.Load += new System.EventHandler(this.main_test_form_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button begin_test;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.RichTextBox outputConsole;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Button button1;
    }
}