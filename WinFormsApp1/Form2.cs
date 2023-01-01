using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            this.MaximizeBox = false;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            textBox1.Text = "0x"+ Config.registers[0].ToString("x");
            textBox2.Text = "0x" + Config.registers[1].ToString("x");
            textBox3.Text = "0x" + Config.registers[2].ToString("x");
            textBox4.Text = "0x" + Config.registers[3].ToString("x");
            textBox5.Text = "0x" + Config.registers[4].ToString("x");
            textBox6.Text = "0x" + Config.registers[5].ToString("x");
            textBox7.Text = "0x" + Config.registers[6].ToString("x");
            textBox8.Text = "0x" + Config.registers[7].ToString("x");
            textBox9.Text = "0x" + Config.registers[8].ToString("x");
            textBox10.Text = "0x" + Config.registers[9].ToString("x");
            textBox11.Text = "0x" + Config.registers[10].ToString("x");
            textBox12.Text = "0x" + Config.registers[11].ToString("x");
            textBox13.Text = "0x" + Config.registers[12].ToString("x");
            textBox14.Text = "0x" + Config.registers[13].ToString("x");
            textBox15.Text = "0x" + Config.registers[14].ToString("x");
            textBox16.Text = "0x" + Config.registers[15].ToString("x");

            textBox17.Text = "0x" + Config.registers[31].ToString("x");
            textBox18.Text = "0x" + Config.registers[30].ToString("x");
            textBox19.Text = "0x" + Config.registers[29].ToString("x");
            textBox20.Text = "0x" + Config.registers[28].ToString("x");
            textBox21.Text = "0x" + Config.registers[27].ToString("x");
            textBox22.Text = "0x" + Config.registers[26].ToString("x");
            textBox23.Text = "0x" + Config.registers[25].ToString("x");
            textBox24.Text = "0x" + Config.registers[24].ToString("x");
            textBox25.Text = "0x" + Config.registers[23].ToString("x");
            textBox26.Text = "0x" + Config.registers[22].ToString("x");
            textBox27.Text = "0x" + Config.registers[21].ToString("x");
            textBox28.Text = "0x" + Config.registers[20].ToString("x");
            textBox29.Text = "0x" + Config.registers[19].ToString("x");
            textBox30.Text = "0x" + Config.registers[18].ToString("x");
            textBox31.Text = "0x" + Config.registers[17].ToString("x");
            textBox32.Text = "0x" + Config.registers[16].ToString("x");


            textBox33.Text = "0x" + Config.ACC.ToString("x");
            textBox34.Text = "0x"+Convert.ToString(Config.PC,16);

            textBox35.Text = Convert.ToString(Config.NZCV, 2).PadLeft(4,'0');
            textBox36.Text = Config.USER_STACK.ToString();
        }

        private void label31_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label33_Click(object sender, EventArgs e)
        {

        }

        private void label34_Click(object sender, EventArgs e)
        {

        }

        private void textBox34_TextChanged(object sender, EventArgs e)
        {

        }

        private void label36_Click(object sender, EventArgs e)
        {

        }

        private void label35_Click(object sender, EventArgs e)
        {

        }

        private void textBox35_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox36_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
