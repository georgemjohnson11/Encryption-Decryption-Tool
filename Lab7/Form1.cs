using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.IO;

namespace Lab7
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //lets the user choose the file
            if (openFileDialog1.ShowDialog(this) == DialogResult.OK)
            {
                Filenametext.Text = openFileDialog1.FileName;
            }
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        //takes the input file and checks to ensure there is a file and the key to encrypt to make a .des file
        private void encryptbutton_Click(object sender, EventArgs e)
        {
            FileStream infile = null, outfile = null;
            byte[] buffer = new byte[512];
            byte[] key = new byte[8];
            if (Filenametext.Text == "")
            {
                MessageBox.Show("The source file must be specified!");
                return;

            }
                //ensures that a key is used
            else if (Keytext.Text == "")
            {
                MessageBox.Show("The Key must be specified!");
                return;
            }
                //ensures a good file type is used.
            else if (Filenametext.Text.Substring(Filenametext.TextLength - 4, 4) == ".des")
            {
                MessageBox.Show("Encrypting more than once leads to file errors. Please use another file not encrypted");
                return;
            }
            try
            {
                infile = new FileStream(Filenametext.Text, FileMode.Open);
                if (File.Exists(Filenametext.Text+".des"))
                    { 
                    // allows the user to overwrite a file
                        DialogResult result = MessageBox.Show("Do you want to OVERWRITE existing file?", "Warning",
                            MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                        if (result == DialogResult.Yes)
                        {
                            File.Delete(Filenametext.Text+".des");
                        }
                        else if (result == DialogResult.No)
                        {
                            return;
                        }
                    }
                outfile = new FileStream(Filenametext.Text + ".des", FileMode.Create);
                byte[] bin = new byte[100]; //This is intermediate storage for the encryption.
                long rdlen = 0;              //This is the total number of bytes written.
                long totlen = infile.Length;    //This is the total length of the input file.
                int len;                     //This is the number of bytes to be written at a time.
                DES des = new DESCryptoServiceProvider();
                byte[] encryptkey = new byte[8];
                int i = 0;

                //assigns the lower bytes to the proper location for keys that are not 8 char in length
                foreach (char k in Keytext.Text)
                {
                    byte keys = (byte)k;
                    encryptkey[i] += keys;
                    ++i;
                    if (i == 8)
                    { i = 0; }
                }
                des.Key = encryptkey;
                des.IV = encryptkey;
                CryptoStream crypt = new CryptoStream(outfile, des.CreateEncryptor(), CryptoStreamMode.Write);

                while (rdlen < totlen)
                {
                    len = infile.Read(bin, 0, 100);
                    crypt.Write(bin, 0, len);
                    rdlen = rdlen + len;
                    Console.WriteLine("{0} bytes processed", rdlen);
                }

                crypt.Close();
                outfile.Close();
                infile.Close();
            }
                //checks for good or bad key
                catch (System.Security.Cryptography.CryptographicException)
            {
                MessageBox.Show("Corrupt or bad Key", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
                //checks for good or bad file
                catch (System.IO.FileNotFoundException)
            {
                MessageBox.Show("Could not open file", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            catch (Exception ee)
            {
                MessageBox.Show("Encryption failed!\n" + ee.Message);
            }
        }


        private void decryptbutton_Click(object sender, EventArgs e)
        {
            FileStream infile = null, outfile = null;
            byte[] buffer = new byte[512];
            byte[] key = new byte[8];
            //ensures user has a file to en/decrypt
            if (Filenametext.Text == "")
            {
                MessageBox.Show("The source file must be specified!");
                return;

            }
                //ensures user has a key they are using
            else if (Keytext.Text == "")
            {
                MessageBox.Show("The Key must be specified!");
                return;
            }
                //makes sure it's the correct file extension
            else if (Filenametext.Text.Substring(Filenametext.TextLength - 4, 4) != ".des")
            {
                MessageBox.Show("Only .des file types are allowed");
                return;
        }
            else if (Filenametext.Text.Substring(Filenametext.TextLength - 4, 4) == ".des")
            {
                try
                {
                    infile = new FileStream(Filenametext.Text, FileMode.Open);
                    if (File.Exists(Filenametext.Text.Substring(0,Filenametext.TextLength -4)))
                    {
                        //ensures the user does not unintentionally overwrite file to prevent loss of key
                        DialogResult result = MessageBox.Show("Do you want to OVERWRITE existing file?", "Warning",
                            MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                        if (result == DialogResult.Yes)
                        {
                            File.Delete(Filenametext.Text.Substring(0, Filenametext.TextLength - 4));
                        }
                        else if (result == DialogResult.No)
                        {
                            return;
                        }
                         }
                    outfile = new FileStream(Filenametext.Text.Remove(Filenametext.TextLength - 4, 4), FileMode.Create);
                    byte[] bin = new byte[100]; //This is intermediate storage for the encryption.
                    long rdlen = 0;              //This is the total number of bytes written.
                    long totlen = infile.Length;    //This is the total length of the input file.
                    int len;                     //This is the number of bytes to be written at a time.
                    DES des = new DESCryptoServiceProvider();
                    //converts keys to byte based 
                    byte[] decryptkey = new byte[8];
                    int i=0;
                    foreach (char k in Keytext.Text)
                    {
                        byte keys = (byte)k;
                        decryptkey[i]+= keys;
                        ++i;
                            if (i==8)
                            {i=0;}
                    }
                    des.Key = decryptkey;
                    des.IV = decryptkey;
                    CryptoStream crypt = new CryptoStream(outfile, des.CreateDecryptor(), CryptoStreamMode.Write);
                    while (rdlen < totlen)
                    {
                        len = infile.Read(bin, 0, 100);
                        crypt.Write(bin, 0, len);
                        rdlen = rdlen + len;
                        Console.WriteLine("{0} bytes processed", rdlen);
                    }

                    crypt.Close();
                    outfile.Close();
                    infile.Close();
                }
                //checks for good or bad key
                catch (System.Security.Cryptography.CryptographicException)
                {
                    MessageBox.Show("Corrupt or bad Key", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                //checks for good or bad file
                catch (System.IO.FileNotFoundException)
                {
                    MessageBox.Show("Could not open file", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                //general log of failed decryption
                catch (Exception ee)
                {
                    MessageBox.Show("Decryption failed!\n" + ee.Message);
                }

            }
        }
    }
}
    
