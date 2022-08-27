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
    public partial class Kast : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source =.; Initial Catalog = Real; Integrated Security = True");

        //SqlConnection con = new SqlConnection(@"Data Source=MOSA-PC\SQLEXPRESS;Initial Catalog=aserzamzam12;Integrated Security=True");
        SqlCommand cm = new SqlCommand();
        SqlDataReader dr;
        public Kast()
        {
            InitializeComponent();
            LoadCustomer();
        }
        public void cust()
        {
            double total = 0;
            double total1 = 0;
            int i = 0;
            dgvCustomer.Rows.Clear();
            cm = new SqlCommand("SELECT nid, date ,Wnam,Work,price,pric2,pric3,pric4,price5 FROM Kast where Wnam= @wnam", con);
            cm.Parameters.AddWithValue("@wnam", textBox2.Text);
            //cm.Parameters.AddWithValue("@sdn", dateTimePicker2.Value.Date);
            con.Open();
            dr = cm.ExecuteReader();
            while (dr.Read())
            {
                i++;
                dgvCustomer.Rows.Add(i, dr[0].ToString(), dr[1].ToString(), dr[2].ToString(), dr[3].ToString(), dr[4].ToString(), dr[5].ToString(), dr[6].ToString(), dr[7].ToString(), dr[8].ToString());
                total += Convert.ToInt32(dr[8].ToString());
                total1 += Convert.ToInt32(dr[5].ToString());
            }
            dr.Close();
            con.Close();
            label6.Text = total.ToString();
            label10.Text = total1.ToString();

        }
        public void LoadCustomer()
        {
           
            double total = 0;
            double total1 = 0;
            int i = 0;
            dgvCustomer.Rows.Clear();
            cm = new SqlCommand("SELECT nid, date ,Wnam,Work,price,pric2,pric3,pric4,price5 FROM Kast ", con);
            //cm.Parameters.AddWithValue("@fdn", dateTimePicker1.Value.Date);
            //cm.Parameters.AddWithValue("@sdn", dateTimePicker2.Value.Date);
            con.Open();
            dr = cm.ExecuteReader();
            while (dr.Read())
            {
                i++;
                dgvCustomer.Rows.Add(i, dr[0].ToString(), dr[1].ToString(), dr[2].ToString(), dr[3].ToString(), dr[4].ToString(), dr[5].ToString(), dr[6].ToString(), dr[7].ToString(), dr[8].ToString());
                total += Convert.ToInt32(dr[8].ToString());
                total1 += Convert.ToInt32(dr[5].ToString());
            }
            dr.Close();
            con.Close();
            label6.Text = total.ToString();
            label10.Text = total1.ToString();
            btnSave.Enabled = true;
            btnUpdate.Enabled = false;

        }
        public void Kat()
        {
            if (textBox1.Text == "" && txtCName.Text == "")
            {
                label13.Text = "0";
                M.Text = "0";
                p2.Text = "0";
                //textBox2.Text = "0";


            }
            else
            {

                double t1 = Convert.ToInt32(textBox1.Text);
                double t2 = Convert.ToInt32(txtCPhone.Text);
                double t3 = t1 / t2;
                double t4 = t1 - t2;
                double t5 = t3 - 1;
                label13.Text = t3.ToString();
                M.Text = t5.ToString();
                p2.Text = t4.ToString();
                // textBox2.Text = t4.ToString();

            }
        }
        public void Kat1()
        {
            if (textBox1.Text == "" && txtCName.Text == "")
            {
                label13.Text = "0";
                M.Text = "0";
                p2.Text = "0";
                //textBox2.Text = "0";


            }
            else
            {

                double t1 = Convert.ToInt32(textBox1.Text);
                double t2 = Convert.ToInt32(txtCPhone.Text);
                double t6 = Convert.ToInt32(p2.Text);
                double t7 = Convert.ToInt32(M.Text);
                double t3 = t1 / t2;
                double t4 = t6 - t2;
                double t5 = t7 - 1;
                label13.Text = t3.ToString();
                M.Text = t5.ToString();
                p2.Text = t4.ToString();
                // textBox2.Text = t4.ToString();

            }
        }

        private void btnAdd_Click_1(object sender, EventArgs e)
        {
            

            btnSave.Enabled = true;
            btnUpdate.Enabled = false;
            LoadCustomer();
            Kat();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            double total = 0;
            double total1 = 0;
            int i = 0;
            dgvCustomer.Rows.Clear();
            cm = new SqlCommand("SELECT nid, date ,Wnam,Work, price,pric2,pric3,pric4,price5  FROM Kast where date between @fdn and @sdn", con);
            cm.Parameters.AddWithValue("@fdn", dateTimePicker2.Value.Date);
            cm.Parameters.AddWithValue("@sdn", dateTimePicker3.Value.Date);
            con.Open();
            dr = cm.ExecuteReader();
            while (dr.Read())
            {
                i++;
                dgvCustomer.Rows.Add(i, dr[0].ToString(), dr[1].ToString(), dr[2].ToString(), dr[3].ToString(), dr[4].ToString(), dr[5].ToString(),dr[6].ToString(), dr[7].ToString(), dr[8].ToString());
                total += Convert.ToInt32(dr[8].ToString());
                total1 += Convert.ToInt32(dr[5].ToString());
            }
            dr.Close();
            con.Close();
            label6.Text = total.ToString();
            label10.Text = total1.ToString();
            Kat();

        }

        private void dgvCustomer_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string colName = dgvCustomer.Columns[e.ColumnIndex].Name;
            if (colName == "Edit")
            {

                lblCId.Text = dgvCustomer.Rows[e.RowIndex].Cells[1].Value.ToString();
                txtCPhone .Text = dgvCustomer.Rows[e.RowIndex].Cells[5].Value.ToString();
                txtCName.Text = dgvCustomer.Rows[e.RowIndex].Cells[3].Value.ToString();
                textBox1.Text = dgvCustomer.Rows[e.RowIndex].Cells[4].Value.ToString();
                p2.Text = dgvCustomer.Rows[e.RowIndex].Cells[6].Value.ToString();
                label13.Text = dgvCustomer.Rows[e.RowIndex].Cells[7].Value.ToString();
                M.Text = dgvCustomer.Rows[e.RowIndex].Cells[8].Value.ToString();
                LoadCustomer();
                btnSave.Enabled = false;
                btnUpdate.Enabled = true;
               
                

            }
            else if (colName == "Delete")
            {
                if (MessageBox.Show("هل انت متاكد من حذف البيانات", "جاري الحذف", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    con.Open();
                    cm = new SqlCommand("DELETE FROM Kast WHERE nid LIKE '" + dgvCustomer.Rows[e.RowIndex].Cells[1].Value.ToString() + "'", con);
                    //dgvCustomer.Rows[e.RowIndex].Cells[3].Value.ToString() + "'", con);
                    cm.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("تم الحذف بنجاح");
                    // MessageBox.Show("ملحوظه مهم جدا يرجاء التاكد من مسح جميع بيانات الخوارج في نهاية اليوم حتي لا يتم حسبها في اليوم التالي");
                    LoadCustomer();

                }
            }
            
            
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            
            try
            {
                if (txtCName.Text == "")
                {
                    MessageBox.Show(" من فضلك ادخال اسم العميل", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;

                }
                if (txtCPhone.Text == "")
                {
                    MessageBox.Show(" من فضلك ادخال القسط الشهري", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;

                }
                if (textBox1.Text == "")
                {
                    MessageBox.Show(" من فضلك ادخال المبلغ كامل", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;

                }

                if (MessageBox.Show("هل انت متاكد من حفظ البيانات ؟  ", "جاري الحفظ", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Kat();
                    cm = new SqlCommand("INSERT INTO Kast (date,Wnam,Work,price,pric2,pric3,pric4,price5)VALUES(@date,@Wnam,@Work,@price,@price2,@pric3,@pric4,@price5)", con);
                    cm.Parameters.AddWithValue("@date", dateTimePicker1.Value.Date);
                    cm.Parameters.AddWithValue("@Wnam", txtCName.Text);
                    cm.Parameters.AddWithValue("@Work", textBox1.Text);
                    cm.Parameters.AddWithValue("@price",  txtCPhone.Text);
                    cm.Parameters.AddWithValue("@price5", txtCPhone.Text);
                    cm.Parameters.AddWithValue("@price2", p2.Text);
                    cm.Parameters.AddWithValue("@pric3", label13.Text);
                    cm.Parameters.AddWithValue("@pric4", M.Text);
                    

                    con.Open();
                    cm.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("تم حفظ اليبانات بنجاح ");
                    LoadCustomer();
                    Clear();
                    Kat();
                    
                    

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
            Kat();
            
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                
                if (MessageBox.Show("هل انت متاكد من تعديل البيانات  ", "جاري التعديل", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Kat1();

                    cm = new SqlCommand("UPDATE Kast SET date=@date, Wnam= @Wnam,Work=@Work,price= @price,pric2=(pric2-@p1) ,pric3= @price3,pric4=(pric4-@p),price5=(price5+@price) WHERE nid LIKE '" + lblCId.Text + "' ", con);
                    cm.Parameters.AddWithValue("@date", dateTimePicker1.Value.Date);
                    cm.Parameters.AddWithValue("@Wnam", txtCName.Text);
                    cm.Parameters.AddWithValue("@Work", textBox1.Text);
                    cm.Parameters.AddWithValue("@price", Convert.ToInt32( txtCPhone.Text));
                    cm.Parameters.AddWithValue("@p1", Convert.ToInt32(txtCPhone.Text));
                    //cm.Parameters.AddWithValue("@price", txtCName.Text);
                    //cm.Parameters.AddWithValue("@price2", p2.Text);
                    cm.Parameters.AddWithValue("@price3", label13.Text);
                    cm.Parameters.AddWithValue("@p", Convert.ToInt32(label18.Text));
                    //cm.Parameters.AddWithValue("@price4", M.Text);

                    //cm = new SqlCommand("UPDATE Kast SET  WHERE nid LIKE '" + lblCId.Text + "' ", con);
                    // cm.Parameters.AddWithValue("@price", Convert.ToInt32(txtCName.Text));
                    //cm = new SqlCommand("UPDATE Kast SET pric2=(pric2-@p1) WHERE nid LIKE '" + lblCId.Text + "' ", con);
                    //cm.Parameters.AddWithValue("@p1", Convert.ToInt32(txtCName.Text));
                    // cm = new SqlCommand("UPDATE Kast SET pric4=(pric4-@p) WHERE nid LIKE '" + lblCId.Text + "' ", con);
                    //cm.Parameters.AddWithValue("@p", Convert.ToInt32(label18.Text));
                    con.Open();
                    cm.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("تم تعديل اليبانات بنجاح ");
                    PrintPreviewDialog printPreviewDialog1 = new PrintPreviewDialog();
                    printPreviewDialog1.Document = this.printDocument1;
                    printPreviewDialog1.FormBorderStyle = FormBorderStyle.Fixed3D;
                    //printPreviewDialog1.SetBounds(20, 20, this.Width, this.Height);
                    printPreviewDialog1.ShowDialog();

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
            Kat();
        }

        private void bt_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bt_Exit_Click_1(object sender, EventArgs e)
        {
            this.Close();

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void Kast_Load(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            cust();
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawImage(Properties.Resources.IMG_20220717_WA0000, 5, 5, 200, 200);
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
            string nam, price, qut, tot, font, Num;

            yPos += 40;
            e.Graphics.DrawString("العيوني ", PatientFontheader, Brushes.Purple, leftMargin + 630, yPos, new StringFormat());
            e.Graphics.DrawString(" ايصال دفع القسط  ", PatientFontheader1, Brushes.Purple, leftMargin + 330, yPos, new StringFormat());
            yPos += 60;
            e.Graphics.DrawString(" للتشطيبات والدهانات ", PatientFontheader2, Brushes.Purple, leftMargin + 550, yPos, new StringFormat());
            yPos += 60;
            e.Graphics.DrawString(dateTimePicker1.Text + ": التاريخ ", PatientFontheader1, Brushes.Purple, leftMargin + 580, yPos, new StringFormat());
            yPos += 40;
            e.Graphics.DrawString("----------------------------------------------------------------" + " : قسط من السيد ", PatientFontheader1, Brushes.Purple, leftMargin + 0, yPos, new StringFormat());
            yPos -= 10;
            e.Graphics.DrawString(txtCName.Text, PatientFontheader1, Brushes.Purple, leftMargin + 200, yPos, new StringFormat());
            yPos += 45;
            e.Graphics.DrawString("--------------------------------------------------------------------------------------", PatientFontheader1, Brushes.Purple, leftMargin + 0, yPos, new StringFormat());
            yPos -= 2;
            e.Graphics.DrawString("--------------------------------------------------------------------------------------", PatientFontheader1, Brushes.Purple, leftMargin + 0, yPos, new StringFormat());
            yPos += 33;
            e.Graphics.DrawString(txtCPhone.Text + "    : القسط الشهري ", PatientFontheader1, Brushes.Purple, leftMargin + 350, yPos, new StringFormat());
            yPos += 33;
            //e.Graphics.DrawString("القسط الشهري", PatientFontheader1, Brushes.Purple, leftMargin + 10, yPos, new StringFormat());
            //e.Graphics.DrawString(txtPName.Text, PatientFontheader1, Brushes.Black, leftMargin + 250, 100, new StringFormat());
            // e.Graphics.DrawString(label16.Text, PatientFontheader1, Brushes.Purple, leftMargin + 395, yPos, new StringFormat());
            e.Graphics.DrawString(textBox1.Text + "     : المبلغ كامل ", PatientFontheader1, Brushes.Purple, leftMargin + 350, yPos, new StringFormat());
            yPos += 33;
            // e.Graphics.DrawString("لمبلغ كامل ", PatientFontheader1, Brushes.Purple, leftMargin + 410, yPos, new StringFormat());
            // e.Graphics.DrawString(txtPrice.Text, PatientFontheader1, Brushes.Black, leftMargin + 350,150 , new StringFormat());
            // e.Graphics.DrawString(label16.Text, PatientFontheader1, Brushes.Purple, leftMargin + 585, yPos, new StringFormat());
            e.Graphics.DrawString(p2.Text + "     : مبلغ القسط المتبقي ", PatientFontheader1, Brushes.Purple, leftMargin + 350, yPos, new StringFormat());
            yPos += 33;
            // e.Graphics.DrawString("مبلغ القسط المتبقي ", PatientFontheader1, Brushes.Purple, leftMargin + 600, yPos, new StringFormat());
            // e.Graphics.DrawString(label16.Text, PatientFontheader1, Brushes.Purple, leftMargin + 715, yPos, new StringFormat());
            e.Graphics.DrawString(M.Text + "      : الشهور المتبقية ", PatientFontheader1, Brushes.Purple, leftMargin + 350, yPos, new StringFormat());
            //yPos += 33;
           // e.Graphics.DrawString("الشهور المتبقية", PatientFontheader1, Brushes.Purple, leftMargin + 730, yPos, new StringFormat());
            yPos += 30;
            e.Graphics.DrawString("---------------------------------------------------------------------------------------", PatientFontheader1, Brushes.Purple, leftMargin + 0, yPos, new StringFormat());
            yPos -= 2;
            e.Graphics.DrawString("---------------------------------------------------------------------------------------", PatientFontheader1, Brushes.Purple, leftMargin + 0, yPos, new StringFormat());
        }
    }
}
