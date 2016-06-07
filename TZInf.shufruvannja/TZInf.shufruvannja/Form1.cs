using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TZInf.shufruvannja
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            comboBox1.SelectedIndex = 0;
            textBox3.Text= " .,;-ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        }

        private void button1_Click(object sender, EventArgs e)
        {

            richTextBox2.Text = "";
            switch (comboBox1.SelectedIndex)
            {
                case 0:
                    {
                        Cesar ces = new Cesar(Convert.ToInt16(keytextBox.Text));
                        foreach (char c in richTextBox1.Text)
                            richTextBox2.Text += ces.chifer(c);
                    }
                    break;
                case 1:
                    {
                        ProstoiZaminu pz = new ProstoiZaminu();
                        foreach (char c in richTextBox1.Text)
                            richTextBox2.Text += pz.chifer(c);
                    }
                    break;
                case 2: 
                    {
                        Vijiner vij = new Vijiner(keytextBox.Text.ToUpper());
                        foreach (char c in richTextBox1.Text)
                            richTextBox2.Text += vij.chifer(c);
                    } 
                    break;
                default: MessageBox.Show("wrong comand");
                    break;
            }
         
          
        }

        private void comboBox1_TextChanged(object sender, EventArgs e)
        {
            switch (comboBox1.SelectedIndex)
            {
                case 0: {
                    groupBox1.Visible = false; 
                    groupBox2.Visible = true;
                    keytextBox.Text = "16";
                }
                    break;
                case 1: {
                    groupBox1.Visible = true;
                    groupBox2.Visible = false;
                }
                    break;
                case 2: {
                    groupBox1.Visible = false;
                    groupBox2.Visible = true;
                    keytextBox.Text = "QWERTY";
                }
                    break;
                default:
                    break;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ProstoiZaminu pr = new ProstoiZaminu();
            pr.alphaREplace(textBox1.Text[0], textBox2.Text[0]);
            textBox3.Text = pr.GetAlphaIN();
            textBox4.Text = pr.GetAlphaOUT();
            button1_Click (sender, e);
        }

   
    }
}
