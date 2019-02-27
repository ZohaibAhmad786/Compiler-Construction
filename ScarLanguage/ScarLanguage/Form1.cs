using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ScarLanguage
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string[] variables;
            string[] s = richtxtInputCode.Lines;
            foreach (string c in s)
            {
                string[] a = c.Split(' ');
                foreach (string b in a)
                {
                    if (b == "INT" || b == "FLAOT" || b == "STRING")
                    {


                       // richtxtResult.Text = "Sucessfully";
                        string[] space = c.Split();

                        for (int i = 1; i < space.Length; i++)
                        {
                            string[] vari = space[i].Split(',');
                            for (int u = 0; u < vari.Length; u++)
                            {
                                string[] semi = vari[u].Split(';');
                                for (int x = 0; x < semi.Length; x++)
                                {
                                    if (semi[x] == "@a" || semi[x] == "@b" || semi[x] == "@c" || semi[x] == "@A" || semi[x] == "@B" || semi[x] == "@C")
                                    {




                                        //richtxtResult.Text += "Your variable are Declearde";
                                        richtxtResult.Text += semi[x] + "=" + 20;
                                    }
                                    else if (semi[x] == "")
                                    {
                                        break;
                                    }
                                    else
                                    {
                                        richtxtResult.Text = "Variable Decleration Error";
                                        break;
                                    }

                                }

                            }
                        }
                        break;
                    }
                    else
                    {
                        richtxtResult.Text = "Your Data type is not defined";

                    }
                }

                Console.WriteLine();

            }
            //int aa = 0;
            //string[] addition = richtxtResult.Lines;
            //foreach (var item in addition)
            //{
            //    string getvarvlaue = item.Split('=').Take(2).ToString();
            //    foreach (var item1 in getvarvlaue)
            //    {
            //         aa+= int.Parse(item1.ToString());
            //        //int b = int.Parse(item1.ToString());
                   
            //    }
            //}
            //Console.Write(richtxtResult.Text += aa);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
