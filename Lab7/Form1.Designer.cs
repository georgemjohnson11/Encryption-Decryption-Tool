namespace Lab7
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
            this.Filenametext = new System.Windows.Forms.TextBox();
            this.Keytext = new System.Windows.Forms.TextBox();
            this.Filenamelabel = new System.Windows.Forms.Label();
            this.Keylabel = new System.Windows.Forms.Label();
            this.encryptbutton = new System.Windows.Forms.Button();
            this.decryptbutton = new System.Windows.Forms.Button();
            this.browsecompfiles = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.saveFileDialog2 = new System.Windows.Forms.SaveFileDialog();
            this.SuspendLayout();
            // 
            // Filenametext
            // 
            this.Filenametext.Location = new System.Drawing.Point(22, 61);
            this.Filenametext.Name = "Filenametext";
            this.Filenametext.Size = new System.Drawing.Size(265, 20);
            this.Filenametext.TabIndex = 0;
            // 
            // Keytext
            // 
            this.Keytext.Location = new System.Drawing.Point(22, 110);
            this.Keytext.Name = "Keytext";
            this.Keytext.Size = new System.Drawing.Size(112, 20);
            this.Keytext.TabIndex = 1;
            // 
            // Filenamelabel
            // 
            this.Filenamelabel.AutoSize = true;
            this.Filenamelabel.Location = new System.Drawing.Point(31, 45);
            this.Filenamelabel.Name = "Filenamelabel";
            this.Filenamelabel.Size = new System.Drawing.Size(52, 13);
            this.Filenamelabel.TabIndex = 2;
            this.Filenamelabel.Text = "Filename:";
            // 
            // Keylabel
            // 
            this.Keylabel.AutoSize = true;
            this.Keylabel.Location = new System.Drawing.Point(31, 94);
            this.Keylabel.Name = "Keylabel";
            this.Keylabel.Size = new System.Drawing.Size(28, 13);
            this.Keylabel.TabIndex = 3;
            this.Keylabel.Text = "Key:";
            // 
            // encryptbutton
            // 
            this.encryptbutton.Location = new System.Drawing.Point(34, 148);
            this.encryptbutton.Name = "encryptbutton";
            this.encryptbutton.Size = new System.Drawing.Size(75, 23);
            this.encryptbutton.TabIndex = 4;
            this.encryptbutton.Text = "Encrypt";
            this.encryptbutton.UseVisualStyleBackColor = true;
            this.encryptbutton.Click += new System.EventHandler(this.encryptbutton_Click);
            // 
            // decryptbutton
            // 
            this.decryptbutton.Location = new System.Drawing.Point(136, 148);
            this.decryptbutton.Name = "decryptbutton";
            this.decryptbutton.Size = new System.Drawing.Size(75, 23);
            this.decryptbutton.TabIndex = 5;
            this.decryptbutton.Text = "Decrypt";
            this.decryptbutton.UseVisualStyleBackColor = true;
            this.decryptbutton.Click += new System.EventHandler(this.decryptbutton_Click);
            // 
            // browsecompfiles
            // 
            this.browsecompfiles.Image = global::Lab7.Properties.Resources.OpenPH1;
            this.browsecompfiles.Location = new System.Drawing.Point(293, 45);
            this.browsecompfiles.Name = "browsecompfiles";
            this.browsecompfiles.Size = new System.Drawing.Size(39, 36);
            this.browsecompfiles.TabIndex = 6;
            this.browsecompfiles.UseVisualStyleBackColor = true;
            this.browsecompfiles.Click += new System.EventHandler(this.button1_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog1_FileOk);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(366, 193);
            this.Controls.Add(this.browsecompfiles);
            this.Controls.Add(this.decryptbutton);
            this.Controls.Add(this.encryptbutton);
            this.Controls.Add(this.Keylabel);
            this.Controls.Add(this.Filenamelabel);
            this.Controls.Add(this.Keytext);
            this.Controls.Add(this.Filenametext);
            this.Name = "Form1";
            this.Text = "Encrypter/Decrypter by George Johnson";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox Filenametext;
        private System.Windows.Forms.TextBox Keytext;
        private System.Windows.Forms.Label Filenamelabel;
        private System.Windows.Forms.Label Keylabel;
        private System.Windows.Forms.Button encryptbutton;
        private System.Windows.Forms.Button decryptbutton;
        private System.Windows.Forms.Button browsecompfiles;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog2;
    }
}

