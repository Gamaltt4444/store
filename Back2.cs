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
    public partial class Back2 : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=.;Initial Catalog=Real;Integrated Security=True");
        SqlCommand cm = new SqlCommand();
        SqlDataReader dr;
        public Back2()
        {
            InitializeComponent();
            bu();
            bu1();
        }
        public void bu()
        {
            int n = 0;
            double total = 0;
            double tota2 = 0;
            dgvOrder.Rows.Clear();
            cm = new SqlCommand("SELECT * FROM tbBack  WHERE odate between @fd and @sd ", con);
            cm.Parameters.AddWithValue("@fd", dateTimePicker2.Value.Date);
            cm.Parameters.AddWithValue("@sd", dateTimePicker3.Value.Date);
            con.Open();
            dr = cm.ExecuteReader();
            while (dr.Read())
            {
                n++;
                dgvOrder.Rows.Add(n, dr[0].ToString(), Convert.ToDateTime(dr[1].ToString()).ToString("dd/MM/yyyy"), dr[2].ToString(), dr[3].ToString(), dr[4].ToString(), dr[5].ToString(), dr[6].ToString(), dr[7].ToString(), dr[8].ToString());
                total += Convert.ToInt32(dr[8].ToString());
                tota2 += Convert.ToInt32(dr[6].ToString());
            }
            dr.Close();
            con.Close();
            label4.Text = n.ToString();
            label5.Text = total.ToString();
            label9.Text = tota2.ToString();
        }
        public void bu1()
        {
            int n = 0;
            double total = 0;
            double tota2 = 0;
            dgvOrder.Rows.Clear();
            cm = new SqlCommand("SELECT * FROM tbBack where Mnam =@mad and odate between @fd and @sd", con);
            cm.Parameters.AddWithValue("@mad", txtSearch.Text);
            cm.Parameters.AddWithValue("@fd", dateTimePicker2.Value.Date);
            cm.Parameters.AddWithValue("@sd", dateTimePicker3.Value.Date);
            con.Open();
            dr = cm.ExecuteReader();
            while (dr.Read())
            {
                n++;
                dgvOrder.Rows.Add(n, dr[0].ToString(), Convert.ToDateTime(dr[1].ToString()).ToString("dd/MM/yyyy"), dr[2].ToString(), dr[3].ToString(), dr[4].ToString(), dr[5].ToString(), dr[6].ToString(), dr[7].ToString(), dr[8].ToString());
                total += Convert.ToInt32(dr[8].ToString());
                tota2 += Convert.ToInt32(dr[6].ToString());
            }
            dr.Close();
            con.Close();
            label4.Text = n.ToString();
            label5.Text = total.ToString();
            label9.Text = tota2.ToString();
        }


        private void bt_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bt_Exit_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            bu();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            bu1();
        }
    }
}
