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
    public partial class MainForm : System.Windows.Forms.Form
    {
        AboutBox aboutBox;
        int[,] grid;
        bool isFirstWindow = true;
        public MainForm()
        {
            InitializeComponent(); 

        }

        private void To_Copy_Text(object sender, EventArgs e)
        {
            Clipboard.SetText(textBox2.Text);
        }

        private void To_Copy_Key(object sender, EventArgs e)
        {
            Clipboard.SetText(textBox3.Text);
        }

        private void Help(object sender, EventArgs e)
        {
            if (!isFirstWindow)
            {
                aboutBox.Close();
            }
            aboutBox = new AboutBox();
            aboutBox.Show(); 
            isFirstWindow = false;
        }

        private void To_Encrypt(object sender, EventArgs e)
        {        

            if (radioButton1.Checked)
            {
                this.grid = Encryption.Convert_Key_To_Grid(textBox3.Text);
            }
            else
            {
                String key = "";
                this.grid = Encryption.Grid_Generation();             
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
            }
            textBox2.Text = Encryption.Encryp_Text(textBox1.Text, this.grid);
        }

        private void To_Decrypt(object sender, EventArgs e)
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
