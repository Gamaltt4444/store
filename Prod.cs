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
    public partial class Prod : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=.;Initial Catalog=Real;Integrated Security=True");
        SqlCommand cm = new SqlCommand();
        SqlDataReader dr;
        public Prod()
        {
            InitializeComponent();
            LoadProduct();
            LoadCategory();
        }
        public void LoadProduct()
        {
            if (txtPQty.Text == "" && txtPPrice.Text == "")
            {
                label13.Text = "0";
                //textBox2.Text = "0";

            }
            else
            {

                double t1 = Convert.ToInt32(txtPQty.Text);
                double t2 = Convert.ToInt32(txtPPrice.Text);
                double t3 = t2 / t1;
                label13.Text = t3.ToString();
                // textBox2.Text = t4.ToString();

            }
            int i = 0;
            dgvProduct.Rows.Clear();
            cm = new SqlCommand("SELECT pid, pname, pprice,pp,pqty, pdescription, pcategory FROM tbProduct WHERE CONCAT(pid, pname, pprice, pdescription, pcategory) LIKE '%" + txtSearch.Text + "%'", con);
            con.Open();
            dr = cm.ExecuteReader();
            while (dr.Read())
            {
                i++;
                dgvProduct.Rows.Add(i, dr[0].ToString(), dr[1].ToString(), dr[2].ToString(), dr[3].ToString(), dr[4].ToString(), dr[5].ToString(), dr[6].ToString());
            }
            dr.Close();
            con.Close();
            btnSave.Enabled = true;
            btnUpdate.Enabled = false;
        }
        public void LoadCategory()
        {
            comboCat.Items.Clear();
            cm = new SqlCommand("SELECT catname FROM tbCategory", con);
            con.Open();
            dr = cm.ExecuteReader();
            while (dr.Read())
            {
                comboCat.Items.Add(dr[0].ToString());
            }
            dr.Close();
            con.Close();
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            //ProductModuleForm formModule = new ProductModuleForm();
            btnSave.Enabled = true;
            btnUpdate.Enabled = false;
            //formModule.ShowDialog();
            LoadProduct();

        }

        private void dgvProduct_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string colName = dgvProduct.Columns[e.ColumnIndex].Name;
            if (colName == "Edit")
            {
                //ProductModuleForm productModule = new ProductModuleForm();
                lblPid.Text = dgvProduct.Rows[e.RowIndex].Cells[1].Value.ToString();
                txtPName.Text = dgvProduct.Rows[e.RowIndex].Cells[2].Value.ToString();
                txtPQty.Text = dgvProduct.Rows[e.RowIndex].Cells[5].Value.ToString();
                txtPPrice.Text = dgvProduct.Rows[e.RowIndex].Cells[3].Value.ToString();
                label13.Text = dgvProduct.Rows[e.RowIndex].Cells[4].Value.ToString();
                txtPDes.Text = dgvProduct.Rows[e.RowIndex].Cells[6].Value.ToString();
                comboCat.Text = dgvProduct.Rows[e.RowIndex].Cells[7].Value.ToString();
                LoadProduct();
                btnSave.Enabled = false;
                btnUpdate.Enabled = true;
                //ShowDialog();
            }
            else if (colName == "Delete")
            {
                if (MessageBox.Show("هل انت متاكد انك تريد مسح هذا الصنف ؟ ", " جاري المسح ", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    con.Open();
                    cm = new SqlCommand("DELETE FROM tbProduct WHERE pid LIKE '" + dgvProduct.Rows[e.RowIndex].Cells[1].Value.ToString() + "'", con);
                    cm.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("تم المسح بنجاح");
                    LoadProduct();
                }
            }
            
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            LoadProduct();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            try
            {
                if (txtPName.Text == "")
                {
                    MessageBox.Show(" من فضلك ادخال اسم المنتح", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;

                }
                if (txtPQty.Text == "")
                {
                    MessageBox.Show(" من فضلك ادخال الكمية", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;

                }
                if (txtPPrice.Text == "")
                {
                    MessageBox.Show(" من فضلك ادخال السعر", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;

                }

                if (MessageBox.Show(" هل انت متاكد انك تريد حفظ هذاالصنف ؟", "جاري الحفظ", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    LoadProduct();
                    cm = new SqlCommand("INSERT INTO tbProduct(pname,pqty,pprice,pp,pdescription,pcategory,date,pqty1,pprice1,t1)VALUES(@pname, @pqty, @pprice, @pp, @pdescription, @pcategory,@date,@pqty1,@pprice1,@t1)", con);
                    cm.Parameters.AddWithValue("@date", dateTimePicker2.Value);
                    cm.Parameters.AddWithValue("@pname", txtPName.Text);
                    cm.Parameters.AddWithValue("@pqty", Convert.ToInt16(txtPQty.Text));
                    cm.Parameters.AddWithValue("@pprice", Convert.ToInt16(txtPPrice.Text));
                    cm.Parameters.AddWithValue("@pqty1", Convert.ToInt16(label9.Text));
                    cm.Parameters.AddWithValue("@pprice1", Convert.ToInt16(label10.Text));
                    cm.Parameters.AddWithValue("@pp", Convert.ToInt16(label13.Text));
                    cm.Parameters.AddWithValue("@t1", Convert.ToInt16(label13.Text));
                    cm.Parameters.AddWithValue("@pdescription", txtPDes.Text);
                    cm.Parameters.AddWithValue("@pcategory", comboCat.Text);

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
            txtPDes.Clear();
            comboCat.Text = "";
            label13.Text = "0";
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            Clear();
            btnSave.Enabled = true;
            btnUpdate.Enabled = false;
            LoadProduct();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {

                if (MessageBox.Show("هل انت متاكد انك تريد تعديل هذا الصنف ؟", "جاري التعديل", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    LoadProduct();
                    cm = new SqlCommand("UPDATE tbProduct SET pname = @pname, pqty=@pqty,pp=@pp, pprice=@pprice, pdescription=@pdescription, pcategory=@pcategory WHERE pid LIKE '" + lblPid.Text + "' ", con);
                    cm.Parameters.AddWithValue("@pname", txtPName.Text);
                    cm.Parameters.AddWithValue("@pqty", Convert.ToInt16(txtPQty.Text));
                    cm.Parameters.AddWithValue("@pprice", Convert.ToInt16(txtPPrice.Text));
                    cm.Parameters.AddWithValue("@pp", Convert.ToInt16(label13.Text));
                    cm.Parameters.AddWithValue("@pdescription", txtPDes.Text);
                    cm.Parameters.AddWithValue("@pcategory", comboCat.Text);
                    con.Open();
                    cm.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("تم التعديل بنجاح");
                    LoadProduct();
                    Clear();
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            LoadProduct();
        }

        private void bt_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void comboCat_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
