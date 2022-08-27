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

namespace InventorySystem1._0
{
    public partial class Repnas : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source =.; Initial Catalog = Real; Integrated Security = True");

        //SqlConnection con = new SqlConnection(@"Data Source=MOSA-PC\SQLEXPRESS;Initial Catalog=aserzamzam12;Integrated Security=True");
        SqlCommand cm = new SqlCommand();
        SqlDataReader dr;
        public Repnas()
        {
            InitializeComponent();
            LoadCustomer();
        }
        public void LoadCustomer()
        {
            double total = 0;
            int i = 0;
            dgvCustomer.Rows.Clear();
            cm = new SqlCommand("SELECT nid, date , price , dec FROM nas", con);
            //cm.Parameters.AddWithValue("@fdn", dateTimePicker1.Value.Date);
            //cm.Parameters.AddWithValue("@sdn", dateTimePicker2.Value.Date);
            con.Open();
            dr = cm.ExecuteReader();
            while (dr.Read())
            {
                i++;
                dgvCustomer.Rows.Add(i, dr[0].ToString(), dr[1].ToString(), dr[2].ToString(), dr[3].ToString());
                total += Convert.ToInt32(dr[2].ToString());
            }
            dr.Close();
            con.Close();
            label5.Text = total.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            double total = 0;
            int i = 0;
            dgvCustomer.Rows.Clear();
            cm = new SqlCommand("SELECT   nid, date , price , dec FROM nas where date between @fdn and @sdn", con);
            cm.Parameters.AddWithValue("@fdn", dateTimePicker2.Value.Date);
            cm.Parameters.AddWithValue("@sdn", dateTimePicker3.Value.Date);
            con.Open();
            dr = cm.ExecuteReader();
            while (dr.Read())
            {
                i++;
                dgvCustomer.Rows.Add(i, dr[0].ToString(), dr[1].ToString(), dr[2].ToString(), dr[3].ToString());
                total += Convert.ToInt32(dr[2].ToString());
            }
            dr.Close();
            con.Close();
            label5.Text = total.ToString();
        }

        private void bt_Exit_Click(object sender, EventArgs e)
        {
            this.Close();

        }
    }
}
