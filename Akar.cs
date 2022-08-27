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
    
    public partial class Akar : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source =.; Initial Catalog = Real; Integrated Security = True");

        //SqlConnection con = new SqlConnection(@"Data Source=MOSA-PC\SQLEXPRESS;Initial Catalog=aserzamzam12;Integrated Security=True");
        SqlCommand cm = new SqlCommand();
        SqlDataReader dr;
        public Akar()
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
            btnSave.Enabled = true;
            btnUpdate.Enabled = false;
        }
        private void btnAdd_Click_1(object sender, EventArgs e)
        {

            btnSave.Enabled = true;
            btnUpdate.Enabled = false;
            LoadCustomer();
        }

        private void dgvUser_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string colName = dgvUser.Columns[e.ColumnIndex].Name;
            if (colName == "Edit")
            {

                lblCId.Text = dgvUser.Rows[e.RowIndex].Cells[1].Value.ToString();
                txtUserName.Text = dgvUser.Rows[e.RowIndex].Cells[2].Value.ToString();
                txtFullName.Text = dgvUser.Rows[e.RowIndex].Cells[3].Value.ToString();
                textBox1.Text = dgvUser.Rows[e.RowIndex].Cells[4].Value.ToString();
                LoadCustomer();
                btnSave.Enabled = false;
                btnUpdate.Enabled = true;
               

            }
            else if (colName == "Delete")
            {
                if (MessageBox.Show("هل انت متاكد من حذف البيانات", "جاري الحذف", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    con.Open();
                    cm = new SqlCommand("DELETE FROM Akar WHERE nid LIKE '" + dgvUser.Rows[e.RowIndex].Cells[1].Value.ToString() + "'", con);
                    //dgvCustomer.Rows[e.RowIndex].Cells[3].Value.ToString() + "'", con);
                    cm.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("تم الحذف بنجاح");
                    // MessageBox.Show("ملحوظه مهم جدا يرجاء التاكد من مسح جميع بيانات الخوارج في نهاية اليوم حتي لا يتم حسبها في اليوم التالي");
                    LoadCustomer();

                }
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            double total = 0;
            int i = 0;
            dgvUser.Rows.Clear();
            cm = new SqlCommand("SELECT nid, nam ,ad, price , da1,da2 FROM Akar where da2 between @fdn and @sdn", con);
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

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtUserName.Text == "")
                {
                    MessageBox.Show("  من فضلك ادخال نوغ العقار", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;

                }
                if (txtFullName.Text == "")
                {
                    MessageBox.Show(" من فضلك ادخال عنوان العقار", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;

                }
                if (textBox1.Text == "")
                {
                    MessageBox.Show(" من فضلك ادخال سعر العقار  ", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;

                }

                if (MessageBox.Show("هل انت متاكد من حفظ البيانات ؟  ", "جاري الحفظ", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {

                    cm = new SqlCommand("INSERT INTO Akar (nam,ad,price,da1)VALUES(@nam,@ad,@price,@da1)", con);
                    cm.Parameters.AddWithValue("@da1", dateTimePicker1.Value.Date);
                    //cm.Parameters.AddWithValue("@da2", dateTimePicker2.Value.Date);
                    cm.Parameters.AddWithValue("@nam", txtUserName.Text);
                    cm.Parameters.AddWithValue("@ad", txtFullName.Text);
                    cm.Parameters.AddWithValue("@price", textBox1.Text);
                    con.Open();
                    cm.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("تم حفظ اليبانات بنجاح ");
                    Clear();
                    LoadCustomer();

                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
        public void Clear()
        {
            textBox1.Clear();
            txtFullName.Clear();
            txtUserName.Clear();

        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("هل انت متاكد من تعديل البيانات  ", "جاري التعديل", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {

                    cm = new SqlCommand("UPDATE Akar SET nam= @nam,ad=@ad,price=@price ,da2=@d2 WHERE nid LIKE '" + lblCId.Text + "' ", con);
                    cm.Parameters.AddWithValue("@nam", txtUserName.Text);
                    cm.Parameters.AddWithValue("@ad", txtFullName.Text);
                    cm.Parameters.AddWithValue("@price", textBox1.Text);
                    cm.Parameters.AddWithValue("@d2", dateTimePicker2.Value.Date);
                    con.Open();
                    cm.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("تم تعديل اليبانات بنجاح ");
                    LoadCustomer();
                    btnSave.Enabled = true;
                    Clear();


                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            Clear();
            btnSave.Enabled = true;
            btnUpdate.Enabled = false;
            LoadCustomer();
        }

        private void bt_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bt_Exit_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }
    }
    
}
