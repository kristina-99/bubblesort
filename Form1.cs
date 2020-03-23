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

namespace bbsort3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public void Button1_Click(object sender, EventArgs e)
        {
            
            if (String.IsNullOrEmpty(textBox1.Text)) 
            {
                this.Hide();
                Error er = new Error();
                er.Show();
            }
            
            else
            {
                string[] stringItems = textBox1.Text.Split(',');
                int[] array = (from s in stringItems select int.Parse(s)).ToArray();
                int t;
                
                label1.Text = String.Join(",", array.Select(p => p.ToString()).ToArray());
                this.Hide();
                Visual vis = new Visual();
                vis.Show();
                vis.label1.Text = String.Join(",", array.Select(p => p.ToString()).ToArray());
                TextBox[] tb = new TextBox[7] { vis.textBox1, vis.textBox2, vis.textBox3, vis.textBox4, vis.textBox5, vis.textBox6, vis.textBox7 };
                ;
                for(int i=0,j=array.Length;i<j;i++)
                {
                    tb[i].Text = array[i].ToString();
                    tb[i].BackColor = Color.White;
                    Font fnt = new Font(tb[i].Font.FontFamily, 20.0F);
                    tb[i].Font = fnt;

                }
                for (int i = array.Length; i < tb.Length; i++)
                {
                    tb[i].Dispose();
                }
                Task.Delay(2000).Wait();
                for (int p = 0; p <= array.Length - 2; p++)
                {
                    for (int i = 0; i <= array.Length - 2; i++)
                    {
                        if (array[i] > array[i + 1])
                        {
                            t = array[i + 1];
                            array[i + 1] = array[i];
                            tb[i + 1].BackColor = Color.LightGreen;
                            tb[i+1].Text = array[i].ToString();
                            array[i] = t;
                            tb[i].BackColor = Color.LightGreen;
                            tb[i].Text = t.ToString();
                            Task.Delay(2000).Wait();
                            tb[i].BackColor = Color.White;
                            tb[i + 1].BackColor = Color.White;
                        }
                    }
                    Task.Delay(2000).Wait();
                }

            }
                


        }
    }
}


