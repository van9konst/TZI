using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.IO;

namespace TZInf.analiz.finaly
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            comboBox1.SelectedIndex = 0;
           // chart1.ChartAreas[0].AxisX.ScaleView.Zoom(100, 100);

            // Enable range selection and zooming end user interface
            chart1.ChartAreas[0].CursorX.IsUserEnabled = true;
            chart1.ChartAreas[0].CursorX.IsUserSelectionEnabled = true;
            chart1.ChartAreas[0].AxisX.ScaleView.Zoomable = true;
            chart1.ChartAreas[0].AxisX.ScrollBar.IsPositionedInside = true;
            chart2.ChartAreas[0].CursorX.IsUserEnabled = true;
            chart2.ChartAreas[0].CursorX.IsUserSelectionEnabled = true;
            chart2.ChartAreas[0].AxisX.ScaleView.Zoomable = true;
            chart2.ChartAreas[0].AxisX.ScrollBar.IsPositionedInside = true;
            /*
            chart2.ChartAreas[0].AxisY.Interval = 50;
            chart1.ChartAreas[0].AxisY.Interval = 50;
            */
        
        }

        private void button1_Click(object sender, EventArgs e)
        {
            switch (comboBox1.SelectedIndex)
            {
                case 0: OnesimbolShowStatistik();
                    break;
                case 1:BigramsShowStatistik();
                    break;
                case 2: TrigramsShowStatistik();
                    break;
                case 3: RepitgramsShowStatistik();
                    break;
                default:MessageBox.Show("Some Error");
                    break;
            }
        }
        public void BigramsShowStatistik()
        {
            chart1.Series[0].Points.Clear();

            AnalizMain am = new AnalizMain();
            am.CountBigrams();
            textBox1.Text = Convert.ToString(am.bigrams.Count);
            chart1.ChartAreas[0].AxisX.Interval = 1;
            for (int i = 0; i < am.bigrams.Count; i++)
            {
                string s = am.bigrams[i].Name;
                s = s.Replace(' ', '_');
                this.chart1.Series[0].Points.AddXY(s, am.bigrams[i].Counted);
            }
            chart2.Series[0].Points.Clear();
            chart2.ChartAreas[0].AxisX.Interval = 1;
            am.bigrams = am.bigrams.OrderByDescending(y => y.Counted).ToList();
            for (int i = 0; i < am.bigrams.Count; i++)
            {
                string s = am.bigrams[i].Name;
                s = s.Replace(' ', '_');
                this.chart2.Series[0].Points.AddXY(s, am.bigrams[i].Counted);
            }
        }
        public void TrigramsShowStatistik()
        {
            chart1.Series[0].Points.Clear();
            AnalizMain am = new AnalizMain();
            am.CountTrigrams();
            textBox1.Text = Convert.ToString(am.trigrams.Count);
            chart1.ChartAreas[0].AxisX.Interval = 1;
            for (int i = 0; i < am.trigrams.Count; i++)
            {
                string s = am.trigrams[i].Name;
                s = s.Replace(' ', '_');
                this.chart1.Series[0].Points.AddXY(s, am.trigrams[i].Counted);
            }
            chart2.Series[0].Points.Clear();
            chart2.ChartAreas[0].AxisX.Interval = 1;
            am.trigrams = am.trigrams.OrderByDescending(y => y.Counted).ToList();
            for (int i = 0; i < am.trigrams.Count; i++)
            {
                string s = am.trigrams[i].Name;
                s = s.Replace(' ', '_');
                this.chart2.Series[0].Points.AddXY(s, am.trigrams[i].Counted);
            }
        }
        public void OnesimbolShowStatistik()
        {
            chart1.Series[0].Points.Clear();
            AnalizMain am = new AnalizMain();
            am.OneSimbolAnalys();
            textBox1.Text = Convert.ToString(am.onegrams.Count);
            chart1.ChartAreas[0].AxisX.Interval = 1;
            for (int i = 0; i < am.onegrams.Count; i++)
            {
                string s = am.onegrams[i].Name;
                s = s.Replace(' ', '_');
                this.chart1.Series[0].Points.AddXY(s, am.onegrams[i].Counted);
            }
            chart2.Series[0].Points.Clear();
            chart2.ChartAreas[0].AxisX.Interval = 1;
            am.onegrams = am.onegrams.OrderByDescending(y => y.Counted).ToList();
            for (int i = 0; i < am.onegrams.Count; i++)
            {
                string s = am.onegrams[i].Name;
                s = s.Replace(' ', '_');
                this.chart2.Series[0].Points.AddXY(s, am.onegrams[i].Counted);
            }
        }

        public void RepitgramsShowStatistik()
        {
            chart1.Series[0].Points.Clear();
            AnalizMain am = new AnalizMain();
            am.CountRepitgrams();
            textBox1.Text = Convert.ToString(am.repitgrams.Count);
            chart1.ChartAreas[0].AxisX.Interval = 1;
            for (int i = 0; i < am.repitgrams.Count; i++)
            {
                string s = am.repitgrams[i].Name;
                s = s.Replace(' ', '_');
                this.chart1.Series[0].Points.AddXY(s, am.repitgrams[i].Counted);
            }
            chart2.Series[0].Points.Clear();
            chart2.ChartAreas[0].AxisX.Interval = 1;
            am.repitgrams = am.repitgrams.OrderByDescending(y => y.Counted).ToList();
            for (int i = 0; i < am.repitgrams.Count; i++)
            {
                string s = am.repitgrams[i].Name;
                s = s.Replace(' ', '_');
                this.chart2.Series[0].Points.AddXY(s, am.repitgrams[i].Counted);
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            chart1.ChartAreas[0].AxisX.ScaleView.ZoomReset(10);
            
            chart2.ChartAreas[0].AxisX.ScaleView.ZoomReset(10);
            
        }
        private void button3_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Show();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox3.SelectedIndex = comboBox2.SelectedIndex;
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox2.SelectedIndex = comboBox3.SelectedIndex;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
           
            comboBox2.Items.Clear();
            comboBox3.Items.Clear();
            AnalizMain am = new AnalizMain();
            switch (comboBox1.SelectedIndex)
            {
                case 0:
                    {
                        am.OneSimbolAnalys();
                        am.onegrams = am.onegrams.OrderByDescending(y => y.Counted).ToList();
                        for (int i = 0; i < am.onegrams.Count; i++)
                        {
                            comboBox2.Items.Add(am.onegrams[i].Name);
                            comboBox3.Items.Add(am.onegrams[i].Counted);
                        }
                        comboBox2.SelectedIndex = 0;
                    }; break;
                case 1:
                    {
                        am.CountBigrams();
                        am.bigrams = am.bigrams.OrderByDescending(y => y.Counted).ToList();
                        for (int i = 0; i < am.bigrams.Count; i++)
                        {
                            comboBox2.Items.Add(am.bigrams[i].Name);
                            comboBox3.Items.Add(am.bigrams[i].Counted);
                        }
                        comboBox2.SelectedIndex = 0;
                    }; break;
                case 2:
                    {
                        am.CountTrigrams();
                        am.trigrams = am.trigrams.OrderByDescending(y => y.Counted).ToList();
                        for (int i = 0; i < am.trigrams.Count; i++)
                        {
                            comboBox2.Items.Add(am.trigrams[i].Name);
                            comboBox3.Items.Add(am.trigrams[i].Counted);
                        }
                        comboBox2.SelectedIndex = 0;
                    }; ; break;
                default:
                    break;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            AnalizMain an = new AnalizMain();
            an.CountBigrams();
            an.CountTrigrams();
            an.OneSimbolAnalys();
            string[] path = { @"onesimbol.txt", @"bigram.txt", @"trigram.txt" };
            WriteToFile(path[0], an.SortGrams(an.onegrams));
            WriteToFile(path[1], an.SortGrams(an.bigrams));
            WriteToFile(path[2], an.SortGrams(an.trigrams));
            
        }
        private void WriteToFile(string path, List<Grams> gr)
        {
            int sum = 0;
            foreach (Grams item in gr)
            {
                sum += item.Counted;
            }
            using (StreamWriter sw = new StreamWriter(path, true))
            {
                foreach (Grams item in gr)
                {
                    float somePersent = item.Counted * 100 / sum;
                    sw.WriteLine("{0}  -  {1}  ", item.Name, item.Counted );
                }
                sw.Close();
            }
            
        }
    }
}
