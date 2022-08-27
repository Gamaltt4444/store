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
    public partial class Customer : Form
    {

        SqlConnection con = new SqlConnection(@"Data Source =.; Initial Catalog = Real; Integrated Security = True");

        //SqlConnection con = new SqlConnection(@"Data Source=MOSA-PC\SQLEXPRESS;Initial Catalog=aserzamzam12;Integrated Security=True");
        SqlCommand cm = new SqlCommand();
        SqlDataReader dr;
        public Customer()
        {
            InitializeComponent();
            LoadCustomer();

        }

        private void Customer_Load(object sender, EventArgs e)
        {

        }
        public void cust()
        {
            double total = 0;
            double total1 = 0;
            int i = 0;
            dgvCustomer.Rows.Clear();
            cm = new SqlCommand("SELECT nid, date1 ,Wnam,Work,price,pric2,pric3,pric4,price5,dec FROM Kast where Wnam= @wnam", con);
            cm.Parameters.AddWithValue("@wnam", textBox2.Text );
            //cm.Parameters.AddWithValue("@sdn", dateTimePicker2.Value.Date);
            con.Open();
            dr = cm.ExecuteReader();
            while (dr.Read())
            {
                i++;
                dgvCustomer.Rows.Add(i, dr[0].ToString(), dr[1].ToString(), dr[2].ToString(), dr[3].ToString(), dr[4].ToString(), dr[5].ToString(), dr[6].ToString(), dr[7].ToString(), dr[8].ToString(), dr[9].ToString());
                total += Convert.ToInt32(dr[8].ToString());
                total1 += Convert.ToInt32(dr[5].ToString());
            }
            dr.Close();
            con.Close();
            label6.Text = total.ToString();
            label10.Text = total1.ToString();
        }

        public void LoadCustomer()
        {

            double total = 0;
            double total1 = 0;
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
                dgvCustomer.Rows.Add(i, dr[0].ToString(), dr[1].ToString(), dr[2].ToString(), dr[3].ToString(), dr[4].ToString(), dr[5].ToString(), dr[6].ToString(), dr[7].ToString(), dr[8].ToString(),dr[9].ToString());
                total += Convert.ToInt32(dr[8].ToString());
                total1 += Convert.ToInt32(dr[5].ToString());
            }
            dr.Close();
            con.Close();
            label6.Text = total.ToString();
            label10.Text = total1.ToString();
            btnSave.Enabled = true;
            btnUpdate.Enabled = false;

        }
        public void Kat()
        {
            if (textBox1.Text == "" && txtCName.Text == "")
            {
                label13.Text = "0";
                M.Text = "0";
                p2.Text = "0";
                //textBox2.Text = "0";


            }
            else
            {

                double t1 = Convert.ToInt32(textBox1.Text);
                double t2 = Convert.ToInt32(txtCPhone.Text);
                double t3 = t1 / t2;
                double t4 = t1 - t2;
                double t5 = t3 ;
                label13.Text = t3.ToString();
                M.Text = t5.ToString();
               // p2.Text = t4.ToString();
                // textBox2.Text = t4.ToString();

            }
        }
        public void Kat1()
        {
            if (textBox1.Text == "" && txtCName.Text == "")
            {
                label13.Text = "0";
                M.Text = "0";
                p2.Text = "0";
                //textBox2.Text = "0";


            }
            else
            {

                double t1 = Convert.ToInt32(textBox1.Text);
                double t2 = Convert.ToInt32(txtCPhone.Text);
                double t6 = Convert.ToInt32(p2.Text);
                double t7 = Convert.ToInt32(M.Text);
                double t3 = t1 / t2;
                double t4 = t6 - t2;
                double t5 = t3;
                label13.Text = t3.ToString();
                M.Text = t5.ToString();
                //p2.Text = t4.ToString();
                // textBox2.Text = t4.ToString();

            }
        }

        private void btnAdd_Click_1(object sender, EventArgs e)
        {


            btnSave.Enabled = true;
            btnUpdate.Enabled = false;
            LoadCustomer();
            Kat();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            double total = 0;
            double total1 = 0;
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
            }
            dr.Close();
            con.Close();
            label6.Text = total.ToString();
            label10.Text = total1.ToString();
            Kat();
            

        }

        private void dgvCustomer_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string colName = dgvCustomer.Columns[e.ColumnIndex].Name;
            if (colName == "Edit")
            {

                lblCId.Text = dgvCustomer.Rows[e.RowIndex].Cells[1].Value.ToString();
                txtCPhone.Text = dgvCustomer.Rows[e.RowIndex].Cells[5].Value.ToString();
                txtCName.Text = dgvCustomer.Rows[e.RowIndex].Cells[3].Value.ToString();
                textBox1.Text = dgvCustomer.Rows[e.RowIndex].Cells[4].Value.ToString();
                p2.Text = dgvCustomer.Rows[e.RowIndex].Cells[6].Value.ToString();
                label13.Text = dgvCustomer.Rows[e.RowIndex].Cells[7].Value.ToString();
                M.Text = dgvCustomer.Rows[e.RowIndex].Cells[8].Value.ToString();
                dec.Text = dgvCustomer.Rows[e.RowIndex].Cells[10].Value.ToString();

                btnSave.Enabled = false;
                btnUpdate.Enabled = true;
                LoadCustomer();
                btnSave.Enabled = false;
                btnUpdate.Enabled = true;


            }
            else if (colName == "Delete")
            {
                if (MessageBox.Show("هل انت متاكد من حذف البيانات", "جاري الحذف", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    con.Open();
                    cm = new SqlCommand("DELETE FROM Kast WHERE nid LIKE '" + dgvCustomer.Rows[e.RowIndex].Cells[1].Value.ToString() + "'", con);
                    //dgvCustomer.Rows[e.RowIndex].Cells[3].Value.ToString() + "'", con);
                    cm.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("تم الحذف بنجاح");
                    // MessageBox.Show("ملحوظه مهم جدا يرجاء التاكد من مسح جميع بيانات الخوارج في نهاية اليوم حتي لا يتم حسبها في اليوم التالي");
                    LoadCustomer();
                }
            }
            
            

        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            try
            {
                if (txtCName.Text == "")
                {
                    MessageBox.Show(" من فضلك ادخال اسم العميل", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;

                }
                if (txtCPhone.Text == "")
                {
                    MessageBox.Show(" من فضلك ادخال القسط الشهري", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;

                }
                if (textBox1.Text == "")
                {
                    MessageBox.Show(" من فضلك ادخال المبلغ كامل ", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;

                }

                if (MessageBox.Show("هل انت متاكد من حفظ البيانات ؟  ", "جاري الحفظ", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Kat();
                    cm = new SqlCommand("INSERT INTO Kast (date1,Wnam,Work,price,pric2,pric3,pric4,price5,dec)VALUES(@date,@Wnam,@Work,@price,@price2,@pric3,@pric4,@price5,@dec)", con);
                    cm.Parameters.AddWithValue("@date", dateTimePicker1.Value.Date);
                    cm.Parameters.AddWithValue("@Wnam",  txtCName.Text);
                    cm.Parameters.AddWithValue("@Work", textBox1.Text);
                    cm.Parameters.AddWithValue("@price", txtCPhone.Text);
                    cm.Parameters.AddWithValue("@price2", textBox1.Text);
                    //cm.Parameters.AddWithValue("@price2", p2.Text);
                    cm.Parameters.AddWithValue("@pric3", label13.Text);
                    cm.Parameters.AddWithValue("@pric4", M.Text);
                    cm.Parameters.AddWithValue("@price5", p2.Text);
                    cm.Parameters.AddWithValue("@dec", dec.Text);


                    con.Open();
                    cm.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("تم حفظ اليبانات بنجاح ");
                    LoadCustomer();
                    Clear();
                    Kat();
                    



                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

        }
        public void Clear()
        {


            txtCName.Clear();
            txtCPhone.Clear();
            textBox1.Clear();
            Kat();

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {

                if (MessageBox.Show("هل انت متاكد من تعديل البيانات  ", "جاري التعديل", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Kat1();

                    cm = new SqlCommand("UPDATE Kast SET date1=@date, Wnam= @Wnam,Work=@Work,price= @price,pric2=@price2 ,pric3= @price3,pric4=@pric4,price5=@price5,dec=@dec WHERE nid LIKE '" + lblCId.Text + "' ", con);
                    cm.Parameters.AddWithValue("@date", dateTimePicker1.Value.Date);
                    cm.Parameters.AddWithValue("@Wnam", txtCName.Text);
                    cm.Parameters.AddWithValue("@Work", textBox1.Text);
                    cm.Parameters.AddWithValue("@price", txtCPhone.Text);
                    cm.Parameters.AddWithValue("@pric4", M.Text);
                    cm.Parameters.AddWithValue("@price2", textBox1.Text);
                    //cm.Parameters.AddWithValue("@price", txtCName.Text);
                    //cm.Parameters.AddWithValue("@price2", p2.Text);
                    cm.Parameters.AddWithValue("@price3", label13.Text);
                    cm.Parameters.AddWithValue("@price5", label6.Text);
                    //cm.Parameters.AddWithValue("@p", Convert.ToInt32(label18.Text));
                    cm.Parameters.AddWithValue("@dec", dec.Text);
                    //cm.Parameters.AddWithValue("@price4", M.Text);

                    //cm = new SqlCommand("UPDATE Kast SET  WHERE nid LIKE '" + lblCId.Text + "' ", con);
                    // cm.Parameters.AddWithValue("@price", Convert.ToInt32(txtCName.Text));
                    //cm = new SqlCommand("UPDATE Kast SET pric2=(pric2-@p1) WHERE nid LIKE '" + lblCId.Text + "' ", con);
                    //cm.Parameters.AddWithValue("@p1", Convert.ToInt32(txtCName.Text));
                    // cm = new SqlCommand("UPDATE Kast SET pric4=(pric4-@p) WHERE nid LIKE '" + lblCId.Text + "' ", con);
                    //cm.Parameters.AddWithValue("@p", Convert.ToInt32(label18.Text));
                    con.Open();
                    cm.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("تم تعديل اليبانات بنجاح ");
                    LoadCustomer();
                    
                    Clear();

                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            btnSave.Enabled = true;
            btnUpdate.Enabled = false;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            Clear();
            btnSave.Enabled = true;
            btnUpdate.Enabled = false;
            LoadCustomer();
            Kat();
        }

        private void bt_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bt_Exit_Click_1(object sender, EventArgs e)
        {
            this.Close();

        }

        private void label19_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            Kast cust = new Kast();
            cust.txtCPhone.Text = txtCPhone.Text;
            this.Close();
            cust.ShowDialog();
            


        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            cust();
        }

        private void label21_Click(object sender, EventArgs e)
        {

        }
    }
}
