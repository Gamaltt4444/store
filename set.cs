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
    public partial class set : Form
    {
        public set()
        {
            InitializeComponent();
        }
        public void closeForm()
        {
            foreach (Form frm in this.MdiChildren)
            {
                frm.Close();
            }

        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            Kast productModule = new Kast();
            productModule.ShowDialog();


            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Customer productModule = new Customer();
            productModule.ShowDialog();
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Worker productModule = new Worker();
            productModule.ShowDialog();
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Employee productModule = new Employee();
            productModule.ShowDialog();
            
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Users productModule = new Users();
            productModule.ShowDialog();
           
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Akar productModule = new Akar();
            productModule.ShowDialog();
            
        }
    }
}
