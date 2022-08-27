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
    public partial class pror : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=.;Initial Catalog=Real;Integrated Security=True");
        SqlCommand cm = new SqlCommand();
        SqlDataReader dr;
        public pror()
        {
            InitializeComponent();
            //LoadProduct1();
            LoadProduct();

        }
        public void LoadProduct()
        {
           
            int i = 0;
            dgvProduct.Rows.Clear();
            cm = new SqlCommand("SELECT pid, pname, pprice,pp,pqty, pdescription, pcategory FROM tbProduct WHERE CONCAT(pqty,pid, pname, pprice, pdescription, pcategory) LIKE '%" + textBox1.Text + "%'", con);
            con.Open();
            dr = cm.ExecuteReader();
            while (dr.Read())
            {
                i++;
                dgvProduct.Rows.Add(i, dr[0].ToString(), dr[1].ToString(), dr[2].ToString(), dr[3].ToString(), dr[4].ToString(), dr[5].ToString(), dr[6].ToString());
            }
            dr.Close();
            con.Close();
            
        }

        public void LoadProduct1()
        {

            int i = 0;
            dgvProduct.Rows.Clear();
            cm = new SqlCommand("SELECT pid, pname, pprice,pp,pqty, pdescription, pcategory FROM tbProduct WHERE  date between @fd and @sd", con);
            cm.Parameters.AddWithValue("@fd", dateTimePicker2.Value.Date);
            cm.Parameters.AddWithValue("@sd", dateTimePicker3.Value.Date);
            con.Open();
            dr = cm.ExecuteReader();
            while (dr.Read())
            {
                i++;
                dgvProduct.Rows.Add(i, dr[0].ToString(), dr[1].ToString(), dr[2].ToString(), dr[3].ToString(), dr[4].ToString(), dr[5].ToString(), dr[6].ToString());
            }
            dr.Close();
            con.Close();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            LoadProduct1();
        }

        private void bt_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LoadProduct();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            LoadProduct();
        }

        private void dgvProduct_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string colName = dgvProduct.Columns[e.ColumnIndex].Name;
            if (colName == "Edit")
            {
                Prod productModule = new Prod();
                productModule. lblPid.Text = dgvProduct.Rows[e.RowIndex].Cells[1].Value.ToString();
                productModule. txtPName.Text = dgvProduct.Rows[e.RowIndex].Cells[2].Value.ToString();
                productModule.txtPQty.Text = dgvProduct.Rows[e.RowIndex].Cells[5].Value.ToString();
                productModule.txtPPrice.Text = dgvProduct.Rows[e.RowIndex].Cells[3].Value.ToString();
                productModule.label13.Text = dgvProduct.Rows[e.RowIndex].Cells[4].Value.ToString();
                productModule.txtPDes.Text = dgvProduct.Rows[e.RowIndex].Cells[6].Value.ToString();
                productModule.comboCat.Text = dgvProduct.Rows[e.RowIndex].Cells[7].Value.ToString();
                //LoadProduct();
                productModule.btnSave.Enabled = false;
                productModule.btnUpdate.Enabled = true;
                productModule.ShowDialog();
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
            LoadProduct();
        }
    }
}
