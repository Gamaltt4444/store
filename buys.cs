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
    public partial class buys : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=.;Initial Catalog=Real;Integrated Security=True");
        SqlCommand cm = new SqlCommand();
        SqlCommand cm1 = new SqlCommand();
        SqlDataReader dr;

        public buys()
        {
            InitializeComponent();
            Loamand();
            Loadprod();
            LoidQ();
            LoadCategory();

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
        public void LoidQ()
        {
            if (txtPQty.Text == "" && tNP.Text == "")
            {
                label13.Text = "0";
                Q.Text = "0";
                Q1.Text = "0";
                txtPPrice.Text = "0";
                P.Text = "0";
                //textBox2.Text = "0";

            }
            else
            {

                double t1 = Convert.ToInt32(txtPQty.Text);
                double t2 = Convert.ToInt32(tNP.Text);
                double t3 = t2 / t1;
                label13.Text = t3.ToString();

            }
        }
        public void Loamand()
        {

         
            
            int i = 0;
            dgvProduct.Rows.Clear();
            cm = new SqlCommand("SELECT pid, pname FROM Mad WHERE CONCAT(pid, pname) LIKE '%" + txtSearch.Text + "%'", con);

            con.Open();
            dr = cm.ExecuteReader();
            while (dr.Read())
            {
                i++;
                dgvProduct.Rows.Add(i, dr[0].ToString(), dr[1].ToString());
            }
            dr.Close();
            con.Close();
            int n = 0;
            dataGridView1.Rows.Clear();
            cm = new SqlCommand("SELECT pid, pname FROM Mord WHERE CONCAT(pid, pname) LIKE '%" + textBox1.Text + "%'", con);

            con.Open();
            dr = cm.ExecuteReader();
            while (dr.Read())
            {
                n++;
                dataGridView1.Rows.Add(n, dr[0].ToString(), dr[1].ToString());
            }
            dr.Close();
            con.Close();
            btnSave.Enabled = true;
            btnUpdate.Enabled = false;
        }

        public void Loadprod()
        {
            int i = 0;
            dataGridView2.Rows.Clear();
            cm = new SqlCommand("SELECT pid, pname,pprice,pp,pqty, pdescription, pcategory,pqty1,pprice1,t1 FROM tbProduct WHERE CONCAT(pid, pname,pprice,pp,pqty, pdescription, pcategory,pqty1,pprice1,t1) LIKE '%" + txtSearchProd.Text + "%'", con);
            con.Open();
            dr = cm.ExecuteReader();
            while (dr.Read())
            {
                i++;
                dataGridView2.Rows.Add(i, dr[0].ToString(), dr[1].ToString(), dr[2].ToString(), dr[3].ToString(), dr[4].ToString(), dr[5].ToString(), dr[6].ToString(), dr[7].ToString(), dr[8].ToString(),dr[9].ToString());
            }
            dr.Close();
            con.Close();
            int n = 0;
            double total = 0;
            dgvOrder.Rows.Clear();
            cm = new SqlCommand("SELECT * FROM tbBuy1 ", con);

            con.Open();
            dr = cm.ExecuteReader();
            while (dr.Read())
            {
                n++;
                dgvOrder.Rows.Add(n, dr[0].ToString(), dr[1].ToString(), dr[2].ToString(), dr[3].ToString(), dr[4].ToString(), dr[5].ToString(), dr[6].ToString(), dr[7].ToString(), dr[8].ToString());
                total += Convert.ToInt32(dr[7].ToString());
            }
            dr.Close();
            con.Close();
            label23.Text = total.ToString();
            btnSave.Enabled = true;
            btnUpdate.Enabled = false;

        }


        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            id.Text = dataGridView2.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtPName.Text = dataGridView2.Rows[e.RowIndex].Cells[2].Value.ToString();
            P.Text = dataGridView2.Rows[e.RowIndex].Cells[9].Value.ToString();
            PP.Text = dataGridView2.Rows[e.RowIndex].Cells[9].Value.ToString();
            //tNP.Text = dataGridView2.Rows[e.RowIndex].Cells[9].Value.ToString();
            label13.Text = dataGridView2.Rows[e.RowIndex].Cells[4].Value.ToString();
            label22.Text = dataGridView2.Rows[e.RowIndex].Cells[10].Value.ToString();
            Q.Text = dataGridView2.Rows[e.RowIndex].Cells[5].Value.ToString();
            txtPDes.Text = dataGridView2.Rows[e.RowIndex].Cells[6].Value.ToString();
            comboCat.Text = dataGridView2.Rows[e.RowIndex].Cells[7].Value.ToString();
            Q1.Text = dataGridView2.Rows[e.RowIndex].Cells[8].Value.ToString();
            QQ.Text = dataGridView2.Rows[e.RowIndex].Cells[8].Value.ToString();
            // txtPQty.Text = dataGridView2.Rows[e.RowIndex].Cells[8].Value.ToString();
            txtPPrice.Text = dataGridView2.Rows[e.RowIndex].Cells[3].Value.ToString();
            btnSave.Enabled = false;
            btnUpdate.Enabled = true;

            string colName = dataGridView2.Columns[e.ColumnIndex].Name;
           
            
             if (colName == "Delet")
            {
                if (MessageBox.Show("هل انت متاكد انك تريد مسح هذا الصنف ؟ ", " جاري المسح ", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    con.Open();
                    cm = new SqlCommand("DELETE FROM tbProduct WHERE pid LIKE '" + dataGridView2.Rows[e.RowIndex].Cells[1].Value.ToString() + "'", con);
                    cm.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("تم المسح بنجاح");
                    Loamand();
                    Loadprod();
                    //LoidQ();
                    Clear();
                }
            }

        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            Loamand();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            Loamand();
        }

        private void dgvProduct_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtCId.Text = dgvProduct.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtCName.Text = dgvProduct.Rows[e.RowIndex].Cells[2].Value.ToString();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtCId.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtCName.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
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
                if (tNP.Text == "")
                {
                    MessageBox.Show(" من فضلك ادخال السعر", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;

                }

                if (MessageBox.Show(" هل انت متاكد انك تريد حفظ هذاالصنف ؟", "جاري الحفظ", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Loadprod();
                    Loamand();
                    LoidQ();


                    cm = new SqlCommand("INSERT INTO tbProduct(pname,pqty,pprice,pp,pdescription,pcategory,pprice1,pqty1,t1)VALUES(@pname, @pqty, @pprice, @pp, @pdescription, @pcategory,@pprice1,@pqty1,@t1)", con);
                    cm.Parameters.AddWithValue("@pname", txtPName.Text);
                    cm.Parameters.AddWithValue("@pqty", Convert.ToInt16(txtPQty.Text));
                    cm.Parameters.AddWithValue("@pqty1", Convert.ToInt16(Q.Text));
                    cm.Parameters.AddWithValue("@pprice1", Convert.ToInt16(txtPPrice.Text));
                    cm.Parameters.AddWithValue("@pprice", Convert.ToInt16(tNP.Text));
                    cm.Parameters.AddWithValue("@pp", Convert.ToInt16(label13.Text));
                    cm.Parameters.AddWithValue("@pdescription", txtPDes.Text);
                    cm.Parameters.AddWithValue("@pcategory", comboCat.Text);
                    cm.Parameters.AddWithValue("@t1", IDD.Text);
                    // double t1 = Convert.ToInt32(txtPQty.Text);
                    // Q.Text = t1.ToString();

                    con.Open();
                    cm.ExecuteNonQuery();

                    con.Close();
                    MessageBox.Show("تم الحفظ بنجاح");
                    Clear();
                    Loadprod();
                    Loamand();
                    LoidQ();
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            Loadprod();
            Loamand();
            LoidQ();



        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {


                if (txtPName.Text == "")
                {
                    MessageBox.Show(" من فضلك ادخال اسم المنتح", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;

                }
                if (Q1.Text == "")
                {
                    MessageBox.Show(" من فضلك ادخال الكمية", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;

                }
                if (P.Text == "")
                {
                    MessageBox.Show(" من فضلك ادخال السعر", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;

                }
                if (txtCId.Text == "")
                {
                    MessageBox.Show(" من فضلك ادخال كود المندوب او المورد", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;

                }
                if (txtCName.Text == "")
                {
                    MessageBox.Show(" من فضلك ادخال اسم المندوب او المورد", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;

                }

                if (P.Text == "0" && Q1.Text == "0")
                {
                    double t1 = Convert.ToInt32(Q.Text);
                    double t2 = Convert.ToInt32(txtPPrice.Text);
                    P.Text = t2.ToString();
                    Q1.Text = t1.ToString();


                }
                

                if (MessageBox.Show("هل انت متاكد من اضافه العنصر؟", "جاري الحفظ", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {


                    
                    cm1 = new SqlCommand("INSERT INTO tbBuy(odate,Mid,Mnam,pid,pnam, qty, price, total)VALUES(@odate, @Mid, @Mnam,@pid,@pnam, @qty, @price, @total)", con);
                    cm1.Parameters.AddWithValue("@odate", dtOrder.Value);
                    cm1.Parameters.AddWithValue("@Mid", Convert.ToInt32(txtCId.Text));
                    cm1.Parameters.AddWithValue("@Mnam", txtCName.Text);
                    cm1.Parameters.AddWithValue("@pid", Convert.ToInt32(id.Text));
                    cm1.Parameters.AddWithValue("@pnam", txtPName.Text);
                    cm1.Parameters.AddWithValue("@qty", Convert.ToInt32(Q1.Text));
                    cm1.Parameters.AddWithValue("@price", Convert.ToInt32(label13.Text));
                    cm1.Parameters.AddWithValue("@total", Convert.ToInt32(P.Text));
                    con.Open();
                    cm1.ExecuteNonQuery();
                    con.Close();

                    cm = new SqlCommand("INSERT INTO tbBuy1(Mid,Mnam,pid,pnam, qty, price, total,t1)VALUES( @Mid, @Mnam,@pid,@pnam, @qty, @price, @total,@t1)", con);
                    //cm.Parameters.AddWithValue("@odate", dtOrder.Value);
                    cm.Parameters.AddWithValue("@Mid", Convert.ToInt32(txtCId.Text));
                    cm.Parameters.AddWithValue("@Mnam", txtCName.Text);
                    cm.Parameters.AddWithValue("@pid", Convert.ToInt32(id.Text));
                    cm.Parameters.AddWithValue("@pnam", txtPName.Text);
                    cm.Parameters.AddWithValue("@qty", Convert.ToInt32(Q1.Text));
                    cm.Parameters.AddWithValue("@price", Convert.ToInt32(label13.Text));
                    cm.Parameters.AddWithValue("@t1", Convert.ToInt32(label22.Text));
                    cm.Parameters.AddWithValue("@total", Convert.ToInt32(P.Text));
                    con.Open();
                    cm.ExecuteNonQuery();
                    con.Close();
                    Loamand();
                    Loadprod();
                    

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            Loamand();
            Loadprod();
            Clear();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {

           
           
            try
            {
                if (txtPQty.Text == "")
                {
                    MessageBox.Show(" من فضلك ادخال الكمية الجديدة", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;

                }
                if (tNP.Text == "")
                {
                    MessageBox.Show(" من فضلك السعر الجديد", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;

                }
                if (txtPQty.Text == "" && tNP.Text == "")
                {
                    label13.Text = "0";
                    Q.Text = "0";
                    Q1.Text = "0";
                    txtPPrice.Text = "0";
                    //textBox2.Text = "0";

                }
                else
                {
                    double t1 = Convert.ToInt32(txtPQty.Text);
                    double t2 = Convert.ToInt32(Q.Text);
                    double t10 = t2 + t1;
                    double t5 = Convert.ToInt32(tNP.Text);
                    Double t6 = Convert.ToInt32(txtPPrice.Text);
                    double t3 = t5 / t1;
                    label13.Text = t3.ToString();
                    double t7 = t5 + t6;
                    Q.Text = t10.ToString();
                    txtPPrice.Text = t7.ToString();
                    double t8 = Convert.ToInt32(Q.Text);
                    double t9 = Convert.ToInt32(txtPPrice.Text);
                    
                }
                if(label13.Text==label22.Text)
                {
                    MessageBox.Show(" ! سعر الوحدة لم يتغير", "ملحوظة", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    
                        if (MessageBox.Show("هل انت متاكد انك تريد تعديل سعر الوحدة الي السعر الجديد ؟", "جاري التعديل", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            double tW2 = Convert.ToInt32(label13.Text);
                            double tW1 = Convert.ToInt32(label22.Text);
                            label13.Text = tW2.ToString();
                        }
                        else  
                        {
                            double tW2 = Convert.ToInt32(label13.Text);
                            double tW1 = Convert.ToInt32(label22.Text);
                            label13.Text = tW1.ToString();
                        }
                    
                    
                }

                if (MessageBox.Show("هل انت متاكد انك تريد تعديل هذا الصنف ؟", "جاري التعديل", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                   
                    cm = new SqlCommand("UPDATE tbProduct SET pname = @pname,pqty=@pqty,pp=@pp,pprice=@pprice, pdescription=@pdescription, pcategory=@pcategory,pqty1=@pqty1,pprice1=@pprice1 WHERE pid LIKE '" + id.Text + "' ", con);
                    cm.Parameters.AddWithValue("@pname", txtPName.Text);
                    cm.Parameters.AddWithValue("@pqty", Convert.ToInt16(Q.Text));
                    cm.Parameters.AddWithValue("@pqty1", Convert.ToInt16(txtPQty.Text));
                    cm.Parameters.AddWithValue("@pprice", Convert.ToInt16(txtPPrice.Text));
                    cm.Parameters.AddWithValue("@pprice1", Convert.ToInt16(tNP.Text));
                    cm.Parameters.AddWithValue("@pp", Convert.ToInt16(label13.Text));
                    cm.Parameters.AddWithValue("@pdescription", txtPDes.Text);
                    cm.Parameters.AddWithValue("@pcategory", comboCat.Text);
                    con.Open();
                    cm.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("تم التعديل بنجاح");
                    Loamand();
                    Loadprod();
                    Clear();
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            Loamand();
            Loadprod();
        }
        public void Clear()
        {
            id.Clear();
            P.Text = "0";
            txtPName.Clear();
            txtPQty.Clear();
            txtPPrice.Text = "0";
            tNP.Clear();
            txtPDes.Clear();
            comboCat.Text = "";
            label13.Text = "0";
            Q.Text = "0";
            Q1.Text = "0";
        }

        private void buys_Load(object sender, EventArgs e)
        {

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            Clear();
            btnSave.Enabled = true;
            btnUpdate.Enabled = false;
        }

        private void txtSearchProd_TextChanged(object sender, EventArgs e)
        {
            Loadprod();
        }

        private void dgvOrder_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string colName = dgvOrder.Columns[e.ColumnIndex].Name;

            if (colName == "Delete")
            {

                if (MessageBox.Show("هل انت متاكد من حذف هذا الاوردر؟", "جاري الحذف", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    IDD.Text = dgvOrder.Rows[e.RowIndex].Cells[1].Value.ToString();
                   
                    cm= new SqlCommand("DELETE FROM tbBuy WHERE idd LIKE '" + IDD.Text + "'", con);
                    con.Open();
                    cm.ExecuteNonQuery();
                    con.Close();
                    cm = new SqlCommand("DELETE FROM tbBuy1 where idd  LIKE '" + dgvOrder.Rows[e.RowIndex].Cells[1].Value.ToString() + "'", con);
                    con.Open();
                    cm.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("!تم الحذف بنجاح");
                    cm = new SqlCommand("UPDATE tbProduct SET pqty=(pqty-@pqty),pprice=(pprice-@pprice1) WHERE pid LIKE '" + dgvOrder.Rows[e.RowIndex].Cells[4].Value.ToString() + "' ", con);
                    cm.Parameters.AddWithValue("@pqty", Convert.ToInt32(QQ.Text));
                    cm.Parameters.AddWithValue("@pprice1", Convert.ToInt16(PP.Text));
                    con.Open();
                    cm.ExecuteNonQuery();
                    con.Close();
                    label22.Text = dgvOrder.Rows[e.RowIndex].Cells[9].Value.ToString();
                    //label13.Text = dgvOrder.Rows[e.RowIndex].Cells[7].Value.ToString();
                   // cm = new SqlCommand("UPDATE tbProduct SET pp = (pprice/pqty) WHERE pid LIKE '" + dgvOrder.Rows[e.RowIndex].Cells[4].Value.ToString() + "' ", con);
                    cm = new SqlCommand("UPDATE tbProduct SET pp = @pp WHERE pid LIKE '" + dgvOrder.Rows[e.RowIndex].Cells[4].Value.ToString() + "' ", con);
                    cm.Parameters.AddWithValue("@pp", Convert.ToInt32(label22.Text));
                    con.Open();
                    cm.ExecuteNonQuery();
                    con.Close();

                }
            }
            Loamand();
            Loadprod();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            id.Clear();
            P.Clear();
            txtPName.Clear();
            txtPQty.Clear();
            txtPPrice.Clear();
            tNP.Clear();
            txtPDes.Clear();
            comboCat.Text = "";
            label13.Text = "0";
            Q.Clear();
            Q1.Clear();
            txtCName.Clear();
            txtCId.Clear();
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


                    cm = new SqlCommand("DELETE  FROM tbBuy1", con);
                    con.Open();
                    cm.ExecuteNonQuery();
                    con.Close();
                    Clear();
                    Loamand();
                    Loadprod();

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
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
            e.Graphics.DrawString(" فاتورة مشتريات  ", PatientFontheader1, Brushes.Purple, leftMargin + 330, yPos, new StringFormat());
            yPos += 60;
            e.Graphics.DrawString(" للتشطيبات والدهانات ", PatientFontheader2, Brushes.Purple, leftMargin + 550, yPos, new StringFormat());
            yPos += 60;
            e.Graphics.DrawString(dtOrder.Text + ": التاريخ ", PatientFontheader1, Brushes.Purple, leftMargin + 580, yPos, new StringFormat());
            yPos += 40;
            e.Graphics.DrawString("----------------------------------------------------------------" + " : مشتري من السيد ", PatientFontheader1, Brushes.Purple, leftMargin + 0, yPos, new StringFormat());
            yPos -= 10;
            e.Graphics.DrawString(txtCName.Text, PatientFontheader1, Brushes.Purple, leftMargin + 200, yPos, new StringFormat());
            yPos += 45;
            e.Graphics.DrawString("--------------------------------------------------------------------------------------", PatientFontheader1, Brushes.Purple, leftMargin + 0, yPos, new StringFormat());
            yPos -= 2;
            e.Graphics.DrawString("--------------------------------------------------------------------------------------", PatientFontheader1, Brushes.Purple, leftMargin + 0, yPos, new StringFormat());
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
            e.Graphics.DrawString("---------------------------------------------------------------------------------------", PatientFontheader1, Brushes.Purple, leftMargin + 0, yPos, new StringFormat());
            yPos -= 2;
            e.Graphics.DrawString("---------------------------------------------------------------------------------------", PatientFontheader1, Brushes.Purple, leftMargin + 0, yPos, new StringFormat());

            //e.Graphics.DrawString(UDQty.Text, PatientFontheader1, Brushes.Black, leftMargin + 350, 200, new StringFormat());
            yPos += 42;
            SizeF stringSize = new SizeF();
            for (int i = 0; i < dgvOrder.Rows.Count; i++)
            {
                //Num = dgvOrder.Rows[i].Cells[1].Value.ToString();
                nam = dgvOrder.Rows[i].Cells[5].Value.ToString();
                price = dgvOrder.Rows[i].Cells[7].Value.ToString();
                qut = dgvOrder.Rows[i].Cells[6].Value.ToString();
                tot = dgvOrder.Rows[i].Cells[8].Value.ToString();
                font = label16.Text;
                e.Graphics.DrawString(nam.ToUpper(), PatientNormal, Brushes.Purple, leftMargin + 10, yPos, new StringFormat());
                yPos += 1;
                tot = "                      " + price + "                     " + qut + "                    " + tot;
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
            e.Graphics.DrawString("-------------------------------------------------------------------------------------", PatientFontheader1, Brushes.Purple, leftMargin + 0, yPos, new StringFormat());
            yPos -= 2;
            e.Graphics.DrawString("-------------------------------------------------------------------------------------", PatientFontheader1, Brushes.Purple, leftMargin + 0, yPos, new StringFormat());


        }
    }
}
    
    

