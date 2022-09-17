using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WinFormsApp1
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
          
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            textBox1.ScrollBars = ScrollBars.Both;
            textBox1.Clear();

            foreach (KeyValuePair<int, string> entry in Config.instrucitonsInBinary)
            {

                string PC = "0x" +  Convert.ToString(entry.Key,16).ToUpper() + " : ";

                textBox1.AppendText( PC + entry.Value );
                textBox1.AppendText(Environment.NewLine);

            }

            
        }
    }
}
