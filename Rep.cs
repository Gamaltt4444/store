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
    public partial class Rep : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source =.; Initial Catalog = Real; Integrated Security = True");

        //SqlConnection con = new SqlConnection(@"Data Source=MOSA-PC\SQLEXPRESS;Initial Catalog=aserzamzam12;Integrated Security=True");
        SqlCommand cm = new SqlCommand();
        SqlDataReader dr;
        public Rep()
        {
            InitializeComponent();
            LoadCustomer();
        }
        public void cust()
        {
            double total = 0;
            double total1 = 0;
            double total2 = 0;
            double total3 = 0;
            int i = 0;
            dgvCustomer.Rows.Clear();
            cm = new SqlCommand("SELECT nid, date1 ,Wnam,Work,price,pric2,pric3,pric4,price5,dec FROM Kast where Wnam= @wnam", con);
            cm.Parameters.AddWithValue("@wnam", textBox2.Text);
            //cm.Parameters.AddWithValue("@sdn", dateTimePicker2.Value.Date);
            con.Open();
            dr = cm.ExecuteReader();
            while (dr.Read())
            {
                i++;
                dgvCustomer.Rows.Add(i, dr[0].ToString(), dr[1].ToString(), dr[2].ToString(), dr[3].ToString(), dr[4].ToString(), dr[5].ToString(), dr[6].ToString(), dr[7].ToString(), dr[8].ToString(), dr[9].ToString());
                total += Convert.ToInt32(dr[8].ToString());
                total1 += Convert.ToInt32(dr[5].ToString());
                total2 += Convert.ToInt32(dr[3].ToString());
                total3 += Convert.ToInt32(dr[7].ToString());


            }
            dr.Close();
            con.Close();
            label6.Text = total.ToString();
            label10.Text = total1.ToString();
            label1.Text = total2.ToString();
            label5.Text = total3.ToString();
        }
        public void LoadCustomer()
        {
            double total = 0;
            double total1 = 0;
            double total2 = 0;
            double total3 = 0;
            int i = 0;
            dgvCustomer.Rows.Clear();
            cm = new SqlCommand("SELECT nid, date1 ,Wnam,Work,price,pric2,pric3,pric4,price5,dec FROM Kast ", con);
            //cm.Parameters.AddWithValue("@fdn", dateTimePicker1.Value.Date);
            //cm.Parameters.AddWithValue("@sdn", dateTimePicker2.Value.Date);
            con.Open();
            dr = cm.ExecuteReader();
            while (dr.Read())
            {
                i++;
                dgvCustomer.Rows.Add(i, dr[0].ToString(), dr[1].ToString(), dr[2].ToString(), dr[3].ToString(), dr[4].ToString(), dr[5].ToString(), dr[6].ToString(), dr[7].ToString(), dr[8].ToString(), dr[9].ToString());
                total += Convert.ToInt32(dr[8].ToString());
                total1 += Convert.ToInt32(dr[5].ToString());
                total2 += Convert.ToInt32(dr[3].ToString());
                total3 += Convert.ToInt32(dr[7].ToString());
            }
            dr.Close();
            con.Close();
            label6.Text = total.ToString();
            label10.Text = total1.ToString();
            label1.Text = total2.ToString();
            label5.Text = total3.ToString();

        }

        private void Rep_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            double total = 0;
            double total1 = 0;
            double total2 = 0;
            double total3 = 0;
            int i = 0;
            dgvCustomer.Rows.Clear();
            cm = new SqlCommand("SELECT nid, date1 ,Wnam,Work, price,pric2,pric3,pric4,price5,dec  FROM Kast where date between @fdn and @sdn", con);
            cm.Parameters.AddWithValue("@fdn", dateTimePicker2.Value.Date);
            cm.Parameters.AddWithValue("@sdn", dateTimePicker3.Value.Date);
            con.Open();
            dr = cm.ExecuteReader();
            while (dr.Read())
            {
                i++;
                dgvCustomer.Rows.Add(i, dr[0].ToString(), dr[1].ToString(), dr[2].ToString(), dr[3].ToString(), dr[4].ToString(), dr[5].ToString(), dr[6].ToString(), dr[7].ToString(), dr[8].ToString(), dr[9].ToString());
                total += Convert.ToInt32(dr[8].ToString());
                total1 += Convert.ToInt32(dr[5].ToString());
                total2 += Convert.ToInt32(dr[3].ToString());
                total3 += Convert.ToInt32(dr[7].ToString());
            }
            dr.Close();
            con.Close();
            label6.Text = total.ToString();
            label10.Text = total1.ToString();
            label1.Text = total2.ToString();
            label5.Text = total3.ToString();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            cust();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Kast cust = new Kast();
            cust.txtCName.Text = txtCName.Text;
            this.Close();
            cust.ShowDialog();
        }

        private void bt_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
