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
    public partial class cust1 : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=.;Initial Catalog=Real;Integrated Security=True");
        SqlCommand cm = new SqlCommand();
        SqlDataReader dr;
        public cust1()
        {
            InitializeComponent();
            LoadProduct();
        }
        public void LoadProduct()
        {
            int i = 0;
            dgvProduct.Rows.Clear();
            cm = new SqlCommand("SELECT * FROM cust1 ", con);
            //cm.Parameters.AddWithValue("@mad", txtSearch.Text);
            con.Open();
            dr = cm.ExecuteReader();
            while (dr.Read())
            {
                i++;
                dgvProduct.Rows.Add(i, dr[0].ToString(), dr[1].ToString(), dr[2].ToString(), dr[3].ToString());
            }
            dr.Close();
            con.Close();
            btnSave.Enabled = true;
            btnUpdate.Enabled = false;
        }
        public void LoadProduct1()
        {
            int i = 0;
            dgvProduct.Rows.Clear();
            cm = new SqlCommand("SELECT  * FROM cust1 WHERE  pname =@mad", con);
            cm.Parameters.AddWithValue("@mad", txtSearch.Text);
            con.Open();
            dr = cm.ExecuteReader();
            while (dr.Read())
            {
                i++;
                dgvProduct.Rows.Add(i, dr[0].ToString(), dr[1].ToString(), dr[2].ToString(), dr[3].ToString());
            }
            dr.Close();
            con.Close();
        }
        
   

private void txtPQty_TextChanged(object sender, EventArgs e)
        {

        }

        private void dgvProduct_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string colName = dgvProduct.Columns[e.ColumnIndex].Name;
            if (colName == "Edit")
            {
                //ProductModuleForm productModule = new ProductModuleForm();
                lblPid.Text = dgvProduct.Rows[e.RowIndex].Cells[1].Value.ToString();
                txtPName.Text = dgvProduct.Rows[e.RowIndex].Cells[2].Value.ToString();
                txtPQty.Text = dgvProduct.Rows[e.RowIndex].Cells[3].Value.ToString();
                txtPPrice.Text = dgvProduct.Rows[e.RowIndex].Cells[4].Value.ToString();
                // txtPDes.Text = dgvProduct.Rows[e.RowIndex].Cells[5].Value.ToString();
                //comboCat.Text = dgvProduct.Rows[e.RowIndex].Cells[6].Value.ToString();
                LoadProduct();
                btnSave.Enabled = false;
                btnUpdate.Enabled = true;
                
                //ShowDialog();
            }
            else if (colName == "Delete")
            {
                if (MessageBox.Show("هل انت متاكد انك تريد مسح البيانات ؟ ", " جاري المسح ", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    con.Open();
                    cm = new SqlCommand("DELETE FROM cust1 WHERE pid LIKE '" + dgvProduct.Rows[e.RowIndex].Cells[1].Value.ToString() + "'", con);
                    cm.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("تم المسح بنجاح");
                    LoadProduct();
                }
            }
            
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtPName.Text == "")
                {
                    MessageBox.Show(" من فضلك ادخال اسم العميل", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;

                }

                if (MessageBox.Show(" هل انت متاكد انك تريد حفظ بيانات هذا العميل؟", "جاري الحفظ", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {

                    cm = new SqlCommand("INSERT INTO cust1(pname,pqty,phone)VALUES(@pname, @pqty, @pprice)", con);
                    cm.Parameters.AddWithValue("@pname", txtPName.Text);
                    cm.Parameters.AddWithValue("@pqty", txtPQty.Text);
                    cm.Parameters.AddWithValue("@pprice", txtPPrice.Text);
                    //cm.Parameters.AddWithValue("@pdescription", txtPDes.Text);
                    // cm.Parameters.AddWithValue("@pcategory", comboCat.Text);

                    con.Open();
                    cm.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("تم الحفظ بنجاح");
                    Clear();
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            LoadProduct();
        }
        public void Clear()
        {
            txtPName.Clear();
            txtPQty.Clear();
            txtPPrice.Clear();
            //txtPDes.Clear();
            //comboCat.Text = "";
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {

                if (MessageBox.Show("هل انت متاكد انك تريد تعديل البيانات ؟", "جاري التعديل", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {

                    cm = new SqlCommand("UPDATE cust1 SET pname = @pname, pqty=@pqty, phone=@pprice WHERE pid LIKE '" + lblPid.Text + "' ", con);
                    cm.Parameters.AddWithValue("@pname", txtPName.Text);
                    cm.Parameters.AddWithValue("@pqty", txtPQty.Text);
                    cm.Parameters.AddWithValue("@pprice", txtPPrice.Text);
                    //cm.Parameters.AddWithValue("@pdescription", txtPDes.Text);
                    //cm.Parameters.AddWithValue("@pcategory", comboCat.Text);
                    con.Open();
                    cm.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("تم التعديل بنجاح");
                    // this.Dispose();
                    LoadProduct();
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
            LoadProduct();
        }

        private void bt_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            LoadProduct1();
        }
    }
}
