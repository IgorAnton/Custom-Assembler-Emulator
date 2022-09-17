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
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            textBox1.Text = Config.registers[0].ToString();
            textBox2.Text = Config.registers[1].ToString();
            textBox3.Text = Config.registers[2].ToString();
            textBox4.Text = Config.registers[3].ToString();
            textBox5.Text = Config.registers[4].ToString();
            textBox6.Text = Config.registers[5].ToString();
            textBox7.Text = Config.registers[6].ToString();
            textBox8.Text = Config.registers[7].ToString();
            textBox9.Text = Config.registers[8].ToString();
            textBox10.Text = Config.registers[9].ToString();
            textBox11.Text = Config.registers[10].ToString();
            textBox12.Text = Config.registers[11].ToString();
            textBox13.Text = Config.registers[12].ToString();
            textBox14.Text = Config.registers[13].ToString();
            textBox15.Text = Config.registers[14].ToString();
            textBox16.Text = Config.registers[15].ToString();

            textBox17.Text = Config.registers[31].ToString();
            textBox18.Text = Config.registers[30].ToString();
            textBox19.Text = Config.registers[29].ToString();
            textBox20.Text = Config.registers[28].ToString();
            textBox21.Text = Config.registers[27].ToString();
            textBox22.Text = Config.registers[26].ToString();
            textBox23.Text = Config.registers[25].ToString();
            textBox24.Text = Config.registers[24].ToString();
            textBox25.Text = Config.registers[23].ToString();
            textBox26.Text = Config.registers[22].ToString();
            textBox27.Text = Config.registers[21].ToString();
            textBox28.Text = Config.registers[20].ToString();
            textBox29.Text = Config.registers[19].ToString();
            textBox30.Text = Config.registers[18].ToString();
            textBox31.Text = Config.registers[17].ToString();
            textBox32.Text = Config.registers[16].ToString();


            textBox33.Text = Config.ACC.ToString();
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
    }
}
