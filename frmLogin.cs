using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using InventorySystem1._0.Includes;

namespace InventorySystem1._0
{
       public partial class frmLogin : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source =.; Initial Catalog = Real; Integrated Security = True");
        //SqlConnection con = new SqlConnection(@"Data Source=MOSA-PC\SQLEXPRESS;Initial Catalog=aserzamzam12;Integrated Security=True");
        SqlCommand cm = new SqlCommand();
        SqlDataReader dr;
        Form1 frm;
        public frmLogin(Form1 frm)
        {
            InitializeComponent();

            this.frm = frm;
        }
        //SQLConfig config = new SQLConfig();
        string sql;

        private void Timer1_Tick(object sender, EventArgs e)
        {
            lbltime.Text = DateTime.Now.ToShortTimeString();
            lbldate.Text = DateTime.Now.ToShortDateString();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            Timer1.Start();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            try
            {

                cm = new SqlCommand("SELECT * FROM tbUser WHERE username=@username AND password=@password", con);
                cm.Parameters.AddWithValue("@username", txtpass.Text);
                cm.Parameters.AddWithValue("@password", txtuse.Text);
                con.Open();
                dr = cm.ExecuteReader();
                dr.Read();
                if (dr.HasRows)
                {

                    MessageBox.Show("مرحبا " + dr["fullname"].ToString() + "  ", "تم التسجيل بنجاح ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    frm.enabled_menu();
                    this.Close();

                }

                else
                {
                    MessageBox.Show("!خطأ فى كلمه السر او اسم المستخدم", " فشل التسجيل ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                con.Close();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

            
            

        }

        private void Button2_Click(object sender, EventArgs e)
        {
            txtuse.Clear();
            txtpass.Clear();
            txtpass.Focus();
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lbltime_Click(object sender, EventArgs e)
        {

        }

        private void Button1_Click_1(object sender, EventArgs e)
        {
            try
            {

                cm = new SqlCommand("SELECT * FROM tbUser WHERE username=@username AND password=@password", con);
                cm.Parameters.AddWithValue("@username", txtuse.Text); 
                cm.Parameters.AddWithValue("@password", txtpass .Text);
                con.Open();
                dr = cm.ExecuteReader();
                dr.Read();
                if (dr.HasRows)
                {

                    MessageBox.Show("مرحبا " + dr["fullname"].ToString() + "  ", "تم التسجيل بنجاح ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    textBox1.Text = dr["Rol"].ToString();
                    if (textBox1.Text == "Admin")
                    {
                        frm.enabled_menu();
                        this.Close();
                    }
                    else
                    {
                        frm.enabled_menu1();
                        this.Close();
                       

                    }
                    

                }

                else
                {
                    MessageBox.Show("!خطأ فى كلمه السر او اسم المستخدم", " فشل التسجيل ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                con.Close();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }



        }

        private void Button3_Click_1(object sender, EventArgs e)
        {
            this.Close();

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            txtuse.Clear();
            txtpass.Clear();
            txtpass.Focus();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
