namespace RSA_cipher
{
    partial class Form1
    {
        /// <summary>
        /// Vyžaduje se proměnná návrháře.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Uvolněte všechny používané prostředky.
        /// </summary>
        /// <param name="disposing">hodnota true, když by se měl spravovaný prostředek odstranit; jinak false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kód generovaný Návrhářem Windows Form

        /// <summary>
        /// Metoda vyžadovaná pro podporu Návrháře - neupravovat
        /// obsah této metody v editoru kódu.
        /// </summary>
        private void InitializeComponent()
        {
            this.textBoxPrvocisloQ = new System.Windows.Forms.TextBox();
            this.textBoxPrvocisloP = new System.Windows.Forms.TextBox();
            this.Random_button = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.Check_button = new System.Windows.Forms.Button();
            this.Open_textBox = new System.Windows.Forms.TextBox();
            this.Cipher_textBox = new System.Windows.Forms.TextBox();
            this.Decrypt_button = new System.Windows.Forms.Button();
            this.Encrypt_button = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // textBoxPrvocisloQ
            // 
            this.textBoxPrvocisloQ.Location = new System.Drawing.Point(42, 53);
            this.textBoxPrvocisloQ.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxPrvocisloQ.Name = "textBoxPrvocisloQ";
            this.textBoxPrvocisloQ.Size = new System.Drawing.Size(221, 20);
            this.textBoxPrvocisloQ.TabIndex = 0;
            // 
            // textBoxPrvocisloP
            // 
            this.textBoxPrvocisloP.Location = new System.Drawing.Point(42, 19);
            this.textBoxPrvocisloP.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxPrvocisloP.Name = "textBoxPrvocisloP";
            this.textBoxPrvocisloP.Size = new System.Drawing.Size(221, 20);
            this.textBoxPrvocisloP.TabIndex = 1;
            // 
            // Random_button
            // 
            this.Random_button.Location = new System.Drawing.Point(279, 19);
            this.Random_button.Name = "Random_button";
            this.Random_button.Size = new System.Drawing.Size(84, 20);
            this.Random_button.TabIndex = 2;
            this.Random_button.Text = "Random";
            this.Random_button.UseVisualStyleBackColor = true;
            this.Random_button.Click += new System.EventHandler(this.Random_button_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(535, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(53, 26);
            this.button1.TabIndex = 3;
            this.button1.Text = "Info";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Check_button
            // 
            this.Check_button.Location = new System.Drawing.Point(279, 53);
            this.Check_button.Name = "Check_button";
            this.Check_button.Size = new System.Drawing.Size(84, 23);
            this.Check_button.TabIndex = 4;
            this.Check_button.Text = "Check";
            this.Check_button.UseVisualStyleBackColor = true;
            this.Check_button.Click += new System.EventHandler(this.Check_button_Click);
            // 
            // Open_textBox
            // 
            this.Open_textBox.Location = new System.Drawing.Point(12, 128);
            this.Open_textBox.Multiline = true;
            this.Open_textBox.Name = "Open_textBox";
            this.Open_textBox.Size = new System.Drawing.Size(269, 197);
            this.Open_textBox.TabIndex = 5;
            // 
            // Cipher_textBox
            // 
            this.Cipher_textBox.Location = new System.Drawing.Point(310, 128);
            this.Cipher_textBox.Multiline = true;
            this.Cipher_textBox.Name = "Cipher_textBox";
            this.Cipher_textBox.Size = new System.Drawing.Size(269, 197);
            this.Cipher_textBox.TabIndex = 6;
            // 
            // Decrypt_button
            // 
            this.Decrypt_button.Location = new System.Drawing.Point(504, 331);
            this.Decrypt_button.Name = "Decrypt_button";
            this.Decrypt_button.Size = new System.Drawing.Size(75, 23);
            this.Decrypt_button.TabIndex = 7;
            this.Decrypt_button.Text = "Decrypt";
            this.Decrypt_button.UseVisualStyleBackColor = true;
            this.Decrypt_button.Click += new System.EventHandler(this.Decrypt_button_Click);
            // 
            // Encrypt_button
            // 
            this.Encrypt_button.Location = new System.Drawing.Point(206, 331);
            this.Encrypt_button.Name = "Encrypt_button";
            this.Encrypt_button.Size = new System.Drawing.Size(75, 23);
            this.Encrypt_button.TabIndex = 8;
            this.Encrypt_button.Text = "Encrypt";
            this.Encrypt_button.UseVisualStyleBackColor = true;
            this.Encrypt_button.Click += new System.EventHandler(this.Encrypt_button_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(17, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "P:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(18, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Q:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 366);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Encrypt_button);
            this.Controls.Add(this.Decrypt_button);
            this.Controls.Add(this.Cipher_textBox);
            this.Controls.Add(this.Open_textBox);
            this.Controls.Add(this.Check_button);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.Random_button);
            this.Controls.Add(this.textBoxPrvocisloP);
            this.Controls.Add(this.textBoxPrvocisloQ);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.Text = "RSA";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxPrvocisloQ;
        private System.Windows.Forms.TextBox textBoxPrvocisloP;
        private System.Windows.Forms.Button Random_button;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button Check_button;
        private System.Windows.Forms.TextBox Open_textBox;
        private System.Windows.Forms.TextBox Cipher_textBox;
        private System.Windows.Forms.Button Decrypt_button;
        private System.Windows.Forms.Button Encrypt_button;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}

