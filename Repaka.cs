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
    public partial class Repaka : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source =.; Initial Catalog = Real; Integrated Security = True");

        //SqlConnection con = new SqlConnection(@"Data Source=MOSA-PC\SQLEXPRESS;Initial Catalog=aserzamzam12;Integrated Security=True");
        SqlCommand cm = new SqlCommand();
        SqlDataReader dr;
        public Repaka()
        {
            InitializeComponent();
            LoadCustomer();
        }
        public void LoadCustomer()
        {
            double total = 0;
            int i = 0;
            dgvUser.Rows.Clear();
            cm = new SqlCommand("SELECT nid, nam ,ad, price , da1,da2 FROM Akar", con);
            //cm.Parameters.AddWithValue("@fdn", dateTimePicker1.Value.Date);
            //cm.Parameters.AddWithValue("@sdn", dateTimePicker2.Value.Date);
            con.Open();
            dr = cm.ExecuteReader();
            while (dr.Read())
            {
                i++;
                dgvUser.Rows.Add(i, dr[0].ToString(), dr[1].ToString(), dr[2].ToString(), dr[3].ToString(), dr[4].ToString(), dr[5].ToString());
                total += Convert.ToInt32(dr[3].ToString());
            }
            dr.Close();
            con.Close();
            label9.Text = total.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            double total = 0;
            int i = 0;
            dgvUser.Rows.Clear();
            cm = new SqlCommand("SELECT nid, nam ,ad, price , da1,da2 FROM Akar where da1 between @fdn and @sdn", con);
            cm.Parameters.AddWithValue("@fdn", dateTimePicker4.Value.Date);
            cm.Parameters.AddWithValue("@sdn", dateTimePicker3.Value.Date);
            con.Open();
            dr = cm.ExecuteReader();
            while (dr.Read())
            {
                i++;
                dgvUser.Rows.Add(i, dr[0].ToString(), dr[1].ToString(), dr[2].ToString(), dr[3].ToString(), dr[4].ToString(), dr[5].ToString());
                total += Convert.ToInt32(dr[3].ToString());
            }
            dr.Close();
            con.Close();
            label9.Text = total.ToString();
        }

        private void bt_Exit_Click(object sender, EventArgs e)
        {
            this.Close();

        }
    }
}
