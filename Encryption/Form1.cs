using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Encryption
{
    public partial class Form1 : Form
    {
        AboutBox1 aboutBox1 = new AboutBox1();
        int[,] grid;
        public Form1()
        {
            InitializeComponent(); 

        }

        private void To_Copy_Text_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(textBox2.Text);
        }

        private void To_Copy_Key_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(textBox3.Text);
        }

        private void Help_Click(object sender, EventArgs e)
        {
            this.aboutBox1.Show();
        }

        private void To_Encrypt_Click(object sender, EventArgs e)
        {
            String key = "";

            if (radioButton1.Checked)
            {
                key = textBox3.Text;
                textBox2.Text = Encryption.Encryp_Text_With_Key(textBox1.Text, key);
            }
            else
            {
                this.grid = Encryption.Key_Generation();             
                int counter = 0;

                for (int line = 0; line < 10; line++)
                {
                    for (int column = 0; column < 10; column++)
                    {
                        if (grid[line, column] == 1)
                        {
                            key += Convert.ToString(counter) + ".";
                        }
                        counter++;
                    }
                }

                textBox3.Text = key.Remove(key.Length - 1);
                textBox2.Text = Encryption.Encryp_Text(textBox1.Text, this.grid);
            }       
        }

        private void To_Decrypt_Text(object sender, EventArgs e)
        {
            try
            {
                textBox2.Text = Encryption.Decryption_Text(textBox3.Text, textBox1.Text);
            }
            catch
            {
                MessageBox.Show("Были введены некорректные данные");
            }
        }
    }
}
