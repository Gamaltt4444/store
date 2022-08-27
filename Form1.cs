using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using InventorySystem1._0.Properties;

namespace InventorySystem1._0
{
    public partial class Form1 : Form
    {
        public Form1()
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
      
     

        public void enabled_menu()
        {
           tool1.Enabled = true;
            tool2.Enabled = true;
            tool3.Enabled = true;
            tool4.Enabled = true;
            tool5.Enabled = true;
            tool6.Enabled = true;
            tool7.Enabled = true;
            tool8.Enabled = true;
            tool9.Enabled = true;
            tool10.Enabled = true;

            ts_ManageUsers.Enabled = true;
            ts_Report.Enabled = true;
            ts_Return.Enabled = true;
            //ts_StockOut.Enabled = true;
            ts_stocks.Enabled = true;
            ts_Login.Text = "تسجيل الخروج";
            ts_Login.Image = Resources.lock_open;
            ts_settings.Enabled = true;
            toolStripButton1.Enabled = true;
            toolStripButton2.Enabled = true;
            toolStripButton3.Enabled = true;
            toolStripButton4.Enabled = true;
            toolStripButton5.Enabled = true;
            toolStripButton6.Enabled = true;
            toolStripButton7.Enabled = true;
            toolStripButton16.Enabled = true;
            toolStripButton15.Enabled = true;
            toolStripButton17.Enabled = true;

        }
        public void enabled_menu1()
        {
            tool1.Enabled = true;
            tool2.Enabled = true;
            tool3.Enabled = true;
            tool4.Enabled = true;
            tool5.Enabled = true;
            tool6.Enabled = true;
            tool7.Enabled = true;
            tool8.Enabled = true;
            tool9.Enabled = true;
            tool10.Enabled = false;

            ts_ManageUsers.Enabled = false;
            ts_Report.Enabled = false;
            ts_Return.Enabled = true;
            //ts_StockOut.Enabled = true;
            ts_stocks.Enabled = true;
            ts_Login.Text = "تسجيل الخروج";
            ts_Login.Image = Resources.lock_open;
            ts_settings.Enabled = false;
            toolStripButton1.Enabled = true;
            toolStripButton2.Enabled = false;
            toolStripButton3.Enabled = true;
            toolStripButton4.Enabled = true;
            toolStripButton5.Enabled = true;
            toolStripButton6.Enabled = true;
            toolStripButton7.Enabled = true;
            toolStripButton16.Enabled = true;
            toolStripButton15.Enabled = true;
            toolStripButton17.Enabled = true;

        }
        public void disabled_menu()
        {
            tool1.Enabled = false;
            tool2.Enabled = false;
            tool3.Enabled = false;
            tool4.Enabled = false;
            tool5.Enabled = false;
            tool6.Enabled = false;
            tool7.Enabled = false;
            tool8.Enabled = false;
            tool9.Enabled = false;
            tool10.Enabled = false;

            ts_ManageUsers.Enabled = false;
            ts_Report.Enabled = false;
            ts_Return.Enabled = false;
            //ts_StockOut.Enabled = false;
            ts_stocks.Enabled = false;
            ts_Login.Text = "تسجيل الدخول";
            ts_Login.Image = Resources.login;
            ts_settings.Enabled = false;
            toolStripButton1.Enabled = false;
            toolStripButton2.Enabled = false;
            toolStripButton3.Enabled = false;
            toolStripButton4.Enabled = false;
            toolStripButton5.Enabled = false;
            toolStripButton6.Enabled = false;
            toolStripButton7.Enabled = false;
            toolStripButton16.Enabled = false;
            toolStripButton15.Enabled = false;
            toolStripButton17.Enabled = false;
        }
        public void showFrm(Form frm)
        {
            this.IsMdiContainer = true;
            frm.MdiParent = this;
            frm.Show();
        }

        private void ts_stocks_Click(object sender, EventArgs e)
        {
           // closeForm();
            //showFrm(new frmItems());
        }

        private void ts_StockOut_Click(object sender, EventArgs e)
        {
           // closeForm();
           // showFrm(new frmStockOut(""));
        }

        private void ts_Return_Click(object sender, EventArgs e)
        {
          //  closeForm();
          //  showFrm(new frmReturn());
        }

        private void ts_ManageUsers_Click(object sender, EventArgs e)
        {
           // closeForm();
            //showFrm(new frmUsers());
        }

        private void ts_Report_Click(object sender, EventArgs e)
        {
           // closeForm();
           // showFrm(new frmReport());

        }

        private void ts_Login_Click(object sender, EventArgs e)
        {
            if (ts_Login.Text == "تسجيل الدخول")
            {
                closeForm();
                showFrm(new frmLogin(this));
            }
            else
            {
                closeForm();
                disabled_menu();
                ts_Login.Text = "تسجيل الدخول";
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            disabled_menu();
            timer1.Start();
        }

        private void ts_settings_Click(object sender, EventArgs e)
        {
            //closeForm();
            //showFrm(new frmSettings());
        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void ts_Login_Click_1(object sender, EventArgs e)
        {
            if (ts_Login.Text == "تسجيل الدخول")
            {
                closeForm();
                showFrm(new frmLogin(this));
            }
            else
            {
                closeForm();
                disabled_menu();
                ts_Login.Text = "تسجيل الدخول";
            }
        }

        private void toolStripButton16_Click(object sender, EventArgs e)
        {
            closeForm();
            showFrm(new about1cs());
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lbltime.Text = DateTime.Now.ToShortTimeString();
            lbldate.Text = DateTime.Now.ToShortDateString();
        }

        private void toolStripButton7_Click(object sender, EventArgs e)
        {
            closeForm();
            showFrm(new Backup());
        }

        private void ts_settings_Click_1(object sender, EventArgs e)
        {
            closeForm();
            showFrm(new set());
        }

        private void toolStripButton16_Click_1(object sender, EventArgs e)
        {
            closeForm();
            showFrm(new about1cs());
        }

        private void ts_ManageUsers_Click_1(object sender, EventArgs e)
        {
            closeForm();
            showFrm(new Users());
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            closeForm();
            showFrm(new Nas());

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            closeForm();
            showFrm(new Akar());
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            closeForm();
            showFrm(new Worker());
        
    }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            closeForm();
            showFrm(new Employee());
        }

        private void ts_Return_Click_1(object sender, EventArgs e)
        {
            closeForm();
            showFrm(new Kast());
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            closeForm();
            showFrm(new Customer());
        }

        private void ts_stocks_Click_1(object sender, EventArgs e)
        {
            closeForm();
            showFrm(new company1());
        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            closeForm();
            showFrm(new Kasm());
        }

        private void toolStripButton17_Click(object sender, EventArgs e)
        {
            closeForm();
            showFrm(new Addwcs());
        }

        private void toolStripButton15_Click(object sender, EventArgs e)
        {
            closeForm();
            showFrm(new Dit());

        }

        private void ts_StockOut_Click_1(object sender, EventArgs e)
        {
            
                
            
        }

        private void tool1_Click(object sender, EventArgs e)
        {
            
        }

        private void tool3_Click(object sender, EventArgs e)
        {
            closeForm();
            showFrm(new Catg());

        }

        private void tool2_Click(object sender, EventArgs e)
        {
            closeForm();
            showFrm(new Prod());
        }

        private void ts_Report_Click_1(object sender, EventArgs e)
        {

        }

        private void PurchaseEntryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            closeForm();
            showFrm(new Rep());

        }

        private void PurchaseReturnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            closeForm();
            showFrm(new Repnas());
        }

        private void تقاريرالعقاراتToolStripMenuItem_Click(object sender, EventArgs e)
        {
            closeForm();
            showFrm(new Repaka());
        }

        private void تقاريرالاربجToolStripMenuItem_Click(object sender, EventArgs e)
        {
            closeForm();
            showFrm(new Repara());
        }

        private void تقاريرتحصيلاتالعمالToolStripMenuItem_Click(object sender, EventArgs e)
        {
            closeForm();
            showFrm(new Worker());
        }

        private void tool4_Click(object sender, EventArgs e)
        {
            closeForm();
            showFrm(new mad());
        }

        private void tool5_Click(object sender, EventArgs e)
        {
            closeForm();
            showFrm(new cust1());
        }

        private void tool6_Click(object sender, EventArgs e)
        {
            closeForm();
            showFrm(new mord());
        }

        private void tool9_Click(object sender, EventArgs e)
        {
            closeForm();
            showFrm(new Nas1());
        }

        private void tool10_Click(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem11_Click(object sender, EventArgs e)
        {
            closeForm();
            showFrm(new Sales());
        }

        private void toolStripMenuItem13_Click(object sender, EventArgs e)
        {
            closeForm();
            showFrm(new buys());

        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            closeForm();
            showFrm(new sal());
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            closeForm();
            showFrm(new Nas1());
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            closeForm();
            showFrm(new pror());
        }

        private void toolStripMenuItem6_Click(object sender, EventArgs e)
        {
            closeForm();
            showFrm(new buy());

        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            closeForm();
            showFrm(new Srapcs());
        }

        private void tool7_Click(object sender, EventArgs e)
        {
            closeForm();
            showFrm(new Back1());
        }

        private void تقريرالمرتجعاتToolStripMenuItem_Click(object sender, EventArgs e)
        {
            closeForm();
            showFrm(new Back2());
        }

        private void lbltime_Click(object sender, EventArgs e)
        {

        }
    }
}
