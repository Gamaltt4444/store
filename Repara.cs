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
    public partial class Repara : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source =.; Initial Catalog = Real; Integrated Security = True");

        //SqlConnection con = new SqlConnection(@"Data Source=MOSA-PC\SQLEXPRESS;Initial Catalog=aserzamzam12;Integrated Security=True");
        SqlCommand cm = new SqlCommand();
        SqlDataReader dr;
        public Repara()
        {
            InitializeComponent();

        }

        private void Repara_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            double total = 0;
            int i = 0;
            dgvUser.Rows.Clear();
            cm = new SqlCommand("SELECT nid, nam ,ad, price , da1,da2 FROM Akar where da2 between @fdn and @sdn", con);
            cm.Parameters.AddWithValue("@fdn", dateTimePicker2.Value.Date);
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
            label3.Text = total.ToString();
            double total1 = 0;
            double total2 = 0;
            double total3 = 0;
            double total4 = 0;
            int n = 0;
            dgvCustomer.Rows.Clear();
            cm = new SqlCommand("SELECT nid, date1 ,Wnam,Work, price,pric2,pric3,pric4,price5,dec  FROM Kast where date between @fdn and @sdn", con);
            cm.Parameters.AddWithValue("@fdn", dateTimePicker2.Value.Date);
            cm.Parameters.AddWithValue("@sdn", dateTimePicker3.Value.Date);
            con.Open();
            dr = cm.ExecuteReader();
            while (dr.Read())
            {
                n++;
                dgvCustomer.Rows.Add(n, dr[0].ToString(), dr[1].ToString(), dr[2].ToString(), dr[3].ToString(), dr[4].ToString(), dr[5].ToString(), dr[6].ToString(), dr[7].ToString(), dr[8].ToString(), dr[9].ToString());
                total1 += Convert.ToInt32(dr[8].ToString());
                total2 += Convert.ToInt32(dr[5].ToString());
                total3 += Convert.ToInt32(dr[3].ToString());
                total4 += Convert.ToInt32(dr[7].ToString());
            }
            dr.Close();
            con.Close();
            label6.Text = total1.ToString();
            label10.Text = total2.ToString();
            label2.Text = total3.ToString();
            label5.Text = total4.ToString();

            double total5 = 0;
            int b = 0;
            dgvCustomer.Rows.Clear();
            cm = new SqlCommand("SELECT   nid, date , price , dec FROM nas where date between @fdn and @sdn", con);
            cm.Parameters.AddWithValue("@fdn", dateTimePicker2.Value.Date);
            cm.Parameters.AddWithValue("@sdn", dateTimePicker3.Value.Date);
            con.Open();
            dr = cm.ExecuteReader();
            while (dr.Read())
            {
                b++;
                dgvCustomer.Rows.Add(b, dr[0].ToString(), dr[1].ToString(), dr[2].ToString(), dr[3].ToString());
                total5 += Convert.ToInt32(dr[2].ToString());
            }
            dr.Close();
            con.Close();
            label8.Text = total5.ToString();

            double total6 = 0;
            int c = 0;
            dgvCustomer.Rows.Clear();
            cm = new SqlCommand("SELECT nid, date ,Wnam,Work, price  FROM Worker where date between @fdn and @sdn", con);
            cm.Parameters.AddWithValue("@fdn", dateTimePicker2.Value.Date);
            cm.Parameters.AddWithValue("@sdn", dateTimePicker3.Value.Date);
            con.Open();
            dr = cm.ExecuteReader();
            while (dr.Read())
            {
                c++;
                dgvCustomer.Rows.Add(c, dr[0].ToString(), dr[1].ToString(), dr[2].ToString(), dr[3].ToString(), dr[4].ToString());
                total6 += Convert.ToInt32(dr[4].ToString());
            }
            dr.Close();
            con.Close();
            label14.Text = total6.ToString();


            double total7 = 0;
            int v = 0;
            dgvCustomer.Rows.Clear();
            cm = new SqlCommand("SELECT nid, date ,Wnam,Work, price  FROM Employee where date between @fdn and @sdn", con);
            cm.Parameters.AddWithValue("@fdn", dateTimePicker2.Value.Date);
            cm.Parameters.AddWithValue("@sdn", dateTimePicker3.Value.Date);
            con.Open();
            dr = cm.ExecuteReader();
            while (dr.Read())
            {
                i++;
                dgvCustomer.Rows.Add(v, dr[0].ToString(), dr[1].ToString(), dr[2].ToString(), dr[3].ToString(), dr[4].ToString());
                total7 += Convert.ToInt32(dr[4].ToString());
            }
            dr.Close();
            con.Close();
            label22.Text = total7.ToString();
            double total8 = total1 - (total5 + total6 + total7);
            label19.Text = total8.ToString();

            double total9 = total3 - (total5 + total6 + total7);
            label26.Text = total9.ToString();

            double totall = 0;
            int g = 0;
            dataGridView6.Rows.Clear();
            cm = new SqlCommand("SELECT   nid, date , price , dec FROM nas1 where date between @fdn and @sdn", con);
            cm.Parameters.AddWithValue("@fdn", dateTimePicker2.Value.Date);
            cm.Parameters.AddWithValue("@sdn", dateTimePicker3.Value.Date);
            con.Open();
            dr = cm.ExecuteReader();
            while (dr.Read())
            {
                g++;
                dataGridView6.Rows.Add(g, dr[0].ToString(), dr[1].ToString(), dr[2].ToString(), dr[3].ToString());
                totall += Convert.ToInt32(dr[2].ToString());
            }
            dr.Close();
            con.Close();
            // Nas.Text = total.ToString();

            double tota11 = 0;
            double tota21 = 0;
            //double total5 = 0;



            int d = 0;
            dgvOrder1.Rows.Clear();
            cm = new SqlCommand("SELECT iddd, odate, O.pid, P.pname, O.cid, C.pname, qty, price, total  FROM tbOrder AS O JOIN cust1 AS C ON O.cid=C.pid JOIN tbProduct AS P ON O.pid=P.pid WHERE odate between @fd and @sd ", con);
            cm.Parameters.AddWithValue("@fd", dateTimePicker2.Value.Date);
            cm.Parameters.AddWithValue("@sd", dateTimePicker3.Value.Date);
            con.Open();
            dr = cm.ExecuteReader();
            while (dr.Read())
            {
                d++;
                dgvOrder1.Rows.Add(d, dr[0].ToString(), Convert.ToDateTime(dr[1].ToString()).ToString("dd/MM/yyyy"), dr[2].ToString(), dr[3].ToString(), dr[4].ToString(), dr[5].ToString(), dr[6].ToString(), dr[7].ToString(), dr[8].ToString());
                tota11 += Convert.ToInt32(dr[8].ToString());
                tota21 += Convert.ToInt32(dr[6].ToString());
                //double total3 += Convert.ToInt32(dr[8].ToString());
                //double total4 += Convert.ToInt32(dr[6].ToString());
                //total5 = total3 - total4;


            }
            dr.Close();
            con.Close();
            // T.Text = n.ToString();
            // Sal.Text = tota1.ToString();
            // Q.Text = tota2.ToString();


            int m = 0;
            double tota31 = 0;
            double tota41 = 0;
            dataGridView4.Rows.Clear();
            cm = new SqlCommand("SELECT * FROM tbBuy  WHERE odate between @fd and @sd ", con);
            cm.Parameters.AddWithValue("@fd", dateTimePicker2.Value.Date);
            cm.Parameters.AddWithValue("@sd", dateTimePicker3.Value.Date);
            con.Open();
            dr = cm.ExecuteReader();
            while (dr.Read())
            {
                m++;
                dataGridView4.Rows.Add(m, dr[0].ToString(), Convert.ToDateTime(dr[1].ToString()).ToString("dd/MM/yyyy"), dr[2].ToString(), dr[3].ToString(), dr[4].ToString(), dr[5].ToString(), dr[6].ToString(), dr[7].ToString(), dr[8].ToString());
                tota31 += Convert.ToInt32(dr[8].ToString());
                tota41 += Convert.ToInt32(dr[6].ToString());
            }
            dr.Close();
            con.Close();
           // T1.Text = b.ToString();
            //Buy.Text = tota3.ToString();
            //Q1.Text = tota4.ToString();


            int j = 0;
            double total51 = 0;
            double total61 = 0;
            dataGridView5.Rows.Clear();
            cm = new SqlCommand("SELECT * FROM tbBack WHERE odate between @fd and @sd ", con);
            cm.Parameters.AddWithValue("@fd", dateTimePicker2.Value.Date);
            cm.Parameters.AddWithValue("@sd", dateTimePicker3.Value.Date);
            con.Open();
            dr = cm.ExecuteReader();
            while (dr.Read())
            {
                j++;
                dataGridView5.Rows.Add(j, dr[0].ToString(), dr[1].ToString(), dr[2].ToString(), dr[3].ToString(), dr[4].ToString(), dr[5].ToString(), dr[6].ToString(), dr[7].ToString(), dr[8].ToString());
                total51 += Convert.ToInt32(dr[8].ToString());
                total61 += Convert.ToInt32(dr[6].ToString());
            }
            dr.Close();
            con.Close();
            //Back.Text = total5.ToString();
            //TB.Text = c.ToString();
            //QB.Text = total6.ToString();
            double tot = (tota11 + total51) - (totall + tota31);
            Tot.Text = tot.ToString();
            double totalmm = tot + total9;
            label21.Text = totalmm.ToString();


        }

        private void bt_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
