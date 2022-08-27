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
    public partial class Nas1 : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source =.; Initial Catalog = Real; Integrated Security = True");

        //SqlConnection con = new SqlConnection(@"Data Source=MOSA-PC\SQLEXPRESS;Initial Catalog=aserzamzam12;Integrated Security=True");
        SqlCommand cm = new SqlCommand();
        SqlDataReader dr;
        public Nas1()
        {
            InitializeComponent();
            LoadCustomer();
        }
        public void LoadCustomer()
        {
            double total = 0;
            int i = 0;
            dgvCustomer.Rows.Clear();
            cm = new SqlCommand("SELECT nid, date , price , dec FROM nas1", con);
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
            btnSave.Enabled = true;
            btnUpdate.Enabled = false;
        }

        private void Nas1_Load(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click_1(object sender, EventArgs e)
        {

            btnSave.Enabled = true;
            btnUpdate.Enabled = false;
            LoadCustomer();
        }


        private void dgvCustomer_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string colName = dgvCustomer.Columns[e.ColumnIndex].Name;
            if (colName == "Edit")
            {

                lblCId.Text = dgvCustomer.Rows[e.RowIndex].Cells[1].Value.ToString();
                txtCPhone.Text = dgvCustomer.Rows[e.RowIndex].Cells[4].Value.ToString();
                txtCName.Text = dgvCustomer.Rows[e.RowIndex].Cells[3].Value.ToString();
                LoadCustomer();
                btnSave.Enabled = false;
                btnUpdate.Enabled = true;
                

            }
            else if (colName == "Delete")
            {
                if (MessageBox.Show("هل انت متاكد من حذف البيانات", "جاري الحذف", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    con.Open();
                    cm = new SqlCommand("DELETE FROM nas1 WHERE nid LIKE '" + dgvCustomer.Rows[e.RowIndex].Cells[1].Value.ToString() + "'", con);
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
            label5.Text = total.ToString();



        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtCName.Text == "")
                {
                    MessageBox.Show("  من فضلك ادخال المبلغ المخرج", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;

                }
                if (txtCPhone.Text == "")
                {
                    MessageBox.Show(" من فضلك ادخال فيما خرج المبلغ", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;

                }

                if (MessageBox.Show("هل انت متاكد من حفظ البيانات ؟  ", "جاري الحفظ", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {

                    cm = new SqlCommand("INSERT INTO nas1 (date,price,dec)VALUES(@date, @price,@dec)", con);
                    cm.Parameters.AddWithValue("@date", dateTimePicker1.Value.Date);
                    cm.Parameters.AddWithValue("@price", txtCName.Text);
                    cm.Parameters.AddWithValue("@dec", txtCPhone.Text);
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
            txtCName.Clear();
            txtCPhone.Clear();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("هل انت متاكد من تعديل البيانات  ", "جاري التعديل", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {

                    cm = new SqlCommand("UPDATE nas1 SET price= @price,dec=@cphone WHERE nid LIKE '" + lblCId.Text + "' ", con);
                    //cm.Parameters.AddWithValue("@date", dateTimePicker1.Value.Date);
                    cm.Parameters.AddWithValue("@price", txtCName.Text);
                    cm.Parameters.AddWithValue("@cphone", txtCPhone.Text);

                    //cm.Parameters.AddWithValue("@date", dateTimePicker1.Value.Date);
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
    }
}
   