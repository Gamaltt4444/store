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
    public partial class Users : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source =.; Initial Catalog = Real; Integrated Security = True");
        //SqlConnection con = new SqlConnection(@"Data Source=MOSA-PC\SQLEXPRESS;Initial Catalog=aserzamzam12;Integrated Security=True");
        SqlCommand cm = new SqlCommand();
        SqlDataReader dr;
        public Users()
        {
            InitializeComponent();
            LoadUser();
        }
        public void LoadUser()
        {
            int i = 0;
            dgvUser.Rows.Clear();
            cm = new SqlCommand("SELECT * FROM tbUser", con);
            con.Open();
            dr = cm.ExecuteReader();
            while (dr.Read())
            {
                i++;
                dgvUser.Rows.Add(i, dr[0].ToString(), dr[1].ToString(), dr[2].ToString(), dr[3].ToString(), dr[4].ToString());
            }
            dr.Close();
            con.Close();
            btnSave.Enabled = true;
            btnUpdate.Enabled = false;
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
           
            btnSave.Enabled = true;
            btnUpdate.Enabled = false;
            
            LoadUser();
        }


        private void dgvUser_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string colName = dgvUser.Columns[e.ColumnIndex].Name;
            if (colName == "Edit")
            {
               
                txtUserName.Text = dgvUser.Rows[e.RowIndex].Cells[1].Value.ToString();
                txtFullName.Text = dgvUser.Rows[e.RowIndex].Cells[2].Value.ToString();
                txtPass.Text = dgvUser.Rows[e.RowIndex].Cells[3].Value.ToString();
                txtPhone.Text = dgvUser.Rows[e.RowIndex].Cells[4].Value.ToString();
                comboBox1.Text = dgvUser.Rows[e.RowIndex].Cells[5].Value.ToString();
                LoadUser();
                btnSave.Enabled = false;
                btnUpdate.Enabled = true;
                txtUserName.Enabled = false;
                comboBox1.Enabled = false;



            }
            else if (colName == "Delete")
            {
                if (MessageBox.Show("هل انت متاكد من مسح بيانات المستخدم ؟", "جاري المسح", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    con.Open();
                    cm = new SqlCommand("DELETE FROM tbUser WHERE username LIKE '" + dgvUser.Rows[e.RowIndex].Cells[1].Value.ToString() + "'", con);
                    cm.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("تم مسح البيانات بنجاح");
                    LoadUser();
                }
                
                Clear();
            }
            
        }
    

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtUserName.Text =="")
                {
                    MessageBox.Show("  من فضلك ادخال اسم المستخدم", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;

                }
                if (txtFullName.Text == "")
                {
                    MessageBox.Show(" من فضلك ادخال اسم كامل", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;

                }
                if (txtPass.Text == "")
                {
                    MessageBox.Show(" من فضلك ادخال كلمة المرور ", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;

                }

                if (txtPass.Text != txtRepass.Text)
                {
                    MessageBox.Show(" اعد ادخال كلمة المرور بشكل صحيح", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                    
                }
                if (comboBox1.Text== "")
                {
                    MessageBox.Show(" من فضلك اختار صلاحية المستخدم ", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;

                }
                if (MessageBox.Show("هل انت متاكد من حفظ بيانات هذا المتستخدم ؟", "جاري الحفظ ", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {

                    cm = new SqlCommand("INSERT INTO tbUser(username,fullname,password,phone,Rol)VALUES(@username,@fullname,@password,@phone,@R)", con);
                    cm.Parameters.AddWithValue("@username", txtUserName.Text);
                    cm.Parameters.AddWithValue("@fullname", txtFullName.Text);
                    cm.Parameters.AddWithValue("@password", txtPass.Text);
                    cm.Parameters.AddWithValue("@phone", txtPhone.Text);
                    cm.Parameters.AddWithValue("@R", comboBox1.Text);
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
            LoadUser();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            Clear();
            btnSave.Enabled = true;
            btnUpdate.Enabled = false;
            LoadUser();
        }
        public void Clear()
        {
            txtUserName.Clear();
            txtFullName.Clear();
            txtPass.Clear();
            txtRepass.Clear();
            txtPhone.Clear();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtPass.Text != txtRepass.Text)
                {
                    MessageBox.Show("!كلمة السر غير متطابقة", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (MessageBox.Show("هل انت متاكد من تعديل بيانات هذا المستخدم ؟", "جاري التعديل ", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {

                    cm = new SqlCommand("UPDATE tbUser SET fullname = @fullname, password=@password, phone=@phone WHERE username =@mad", con);
                    cm.Parameters.AddWithValue("@mad", txtUserName.Text);
                    cm.Parameters.AddWithValue("@fullname", txtFullName.Text);
                    cm.Parameters.AddWithValue("@password", txtPass.Text);
                    cm.Parameters.AddWithValue("@phone", txtPhone.Text);
                    con.Open();
                    cm.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("تم التعديل بنجاح");
                    //this.Dispose();
                    LoadUser();
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
    }
}
