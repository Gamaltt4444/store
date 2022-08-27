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
    public partial class Srapcs : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source =.; Initial Catalog = Real; Integrated Security = True");

        //SqlConnection con = new SqlConnection(@"Data Source=MOSA-PC\SQLEXPRESS;Initial Catalog=aserzamzam12;Integrated Security=True");
        SqlCommand cm = new SqlCommand();
        SqlDataReader dr;
        public Srapcs()
        {
            InitializeComponent();
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

            double total = 0;
            int i = 0;
            dgvCustomer.Rows.Clear();
            cm = new SqlCommand("SELECT   nid, date , price , dec FROM nas1 where date between @fdn and @sdn", con);
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
            Nas.Text = total.ToString();

            double tota1 = 0;
            double tota2 = 0;
            //double total5 = 0;



            int n = 0;
            dgvOrder.Rows.Clear();
            cm = new SqlCommand("SELECT iddd, odate, O.pid, P.pname, O.cid, C.pname, qty, price, total  FROM tbOrder AS O JOIN cust1 AS C ON O.cid=C.pid JOIN tbProduct AS P ON O.pid=P.pid WHERE odate between @fd and @sd ", con);
            cm.Parameters.AddWithValue("@fd", dateTimePicker2.Value.Date);
            cm.Parameters.AddWithValue("@sd", dateTimePicker3.Value.Date);
            con.Open();
            dr = cm.ExecuteReader();
            while (dr.Read())
            {
                n++;
                dgvOrder.Rows.Add(i, dr[0].ToString(), Convert.ToDateTime(dr[1].ToString()).ToString("dd/MM/yyyy"), dr[2].ToString(), dr[3].ToString(), dr[4].ToString(), dr[5].ToString(), dr[6].ToString(), dr[7].ToString(), dr[8].ToString());
                tota1 += Convert.ToInt32(dr[8].ToString());
                tota2 += Convert.ToInt32(dr[6].ToString());
                //double total3 += Convert.ToInt32(dr[8].ToString());
                //double total4 += Convert.ToInt32(dr[6].ToString());
                //total5 = total3 - total4;


            }
            dr.Close();
            con.Close();
            T.Text = n.ToString();
            Sal.Text = tota1.ToString();
            Q.Text = tota2.ToString();

            int b = 0;
            double tota3 = 0;
            double tota4 = 0;
            dataGridView1.Rows.Clear();
            cm = new SqlCommand("SELECT * FROM tbBuy  WHERE odate between @fd and @sd ", con);
            cm.Parameters.AddWithValue("@fd", dateTimePicker2.Value.Date);
            cm.Parameters.AddWithValue("@sd", dateTimePicker3.Value.Date);
            con.Open();
            dr = cm.ExecuteReader();
            while (dr.Read())
            {
                b++;
                dgvOrder.Rows.Add(b, dr[0].ToString(), Convert.ToDateTime(dr[1].ToString()).ToString("dd/MM/yyyy"), dr[2].ToString(), dr[3].ToString(), dr[4].ToString(), dr[5].ToString(), dr[6].ToString(), dr[7].ToString(), dr[8].ToString());
                tota3 += Convert.ToInt32(dr[8].ToString());
                tota4 += Convert.ToInt32(dr[6].ToString());
            }
            dr.Close();
            con.Close();
            T1.Text = b.ToString();
            Buy.Text = tota3.ToString();
            Q1.Text = tota4.ToString();


            int c = 0;
            double total5 = 0;
            double total6 = 0;
            dataGridView2.Rows.Clear();
            cm = new SqlCommand("SELECT * FROM tbBack WHERE odate between @fd and @sd ", con);
            cm.Parameters.AddWithValue("@fd", dateTimePicker2.Value.Date);
            cm.Parameters.AddWithValue("@sd", dateTimePicker3.Value.Date);
            con.Open();
            dr = cm.ExecuteReader();
            while (dr.Read())
            {
                c++;
                dgvOrder.Rows.Add(n, dr[0].ToString(), dr[1].ToString(), dr[2].ToString(), dr[3].ToString(), dr[4].ToString(), dr[5].ToString(), dr[6].ToString(), dr[7].ToString(), dr[8].ToString());
                total5 += Convert.ToInt32(dr[8].ToString());
                total6 += Convert.ToInt32(dr[6].ToString());
            }
            dr.Close();
            con.Close();
            Back.Text = total5.ToString();
            TB.Text = c.ToString();
            QB.Text = total6.ToString();
            double tot = (tota1 + total5) - (total + tota3);
            Tot.Text = tot.ToString();

        }
    }
}
