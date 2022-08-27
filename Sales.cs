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
    public partial class Sales : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=.;Initial Catalog=Real;Integrated Security=True");
        SqlCommand cm = new SqlCommand();
        SqlDataReader dr;
        int qty = 0;
        public Sales()
        {
            InitializeComponent();
            LoadCustomer();
            LoadProduct();
        }
        public void LoadCustomer()
        {
            int i = 0;
            dgvCustomer.Rows.Clear();
            cm = new SqlCommand("SELECT pid, pname FROM cust1 WHERE CONCAT(pid, pname) LIKE '%" + txtSearchCust.Text + "%'", con);
            con.Open();
            dr = cm.ExecuteReader();
            while (dr.Read())
            {
                i++;
                dgvCustomer.Rows.Add(i, dr[0].ToString(), dr[1].ToString());
            }
            dr.Close();
            con.Close();
        }

        public void LoadProduct()
        {
            int i = 0;
            dgvProduct.Rows.Clear();
            cm = new SqlCommand("SELECT pid, pname,pprice,pp,pqty, pdescription, pcategory FROM tbProduct WHERE CONCAT(pid, pname, pprice,pp, pdescription, pcategory) LIKE '%" + txtSearchProd.Text + "%'", con);
            con.Open();
            dr = cm.ExecuteReader();
            while (dr.Read())
            {
                i++;
                dgvProduct.Rows.Add(i, dr[0].ToString(), dr[1].ToString(), dr[2].ToString(), dr[3].ToString(), dr[4].ToString(), dr[5].ToString(), dr[6].ToString());
            }
            dr.Close();
            con.Close();
            int n = 0;
            double total = 0;
            dgvOrder.Rows.Clear();
            cm = new SqlCommand("SELECT idd ,pid, nam,qty, price, total FROM tbOrder1 ", con);

            con.Open();
            dr = cm.ExecuteReader();
            while (dr.Read())
            {
                n++;
                dgvOrder.Rows.Add(n, dr[0].ToString(), dr[1].ToString(), dr[2].ToString(), dr[3].ToString(), dr[4].ToString(), dr[5].ToString());
                total += Convert.ToInt32(dr[5].ToString());
            }
            dr.Close();
            con.Close();
            label23.Text = total.ToString();

        }


        private void Sales_Load(object sender, EventArgs e)
        {

        }

        private void txtSearchCust_TextChanged(object sender, EventArgs e)
        {
            LoadCustomer();
        }

        private void txtSearchProd_TextChanged(object sender, EventArgs e)
        {
            LoadProduct();
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            GetQty();
            //if (Convert.ToInt16(UDQty.Value) > qty)
           // {
               // MessageBox.Show("!الكمية غير متوفرة", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
               // UDQty.Value = UDQty.Value - 1;
                //return;
            //}
            if (Convert.ToInt16(UDQty.Value) > 0)
            {
                int total = Convert.ToInt16(txtPrice.Text) * Convert.ToInt16(UDQty.Value);
                txtTotal.Text = total.ToString();
            }
        }
        public void GetQty()
        {
            cm = new SqlCommand("SELECT pqty FROM tbProduct WHERE pid='" + txtPid.Text + "'", con);
            con.Open();
            dr = cm.ExecuteReader();
            while (dr.Read())
            {
                qty = Convert.ToInt32(dr[0].ToString());
            }
            dr.Close();
            con.Close();
        }

        private void dgvCustomer_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtCId.Text = dgvCustomer.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtCName.Text = dgvCustomer.Rows[e.RowIndex].Cells[2].Value.ToString();
        }

        private void dgvProduct_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtPid.Text = dgvProduct.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtPName.Text = dgvProduct.Rows[e.RowIndex].Cells[2].Value.ToString();
            txtPrice.Text = dgvProduct.Rows[e.RowIndex].Cells[4].Value.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
               

                if (txtCId.Text == "")
                {
                    MessageBox.Show("من فضلك اختار كود العميل", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (txtCName.Text == "")
                {
                    MessageBox.Show("من فضلك اكتب اسم العميل", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (txtPid.Text == "")
                {
                    MessageBox.Show("من فضلك اختار الصنف او المنتج", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (txtTotal.Text == "")
                {
                    MessageBox.Show("من فضلك اختار الكمية", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (MessageBox.Show("هل انت متاكد من اضافه العنصر؟", "جاري الحفظ", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {

                    cm = new SqlCommand("INSERT INTO tbOrder(odate, pid, cid, qty, price, total)VALUES(@odate, @pid, @cid, @qty, @price, @total)", con);
                    cm.Parameters.AddWithValue("@odate", dtOrder.Value);
                    cm.Parameters.AddWithValue("@pid", Convert.ToInt32(txtPid.Text));
                    cm.Parameters.AddWithValue("@cid", Convert.ToInt32(txtCId.Text));
                    cm.Parameters.AddWithValue("@qty", Convert.ToInt32(UDQty.Value));
                    cm.Parameters.AddWithValue("@price", Convert.ToInt32(txtPrice.Text));
                    cm.Parameters.AddWithValue("@total", Convert.ToInt32(txtTotal.Text));
                    con.Open();
                    cm.ExecuteNonQuery();
                    con.Close();

                    cm = new SqlCommand("INSERT INTO tbOrder1(pid,nam,qty, price, total)VALUES(@pid,@nam, @qty, @price, @total)", con);
                    cm.Parameters.AddWithValue("@pid", Convert.ToInt32(txtPid.Text));
                    cm.Parameters.AddWithValue("@nam", txtPName.Text);
                    cm.Parameters.AddWithValue("@qty", Convert.ToInt32(UDQty.Value));
                    cm.Parameters.AddWithValue("@price", Convert.ToInt32(txtPrice.Text));
                    cm.Parameters.AddWithValue("@total", Convert.ToInt32(txtTotal.Text));
                    con.Open();
                    cm.ExecuteNonQuery();
                    con.Close();

                    cm = new SqlCommand("UPDATE tbProduct SET pqty=(pqty-@pqty) WHERE pid LIKE '" + txtPid.Text + "' ", con);
                    cm.Parameters.AddWithValue("@pqty", Convert.ToInt16(UDQty.Value));

                    con.Open();
                    cm.ExecuteNonQuery();
                    con.Close();
                    Clear1();
                    LoadProduct();

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            try
            {

                if (txtCName.Text == "")
                {
                    MessageBox.Show("من فضلك اكتب اسم العميل", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (label23.Text == "0")
                {
                    MessageBox.Show("من فضلك اختار الصنف او المنتج", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (MessageBox.Show("هل انت متاكد من اجراء هذا الطلب؟", "جاري الحفظ", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    MessageBox.Show("تم اجراء الاوردر بنجاح");
                    PrintPreviewDialog printPreviewDialog1 = new PrintPreviewDialog();
                    printPreviewDialog1.Document = this.printDocument1;
                    printPreviewDialog1.FormBorderStyle = FormBorderStyle.Fixed3D;
                    //printPreviewDialog1.SetBounds(20, 20, this.Width, this.Height);

                    printPreviewDialog1.ShowDialog();


                    cm = new SqlCommand("DELETE  FROM tbOrder1", con);
                    con.Open();
                    cm.ExecuteNonQuery();
                    con.Close();
                    Clear();
                    LoadProduct();

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
            
        }
        public void Clear1()
        {
            //txtCId.Clear();
            //txtCName.Clear();

            txtPid.Clear();
            txtPName.Clear();

            txtPrice.Clear();
            UDQty.Value = 0;
            txtTotal.Clear();
            dtOrder.Value = DateTime.Now;
        }
        public void Clear()
        {
            txtCId.Clear();
            txtCName.Clear();

            txtPid.Clear();
            txtPName.Clear();

            txtPrice.Clear();
            UDQty.Value = 0;
            txtTotal.Clear();
            dtOrder.Value = DateTime.Now;
        }



       

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
           e.Graphics.DrawImage(Properties.Resources.IMG_20220717_WA0000, 5, 5,200 , 200);
            float yPos = 8;
            int leftMargin = 15;
            // Pen pen = new Pen(Brushes.Black);

            //e.HasMorePages =true;
            // pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            //Font printFont4d = new System.Drawing.Font("Times New Roman", 12, FontStyle.Bold);
            //Font printFont = new System.Drawing.Font("Times New Roman", 14);
            //Font printFont11 = new System.Drawing.Font("Times New Roman", 16);
            //Font printFontFoorer = new System.Drawing.Font("Times New Roman", 12);
            //Font printFontheader_DRName = new System.Drawing.Font("Times New Roman", 20, FontStyle.Bold);
            //------


            Font PatientFontheader = new System.Drawing.Font("Times New Roman", 35, FontStyle.Bold);
            Font PatientFontheader2 = new System.Drawing.Font("Times New Roman", 25, FontStyle.Bold);

            Font PatientFontheader1 = new System.Drawing.Font("Times New Roman", 20, FontStyle.Bold);

            Font PatientNormal = new System.Drawing.Font("Arial", 15, FontStyle.Bold);
            //======================================                      
            string nam, price, qut, tot,font,Num;
            
            yPos += 40;
            e.Graphics.DrawString("العيوني ", PatientFontheader, Brushes.Purple, leftMargin + 630, yPos, new StringFormat());
            e.Graphics.DrawString(  " فاتورة مببعات  ", PatientFontheader1, Brushes.Purple, leftMargin + 330, yPos, new StringFormat());
            yPos += 60;
            e.Graphics.DrawString(" للتشطيبات والدهانات ", PatientFontheader2, Brushes.Purple, leftMargin + 550, yPos, new StringFormat());
            yPos += 60;
            e.Graphics.DrawString(  dtOrder.Text+ ": التاريخ ", PatientFontheader1, Brushes.Purple, leftMargin + 580, yPos, new StringFormat());
            yPos += 40;
            e.Graphics.DrawString( "----------------------------------------------------------------"+" : مطلوب من السيد ", PatientFontheader1, Brushes.Purple, leftMargin + 0,yPos , new StringFormat());
            yPos -= 10;
            e.Graphics.DrawString(  txtCName.Text , PatientFontheader1, Brushes.Purple, leftMargin + 200, yPos, new StringFormat());
            yPos += 45;
            e.Graphics.DrawString("--------------------------------------------------------------------------------------", PatientFontheader1, Brushes.Purple, leftMargin + 0, yPos, new StringFormat());
            yPos -=2;
            e.Graphics.DrawString("--------------------------------------------------------------------------------------", PatientFontheader1, Brushes.Purple, leftMargin + 0,yPos , new StringFormat());
            yPos += 33;
            e.Graphics.DrawString("اسم الصنف", PatientFontheader1, Brushes.Purple, leftMargin + 10, yPos, new StringFormat());
            //e.Graphics.DrawString(txtPName.Text, PatientFontheader1, Brushes.Black, leftMargin + 250, 100, new StringFormat());
           // e.Graphics.DrawString(label16.Text, PatientFontheader1, Brushes.Purple, leftMargin + 395, yPos, new StringFormat());

            e.Graphics.DrawString("سعر الوحدة", PatientFontheader1, Brushes.Purple, leftMargin + 410, yPos, new StringFormat());
            // e.Graphics.DrawString(txtPrice.Text, PatientFontheader1, Brushes.Black, leftMargin + 350,150 , new StringFormat());
           // e.Graphics.DrawString(label16.Text, PatientFontheader1, Brushes.Purple, leftMargin + 585, yPos, new StringFormat());
            e.Graphics.DrawString("الكميه", PatientFontheader1, Brushes.Purple, leftMargin + 600, yPos, new StringFormat());
           // e.Graphics.DrawString(label16.Text, PatientFontheader1, Brushes.Purple, leftMargin + 715, yPos, new StringFormat());
            e.Graphics.DrawString("الاجمالي", PatientFontheader1, Brushes.Purple, leftMargin + 730, yPos, new StringFormat());
            yPos += 30;
            e.Graphics.DrawString("--------------------------------------------------------------------------------------", PatientFontheader1, Brushes.Purple, leftMargin + 0, yPos, new StringFormat());
            yPos -=2;
            e.Graphics.DrawString("--------------------------------------------------------------------------------------", PatientFontheader1, Brushes.Purple, leftMargin + 0, yPos, new StringFormat());

            //e.Graphics.DrawString(UDQty.Text, PatientFontheader1, Brushes.Black, leftMargin + 350, 200, new StringFormat());
            yPos += 42;
            SizeF stringSize = new SizeF();
            for (int i = 0; i < dgvOrder.Rows.Count; i++)
            {
                Num = dgvOrder.Rows[i].Cells[1].Value.ToString();
                nam = dgvOrder.Rows[i].Cells[3].Value.ToString();
                price = dgvOrder.Rows[i].Cells[5].Value.ToString();
                qut = dgvOrder.Rows[i].Cells[4].Value.ToString();
                tot = dgvOrder.Rows[i].Cells[6].Value.ToString();
                //font = label16.Text;
                e.Graphics.DrawString(nam.ToUpper(), PatientNormal, Brushes.Purple, leftMargin + 10, yPos, new StringFormat());
                yPos += 1;
                tot = "                      " + price + "                     " + qut + "                    "  + tot;
                stringSize = e.Graphics.MeasureString(tot, PatientNormal);
                e.Graphics.DrawString(tot, PatientNormal, Brushes.Purple, 800 - stringSize.Width, yPos);
                yPos += 40;
            }
            yPos += 30;
            e.Graphics.DrawString("--------------------------------------------------------------------------------------", PatientFontheader1, Brushes.Purple, leftMargin + 0, yPos, new StringFormat());
            yPos -= 2;
            e.Graphics.DrawString("--------------------------------------------------------------------------------------", PatientFontheader1, Brushes.Purple, leftMargin + 0, yPos, new StringFormat());
            yPos += 50;

            e.Graphics.DrawString("---------------------------------------------------------------------" + " : المجموع ", PatientFontheader1, Brushes.Purple, leftMargin + 0, yPos, new StringFormat());
            yPos -= 10;
            // e.Graphics.DrawString(":المجموع", PatientFontheader1, Brushes.Purple, leftMargin + 400, yPos, new StringFormat());
            e.Graphics.DrawString("جينة فقط لا غير", PatientFontheader1, Brushes.Purple, leftMargin + 80, yPos, new StringFormat());
            e.Graphics.DrawString(label23.Text, PatientFontheader1, Brushes.Purple, leftMargin + 400, yPos, new StringFormat());
            yPos += 40;
            e.Graphics.DrawString("--------------------------------------------------------------------------------------", PatientFontheader1, Brushes.Purple, leftMargin + 0, yPos, new StringFormat());
            yPos -= 2;
            e.Graphics.DrawString("--------------------------------------------------------------------------------------", PatientFontheader1, Brushes.Purple, leftMargin + 0, yPos, new StringFormat());


        }

        private void dgvOrder_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            string colName = dgvOrder.Columns[e.ColumnIndex].Name;

            if (colName == "Delete")
            {

                if (MessageBox.Show("هل انت متاكد من حذف هذا الاوردر؟", "جاري الحذف", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    label14.Text = dgvOrder.Rows[e.RowIndex].Cells[1].Value.ToString();
                    cm = new SqlCommand("DELETE  FROM tbOrder WHERE iddd LIKE '" + label14.Text + "'", con);
                    con.Open();
                    cm.ExecuteNonQuery();
                    con.Close();
                    con.Open();
                    cm = new SqlCommand("DELETE FROM tbOrder1 where idd  LIKE '" + dgvOrder.Rows[e.RowIndex].Cells[1].Value.ToString() + "'", con);

                    cm.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("!تم الحذف بنجاح");



                    cm = new SqlCommand("UPDATE tbProduct SET pqty=(pqty+@pqty) WHERE pid LIKE '" + dgvOrder.Rows[e.RowIndex].Cells[2].Value.ToString() + "' ", con);
                    cm.Parameters.AddWithValue("@pqty", Convert.ToInt16(dgvOrder.Rows[e.RowIndex].Cells[4].Value.ToString()));

                    con.Open();
                    cm.ExecuteNonQuery();
                    con.Close();

                }
            }
            LoadProduct();
        }

        private void dgvCustomer_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtCId.Text = dgvCustomer.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtCName.Text = dgvCustomer.Rows[e.RowIndex].Cells[2].Value.ToString();
            
        }

        private void dgvProduct_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtPid.Text = dgvProduct.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtPName.Text = dgvProduct.Rows[e.RowIndex].Cells[2].Value.ToString();
            txtPrice.Text = dgvProduct.Rows[e.RowIndex].Cells[4].Value.ToString();
        }

        private void UDQty_ValueChanged(object sender, EventArgs e)
        {
            GetQty();
            if (Convert.ToInt16(UDQty.Value) > qty)
             {
             MessageBox.Show("!الكمية غير متوفرة", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
             UDQty.Value = UDQty.Value - 1;
            return;
            }
            if (Convert.ToInt16(UDQty.Value) > 0)
            {
                int total = Convert.ToInt16(txtPrice.Text) * Convert.ToInt16(UDQty.Value);
                txtTotal.Text = total.ToString();
            }
        }

        private void bt_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void printPreviewDialog1_Load(object sender, EventArgs e)
        {

        }
    }
}