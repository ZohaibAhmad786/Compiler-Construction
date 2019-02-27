using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ScarLanguage_Version1._1
{
    public partial class InputTakingForm : Form
    {
        public static  string datatype = null;
        
        public InputTakingForm()
        {
            
            InitializeComponent();
        }

        private void btnInput_Click(object sender, EventArgs e)
        {

            datatype = richTextBox1.Text;
           // Form1 f = new  Form1(datatype);
            
            this.Close();
        }
        //public void InputData()
        //{
        //    this.datatype;
        //}
    }
}
