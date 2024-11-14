namespace desktopYapayZeka
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnUpload = new Button();
            txtResult = new RichTextBox();
            progressBar = new ProgressBar();
            lblStatus = new Label();
            groupBoxSonuc = new GroupBox();
            richTextBox1 = new RichTextBox();
            pictureBox1 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // btnUpload
            // 
            btnUpload.Location = new Point(400, 26);
            btnUpload.Name = "btnUpload";
            btnUpload.Size = new Size(495, 150);
            btnUpload.TabIndex = 0;
            btnUpload.Text = "EXCEL YUKLE";
            btnUpload.UseVisualStyleBackColor = true;
            btnUpload.Click += BtnUpload_Click;
            // 
            // txtResult
            // 
            txtResult.BackColor = Color.White;
            txtResult.Font = new Font("Mongolian Baiti", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtResult.ForeColor = Color.Black;
            txtResult.Location = new Point(-5, 285);
            txtResult.Margin = new Padding(20, 3, 3, 3);
            txtResult.Name = "txtResult";
            txtResult.ScrollBars = RichTextBoxScrollBars.Vertical;
            txtResult.Size = new Size(1397, 653);
            txtResult.TabIndex = 1;
            txtResult.Text = "YAPAY ZEKA DEĞERLENDİRMESİ";
            // 
            // progressBar
            // 
            progressBar.Location = new Point(563, 242);
            progressBar.Name = "progressBar";
            progressBar.Size = new Size(163, 23);
            progressBar.TabIndex = 2;
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Location = new Point(457, 242);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(82, 15);
            lblStatus.TabIndex = 3;
            lblStatus.Text = "İşlem Durumu";
            // 
            // groupBoxSonuc
            // 
            groupBoxSonuc.Location = new Point(389, 50);
            groupBoxSonuc.Name = "groupBoxSonuc";
            groupBoxSonuc.Size = new Size(200, 100);
            groupBoxSonuc.TabIndex = 4;
            groupBoxSonuc.TabStop = false;
            groupBoxSonuc.Text = "groupBox1";
            // 
            // richTextBox1
            // 
            richTextBox1.BackColor = Color.White;
            richTextBox1.Font = new Font("Modern No. 20", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            richTextBox1.ForeColor = Color.SandyBrown;
            richTextBox1.Location = new Point(1021, 46);
            richTextBox1.Margin = new Padding(20, 3, 3, 3);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.ScrollBars = RichTextBoxScrollBars.Vertical;
            richTextBox1.Size = new Size(341, 69);
            richTextBox1.TabIndex = 5;
            richTextBox1.Text = "© 2024. Orhun Babaoğlu Tüm hakları saklıdır";
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.LogoKosifler;
            pictureBox1.Location = new Point(-5, -2);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(250, 267);
            pictureBox1.SizeMode = PictureBoxSizeMode.AutoSize;
            pictureBox1.TabIndex = 6;
            pictureBox1.TabStop = false;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(147, 149, 152);
            ClientSize = new Size(1391, 905);
            Controls.Add(pictureBox1);
            Controls.Add(richTextBox1);
            Controls.Add(lblStatus);
            Controls.Add(progressBar);
            Controls.Add(txtResult);
            Controls.Add(btnUpload);
            Name = "Form1";
            Text = "H&R Yapay Zeka Değerlendirme Aracı";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnUpload;
        private RichTextBox txtResult;
        private ProgressBar progressBar;
        private Label lblStatus;
        private GroupBox groupBoxSonuc;
        private RichTextBox richTextBox1;
        private PictureBox pictureBox1;
    }
}
