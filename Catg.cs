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
    public partial class Catg : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source =.; Initial Catalog = Real; Integrated Security = True");
        SqlCommand cm = new SqlCommand();
        SqlDataReader dr;
        public Catg()
        {
            InitializeComponent();
            LoadCategory();
        }
        public void LoadCategory()
        {
            int i = 0;
            dgvCategory.Rows.Clear();
            cm = new SqlCommand("SELECT * FROM tbCategory", con);
            con.Open();
            dr = cm.ExecuteReader();
            while (dr.Read())
            {
                i++;
                dgvCategory.Rows.Add(i, dr[0].ToString(), dr[1].ToString());
            }
            dr.Close();
            con.Close();
            btnSave.Enabled = true;
            btnUpdate.Enabled = false;
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            //CategoryModuleForm formModule = new CategoryModuleForm();
            btnSave.Enabled = true;
            btnUpdate.Enabled = false;
            //ShowDialog();
            LoadCategory();
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dgvCategory_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string colName = dgvCategory.Columns[e.ColumnIndex].Name;
            if (colName == "Edit")
            {
               // CategoryModuleForm formModule = new CategoryModuleForm();
                lblCatId.Text = dgvCategory.Rows[e.RowIndex].Cells[1].Value.ToString();
                txtCatName.Text = dgvCategory.Rows[e.RowIndex].Cells[2].Value.ToString();

                btnSave.Enabled = false;
                btnUpdate.Enabled = true;
               // ShowDialog();
            }
            else if (colName == "Delete")
            {
                if (MessageBox.Show("هل انت متاكد انك تريد مسح بيانات الخارج ؟", "جاري المسح ", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    con.Open();
                    cm = new SqlCommand("DELETE FROM tbCategory WHERE catid LIKE '" + dgvCategory.Rows[e.RowIndex].Cells[1].Value.ToString() + "'", con);
                    cm.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("تم المسح بنجاح");
                }
            }
            LoadCategory();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            
            try
            {
                if (txtCatName.Text == "")
                {
                    MessageBox.Show(" من فضلك ادخال الكتالوج", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;

                }
                
                if (MessageBox.Show("هل انت متاكد من حفظ هذا الكتالوج ؟ ", "جارى الحفظ", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {

                    cm = new SqlCommand("INSERT INTO tbCategory(catname)VALUES(@catname)", con);
                    cm.Parameters.AddWithValue("@catname", txtCatName.Text);
                    con.Open();
                    cm.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("! تم الحفظ بنجاح");
                    Clear();
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            LoadCategory();

        }
        public void Clear()
        {
            txtCatName.Clear();
            LoadCategory();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            Clear();
            btnSave.Enabled = true;
            btnUpdate.Enabled = false;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("هل انت متاكد من تحديث الكتالوج ؟", "جاري التحديث", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {

                    cm = new SqlCommand("UPDATE tbCategory SET catname = @catname WHERE catid LIKE '" + lblCatId.Text + "' ", con);
                    cm.Parameters.AddWithValue("@catname", txtCatName.Text);
                    con.Open();
                    cm.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("تم التحديث بنجاح");
                    // this.Dispose();
                    LoadCategory();
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

        private void bt_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvCategory_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            string colName = dgvCategory.Columns[e.ColumnIndex].Name;
            if (colName == "Edit")
            {
                // CategoryModuleForm formModule = new CategoryModuleForm();
                lblCatId.Text = dgvCategory.Rows[e.RowIndex].Cells[1].Value.ToString();
                txtCatName.Text = dgvCategory.Rows[e.RowIndex].Cells[2].Value.ToString();

                LoadCategory();
                btnSave.Enabled = false;
                btnUpdate.Enabled = true;
                // ShowDialog();
            }
            else if (colName == "Delete")
            {
                if (MessageBox.Show("هل انت متاكد انك تريد مسح البيانات ؟", "جاري المسح ", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    con.Open();
                    cm = new SqlCommand("DELETE FROM tbCategory WHERE catid LIKE '" + dgvCategory.Rows[e.RowIndex].Cells[1].Value.ToString() + "'", con);
                    cm.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("تم المسح بنجاح");
                    LoadCategory();
                    
                }
            }
            
        }

        private void Catg_Load(object sender, EventArgs e)
        {

        }
    }
    
}
