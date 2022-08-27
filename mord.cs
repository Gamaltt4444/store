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
    public partial class mord : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=.;Initial Catalog=Real;Integrated Security=True");
        SqlCommand cm = new SqlCommand();
        SqlDataReader dr;
        public mord()
        {
            InitializeComponent();
            LoadProduct();
        }
        public void LoadProduct()
        {
            int i = 0;
            dgvProduct.Rows.Clear();
            cm = new SqlCommand("SELECT  * FROM Mord ", con);
            cm.Parameters.AddWithValue("@mad", txtSearch.Text);
            con.Open();
            dr = cm.ExecuteReader();
            while (dr.Read())
            {
                i++;
                dgvProduct.Rows.Add(i, dr[0].ToString(), dr[1].ToString(), dr[2].ToString(), dr[3].ToString(), dr[4].ToString());
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
            cm = new SqlCommand("SELECT  * FROM Mord WHERE  pname =@mad", con);
            cm.Parameters.AddWithValue("@mad", txtSearch.Text);
            con.Open();
            dr = cm.ExecuteReader();
            while (dr.Read())
            {
                i++;
                dgvProduct.Rows.Add(i, dr[0].ToString(), dr[1].ToString(), dr[2].ToString(), dr[3].ToString(), dr[4].ToString());
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
                txtPQty.Text = dgvProduct.Rows[e.RowIndex].Cells[3].Value.ToString();
                txtPPrice.Text = dgvProduct.Rows[e.RowIndex].Cells[4].Value.ToString();
                txtPDes.Text = dgvProduct.Rows[e.RowIndex].Cells[5].Value.ToString();
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
                    cm = new SqlCommand("DELETE FROM Mord WHERE pid LIKE '" + dgvProduct.Rows[e.RowIndex].Cells[1].Value.ToString() + "'", con);
                    cm.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("تم المسح بنجاح");
                    LoadProduct();
                }
            }
            
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            LoadProduct1();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {

                if (MessageBox.Show(" هل انت متاكد انك تريد حفظ بيانات هذا المندوب؟", "جاري الحفظ", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {

                    cm = new SqlCommand("INSERT INTO Mord(pname,pqty,phone,pdescription)VALUES(@pname, @pqty, @pprice, @pdescription)", con);
                    cm.Parameters.AddWithValue("@pname", txtPName.Text);
                    cm.Parameters.AddWithValue("@pqty", txtPQty.Text);
                    cm.Parameters.AddWithValue("@pprice", txtPPrice.Text);
                    cm.Parameters.AddWithValue("@pdescription", txtPDes.Text);
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
            txtPDes.Clear();
            //comboCat.Text = "";
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {

                if (MessageBox.Show("هل انت متاكد انك تريد تعديل البيانات ؟", "جاري التعديل", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {

                    cm = new SqlCommand("UPDATE Mord SET pname = @pname, pqty=@pqty, phone=@pprice, pdescription=@pdescription WHERE pid LIKE '" + lblPid.Text + "' ", con);
                    cm.Parameters.AddWithValue("@pname", txtPName.Text);
                    cm.Parameters.AddWithValue("@pqty", txtPQty.Text);
                    cm.Parameters.AddWithValue("@pprice", txtPPrice.Text);
                    cm.Parameters.AddWithValue("@pdescription", txtPDes.Text);
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
        }

        private void bt_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            Clear();
            btnSave.Enabled = true;
            btnUpdate.Enabled = false;
            LoadProduct();
        }

        private void txtSearch_TextChanged_1(object sender, EventArgs e)
        {
            LoadProduct1();

        }

        private void btnSave_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (txtPName.Text == "")
                {
                    MessageBox.Show(" من فضلك ادخال اسم المورد", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;

                }
                if (txtPQty.Text == "")
                {
                    MessageBox.Show(" من فضلك ادخال المكان", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;

                }
                if (MessageBox.Show(" هل انت متاكد انك تريد حفظ بيانات هذا المورد؟", "جاري الحفظ", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {

                    cm = new SqlCommand("INSERT INTO Mord(pname,pqty,phone,pdescription)VALUES(@pname, @pqty, @pprice, @pdescription)", con);
                    cm.Parameters.AddWithValue("@pname", txtPName.Text);
                    cm.Parameters.AddWithValue("@pqty", txtPQty.Text);
                    cm.Parameters.AddWithValue("@pprice", txtPPrice.Text);
                    cm.Parameters.AddWithValue("@pdescription", txtPDes.Text);
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

        private void btnUpdate_Click_1(object sender, EventArgs e)
        {
            try
            {

                if (MessageBox.Show("هل انت متاكد انك تريد تعديل البيانات ؟", "جاري التعديل", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {

                    cm = new SqlCommand("UPDATE Mord SET pname = @pname, pqty=@pqty, phone=@pprice, pdescription=@pdescription WHERE pid LIKE '" + lblPid.Text + "' ", con);
                    cm.Parameters.AddWithValue("@pname", txtPName.Text);
                    cm.Parameters.AddWithValue("@pqty", txtPQty.Text);
                    cm.Parameters.AddWithValue("@pprice", txtPPrice.Text);
                    cm.Parameters.AddWithValue("@pdescription", txtPDes.Text);
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
        }

        private void bt_Exit_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvProduct_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            string colName = dgvProduct.Columns[e.ColumnIndex].Name;
            if (colName == "Edit")
            {
                //ProductModuleForm productModule = new ProductModuleForm();
                lblPid.Text = dgvProduct.Rows[e.RowIndex].Cells[1].Value.ToString();
                txtPName.Text = dgvProduct.Rows[e.RowIndex].Cells[2].Value.ToString();
                txtPQty.Text = dgvProduct.Rows[e.RowIndex].Cells[3].Value.ToString();
                txtPPrice.Text = dgvProduct.Rows[e.RowIndex].Cells[4].Value.ToString();
                txtPDes.Text = dgvProduct.Rows[e.RowIndex].Cells[5].Value.ToString();
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
                    cm = new SqlCommand("DELETE FROM Mord WHERE pid LIKE '" + dgvProduct.Rows[e.RowIndex].Cells[1].Value.ToString() + "'", con);
                    cm.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("تم المسح بنجاح");
                    LoadProduct();

                }
            }
            
        }
    }
}

