using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InventorySystem1._0
{
    public partial class Dit : Form
    {
        public Dit()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            
            pictureBox1.Visible = false;
            pictureBox2.Visible = true;
            pictureBox3.Visible = false;
            pictureBox4.Visible = false;
            pictureBox5.Visible = false;
            button1.Visible = false;
           button2.Visible = true;
            button3.Visible = false;
            button5.Visible = false;
            button6.Visible = false;
            button1.Visible = false;
            button5.Visible = false;
            button7.Visible = false;
            button8.Visible = true;
            button9.Visible = false;


        }

        private void button3_Click(object sender, EventArgs e)
        {
            pictureBox1.Visible = false;
            pictureBox2.Visible = false;
            pictureBox3.Visible = false;
            pictureBox4.Visible = true;
            pictureBox5.Visible = false;
            button1.Visible = false;
            button2.Visible = false;
           button3.Visible = false;
           button6.Visible = true;
            button5.Visible = false;
            //button5.Visible = false;
            button7.Visible = true;
            button8.Visible = false;
            button9.Visible = false;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            pictureBox1.Visible = false;
            pictureBox2.Visible = false;
            pictureBox3.Visible = true;
            pictureBox4.Visible = false;
            pictureBox5.Visible = false;
            button1.Visible = false;
            button2.Visible = false;
             button3.Visible = true;
           //button5.Visible = false;
            button6.Visible = false;
            button5.Visible = false;
            button7.Visible = false;
            button8.Visible = true;
            button9.Visible = false;
            //button2.Visible = false;

        }

        private void button6_Click(object sender, EventArgs e)
        {
            pictureBox1.Visible = false;
            pictureBox2.Visible = false;
            pictureBox3.Visible = false;
            pictureBox4.Visible = false;
            pictureBox5.Visible = true;
            button1.Visible = false;
            button2.Visible = false;
            button3.Visible = false;
            button5.Visible = true;
            button6.Visible = true;
            //button5.Visible = false;
            //button5.Visible = false;
            button7.Visible = false;
            button8.Visible = false;
            button9.Visible = false;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            pictureBox1.Visible = false;
            pictureBox2.Visible = false;
            pictureBox3.Visible = false;
            pictureBox4.Visible = true;
            pictureBox5.Visible = false;
            button1.Visible = false;
            button2.Visible = false;
            button3.Visible = false;
            button6.Visible = true;
            button5.Visible = false;
            button7.Visible = true;
            button8.Visible = false;
            button9.Visible = false;


        }

        private void button7_Click(object sender, EventArgs e)
        {
            pictureBox1.Visible = false;
            pictureBox2.Visible = false;
            pictureBox3.Visible = true;
            pictureBox4.Visible = false;
            pictureBox5.Visible = false;
            button1.Visible = false;
            button2.Visible = false;
            button3.Visible = true;
            //button5.Visible = false;
            button6.Visible = false;
            button5.Visible = false;
            button7.Visible = false;
            button8.Visible = true;
            button9.Visible = false;
            //button2.Visible = false;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            pictureBox1.Visible = false;
            pictureBox2.Visible = true;
            pictureBox3.Visible = false;
            pictureBox4.Visible = false;
            pictureBox5.Visible = false;
            button1.Visible = false;
            button2.Visible = true;
            button3.Visible = false;
           // button5.Visible = false;
            button6.Visible = false;
            button1.Visible = false;
            button5.Visible = false;
            button7.Visible = false;
            button8.Visible = false;
            button9.Visible = true;
        

    }

        private void button9_Click(object sender, EventArgs e)
        {
            pictureBox1.Visible = true;
            pictureBox2.Visible = false;
            pictureBox3.Visible = false;
            pictureBox4.Visible = false;
            pictureBox5.Visible = false;
            button1.Visible = true;
            button2.Visible = false;
            button3.Visible = false;
            // button5.Visible = false;
            button6.Visible = false;
            //button1.Visible = false;
            button5.Visible = false;
            button7.Visible = false;
            button8.Visible = false;
            button9.Visible = true;
        }
    }
}
