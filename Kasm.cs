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
    public partial class Kasm : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source =.; Initial Catalog = Real; Integrated Security = True");

        //SqlConnection con = new SqlConnection(@"Data Source=MOSA-PC\SQLEXPRESS;Initial Catalog=aserzamzam12;Integrated Security=True");
        SqlCommand cm = new SqlCommand();
        SqlDataReader dr;
        public Kasm()
        {
            InitializeComponent();
            LoadCustomer();
        }
        public void LoadCustomer()
        {
            int i = 0;
            dgvCustomer.Rows.Clear();
            cm = new SqlCommand("SELECT nid,Nam , Mas , dec FROM Kas", con);
            //cm.Parameters.AddWithValue("@fdn", dateTimePicker1.Value.Date);
            //cm.Parameters.AddWithValue("@sdn", dateTimePicker2.Value.Date);
            con.Open();
            dr = cm.ExecuteReader();
            while (dr.Read())
            {
                i++;
                dgvCustomer.Rows.Add(i, dr[0].ToString(), dr[1].ToString(), dr[2].ToString(), dr[3].ToString());
                
            }
            dr.Close();
            con.Close();
            btnSave.Enabled = true;
            btnUpdate.Enabled = false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtCName.Text == "")
                {
                    MessageBox.Show("  من فضلك ادخال اسم القسم", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;

                }
                if (txtCPhone.Text == "")
                {
                    MessageBox.Show("من فضلك ادخال  المسؤل", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;

                }
                

                if (MessageBox.Show("هل انت متاكد من حفظ البيانات ؟  ", "جاري الحفظ", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {

                    cm = new SqlCommand("INSERT INTO Kas (Nam,Mas,dec)VALUES(@date, @price,@dec)", con);
                    cm.Parameters.AddWithValue("@date", txtCName.Text);
                    cm.Parameters.AddWithValue("@price", txtCPhone.Text);
                    cm.Parameters.AddWithValue("@dec", textBox1.Text);
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
            textBox1.Clear();
        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("هل انت متاكد من تعديل البيانات  ", "جاري التعديل", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {

                    cm = new SqlCommand("UPDATE Kas SET Nam= @price,Mas=@Mas,dec=@cphone WHERE nid LIKE '" + lblCId.Text + "' ", con);
                    //cm.Parameters.AddWithValue("@date", dateTimePicker1.Value.Date);
                    cm.Parameters.AddWithValue("@price", txtCName.Text);
                    cm.Parameters.AddWithValue("@Mas", txtCPhone.Text);
                    cm.Parameters.AddWithValue("@cphone", textBox1.Text);

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
            btnSave.Enabled = true;
            btnUpdate.Enabled = false;
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

        private void dgvCustomer_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string colName = dgvCustomer.Columns[e.ColumnIndex].Name;
            if (colName == "Edit")
            {

                lblCId.Text = dgvCustomer.Rows[e.RowIndex].Cells[1].Value.ToString();
                txtCPhone.Text = dgvCustomer.Rows[e.RowIndex].Cells[3].Value.ToString();
                txtCName.Text = dgvCustomer.Rows[e.RowIndex].Cells[2].Value.ToString();
                textBox1.Text = dgvCustomer.Rows[e.RowIndex].Cells[4].Value.ToString();
                LoadCustomer();
                btnSave.Enabled = false;
                btnUpdate.Enabled = true;
                

            }
            else if (colName == "Delete")
            {
                if (MessageBox.Show("هل انت متاكد من حذف البيانات", "جاري الحذف", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    con.Open();
                    cm = new SqlCommand("DELETE FROM Kas WHERE nid LIKE '" + dgvCustomer.Rows[e.RowIndex].Cells[1].Value.ToString() + "'", con);
                    //dgvCustomer.Rows[e.RowIndex].Cells[3].Value.ToString() + "'", con);
                    cm.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("تم الحذف بنجاح");
                    // MessageBox.Show("ملحوظه مهم جدا يرجاء التاكد من مسح جميع بيانات الخوارج في نهاية اليوم حتي لا يتم حسبها في اليوم التالي");
                    LoadCustomer();

                }
            }
            
        }
    }
    }

