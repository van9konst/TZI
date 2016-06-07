using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace TZInf.analiz.finaly
{
    public partial class Form2 : Form
    {
        AnalizMain am = new AnalizMain();
        public Form2()
        {
            InitializeComponent();
            
            textBox2.Text = comboBox1.Text;
            comboBox2.Items.Add("simple");
            comboBox2.Items.Add("bigrams");
            comboBox2.Items.Add("trigrams");
            comboBox2.SelectedIndex = 0;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string path = @"L1.txt";
            string combineText = textBox2.Text;
            richTextBox1.Clear();
            richTextBox1.SelectionBackColor = Color.Black;
            string cinTEXT = "";
            if (File.Exists(path))
            {
                using (StreamReader sr = File.OpenText(path))
                {
                    


                    while (!sr.EndOfStream)
                    {
                        cinTEXT += sr.ReadLine();
                    }
                    richTextBox1.Text = cinTEXT;

                }
            }
            string inp = textBox2.Text;
            int i = 0;
            foreach (char symb in cinTEXT )
            {
                if ((i + inp.Length < cinTEXT.Length) && (inp == cinTEXT.Substring(i, inp.Length)))
                {
                    richTextBox1.Select(i, inp.Length);
                    richTextBox1.SelectionBackColor = Color.Red;
                }
                i++;
            }
        }
            
        

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();

            switch (comboBox2.SelectedIndex)
            {
                case 0:
                    {
                        am.OneSimbolAnalys();
                        am.onegrams = am.onegrams.OrderByDescending(y => y.Counted).ToList();
                        for (int i = 0; i < am.onegrams.Count; i++)
                        {
                            comboBox1.Items.Add(am.onegrams[i].Name);
                            comboBox3.Items.Add(am.onegrams[i].Counted);
                        }
                        comboBox1.SelectedIndex = 0;
                    }; break;
                case 1:
                    {
                        am.CountBigrams();
                        am.bigrams = am.bigrams.OrderByDescending(y => y.Counted).ToList();
                        for (int i = 0; i < am.bigrams.Count; i++)
                        {
                            comboBox1.Items.Add(am.bigrams[i].Name);
                            comboBox3.Items.Add(am.bigrams[i].Counted);
                        }
                        comboBox1.SelectedIndex = 0;
                    }; break;
                case 2:
                    {
                        am.CountTrigrams();
                        am.trigrams = am.trigrams.OrderByDescending(y => y.Counted).ToList();
                        for (int i = 0; i < am.trigrams.Count; i++)
                        {
                            comboBox1.Items.Add(am.trigrams[i].Name);
                            comboBox3.Items.Add(am.trigrams[i].Counted);
                        }
                        comboBox1.SelectedIndex = 0;
                    }; ; break;
                default:
                    break;
            }
                        

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox2.Text = comboBox1.Text;
            comboBox3.SelectedIndex = comboBox1.SelectedIndex;
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = comboBox3.SelectedIndex;
        }

     

     
    }
}
