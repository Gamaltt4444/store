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
using System.IO;

namespace InventorySystem1._0
{
    public partial class Addwcs : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source =.; Initial Catalog = Real; Integrated Security = True");

        //SqlConnection con = new SqlConnection(@"Data Source=MOSA-PC\SQLEXPRESS;Initial Catalog=aserzamzam12;Integrated Security=True");
        SqlCommand cm = new SqlCommand();
        SqlDataReader dr;
        public Addwcs()
        {

            InitializeComponent();
            w();
            WW();

        }
        public void w()
        {

            con.Open();
            cm = new SqlCommand("SELECT nid,Da,WT,Dpm,Mat,DpA,Ep,Sp,Ap,im1,im2,im3,im4,im5 from work", con);
            SqlDataAdapter sd = new SqlDataAdapter(cm);
            DataTable dt = new DataTable();
            sd.Fill(dt);
            dgvCustomer.DataSource = dt;
            con.Close();
            btnSave.Enabled = true;
            btnUpdate.Enabled = false;
            button5.Enabled = false;
            //dgvCustomer.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

        }
        public void WW()
        {
            if (txtCName.Text == "" && textBox2.Text == "")
            {
                label13.Text = "0";

            }
            else
            {

                double t1 = Convert.ToInt32(textBox2.Text);
                double t2 = Convert.ToInt32(txtCName.Text);
                double t3 = t1 * t2;
                label13.Text = t3.ToString();

            }
        }
        private void Addwcs_Load(object sender, EventArgs e)
        {
            w();
            WW();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtCPhone_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtCName_TextChanged(object sender, EventArgs e)
        {

        }
        Image[] cimg;
        int pos = 0;

        private void bt_Exit_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Multiselect = true;
            ofd.Filter = "Image|*.JPG; *.PNG; *.GIF; *.BMP";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                int i = 0;
                cimg = new Image[10];
                foreach (string filename in ofd.FileNames)
                {
                    for (; i < 5; i++)
                    {

                        cimg[i] = Image.FromFile(filename);
                        break;

                    }
                    i++;
                }
                pictureBox1.Image = cimg[0];
                pictureBox2.Image = cimg[0];
                pictureBox3.Image = cimg[1];
                pictureBox4.Image = cimg[2];
                pictureBox5.Image = cimg[3];
                pictureBox6.Image = cimg[4];


            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            pos--;
            if (pos <= 0)
            {
                pictureBox1.Image = cimg[0];
            }
            else
            {
                pictureBox1.Image = cimg[pos];
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            pos++;
            if (pos >= 4)
            {
                pictureBox1.Image = cimg[4];
                pos = 4;
            }
            else
            {
                pictureBox1.Image = cimg[pos];
            }

        }

        private void btnSave_Click(object sender, EventArgs e)
        {

        }

        private void btnSave_Click_1(object sender, EventArgs e)
        {

            if (txtCName.Text == "" && textBox2.Text == "")
            {
                label13.Text = "0";

            }
            else
            {

                double t1 = Convert.ToInt32(textBox2.Text);
                double t2 = Convert.ToInt32(txtCName.Text);
                double t3 = t1 * t2;
                label13.Text = t3.ToString();

            }

            try
            {

                if (comboCat.Text == "")
                {
                    MessageBox.Show("  من فضلك ادخال نوع المكان", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;

                }
                if (txtCName.Text == "")
                {
                    MessageBox.Show(" من فضلك ادخال  سعر متر الدهان", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;

                }
                if (textBox2.Text == "")
                {
                    MessageBox.Show(" من فضلك ادخال  مساحة المكان  ", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;

                }
                if (txtCPhone.Text == "")
                {
                    MessageBox.Show(" من فضلك ادخال   تكاليف الكهرباء ", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;

                }
                if (textBox1.Text == "")
                {
                    MessageBox.Show(" من فضلك ادخال   تكاليف السباكة ", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;

                }
                


                if (MessageBox.Show("هل انت متاكد من حفظ البيانات ؟  ", "جاري الحفظ", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {



                    MemoryStream ma = new MemoryStream();
                    MemoryStream ma1 = new MemoryStream();
                    MemoryStream ma2 = new MemoryStream();
                    MemoryStream ma3 = new MemoryStream();
                    MemoryStream ma4 = new MemoryStream();

                    pictureBox2.Image.Save(ma, System.Drawing.Imaging.ImageFormat.Png);
                    pictureBox3.Image.Save(ma1, System.Drawing.Imaging.ImageFormat.Png);
                    pictureBox4.Image.Save(ma2, System.Drawing.Imaging.ImageFormat.Png);
                    pictureBox5.Image.Save(ma3, System.Drawing.Imaging.ImageFormat.Png);
                    pictureBox6.Image.Save(ma4, System.Drawing.Imaging.ImageFormat.Png);

                    var _cover = ma.ToArray();
                    var _cover1 = ma1.ToArray();
                    var _cover2 = ma2.ToArray();
                    var _cover3 = ma3.ToArray();
                    var _cover4 = ma4.ToArray();
                    // pictureBox1.Image.Save(ma,System.Drawing.Imaging.ImageFormat.)
                    //pictureBox1.Image = Image.FromFile(openFileDialog1.FileName);
                    //Kat();,im2,im3,im4,im5  ,@im2,@im3,@im4,@im5
                    cm = new SqlCommand("INSERT INTO work (Da,WT,Dpm,Mat,DpA,Ep,Sp,Ap,im1,im2,im3,im4,im5 )VALUES(@Da,@WT,@Dpm,@Mat,@DpA,@Ep,@Sp,@Ap,@im1,@im2,@im3,@im4,@im5)", con);
                    cm.Parameters.AddWithValue("@Da", dateTimePicker1.Value.Date);
                    cm.Parameters.AddWithValue("@WT", comboCat.Text);
                    cm.Parameters.AddWithValue("@Dpm", txtCName.Text);
                    cm.Parameters.AddWithValue("@Mat", textBox2.Text);
                    cm.Parameters.AddWithValue("@DpA", label13.Text);
                    cm.Parameters.AddWithValue("@Ep", txtCPhone.Text);
                    cm.Parameters.AddWithValue("@Sp", textBox1.Text);
                    cm.Parameters.AddWithValue("@Ap", textBox3.Text);
                    cm.Parameters.AddWithValue("@im1", _cover);
                    cm.Parameters.AddWithValue("@im2", _cover1);
                    cm.Parameters.AddWithValue("@im3", _cover2);
                    cm.Parameters.AddWithValue("@im4", _cover3);
                    cm.Parameters.AddWithValue("@im5", _cover4);
                    con.Open();
                    cm.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("تم حفظ اليبانات بنجاح ");
                    //LoadCustomer();
                    Clear();
                    //Kat();
                    WW();
                    w();


                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

        }

        private void dgvCustomer_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            Dit productModule = new Dit();
            string colName = dgvCustomer.Columns[e.ColumnIndex].Name;
            if (colName == "Delete")
            {

                productModule.comboCat.Text = dgvCustomer.Rows[e.RowIndex].Cells[4].Value.ToString();
                productModule.txtCName.Text = dgvCustomer.Rows[e.RowIndex].Cells[5].Value.ToString();
                productModule.textBox2.Text = dgvCustomer.Rows[e.RowIndex].Cells[6].Value.ToString();
                productModule.label13.Text = dgvCustomer.Rows[e.RowIndex].Cells[7].Value.ToString();
                productModule.txtCPhone.Text = dgvCustomer.Rows[e.RowIndex].Cells[8].Value.ToString();
                productModule.textBox1.Text = dgvCustomer.Rows[e.RowIndex].Cells[9].Value.ToString();
                productModule.textBox3.Text = dgvCustomer.Rows[e.RowIndex].Cells[10].Value.ToString();
                //pictureBox1.Text = dgvCustomer.CurrentRow.Cells[10].Value.ToString();
                byte[] imgData4 = (byte[])dgvCustomer.CurrentRow.Cells[11].Value;
                byte[] imgData = (byte[])dgvCustomer.CurrentRow.Cells[12].Value;
                byte[] imgData1 = (byte[])dgvCustomer.CurrentRow.Cells[13].Value;
                byte[] imgData2 = (byte[])dgvCustomer.CurrentRow.Cells[14].Value;
                byte[] imgData3 = (byte[])dgvCustomer.CurrentRow.Cells[15].Value;
                MemoryStream ms = new MemoryStream(imgData);
                MemoryStream ms1 = new MemoryStream(imgData1);
                MemoryStream ms2 = new MemoryStream(imgData2);
                MemoryStream ms3 = new MemoryStream(imgData3);
                MemoryStream ms4 = new MemoryStream(imgData4);
                productModule.pictureBox1.Image = Image.FromStream(ms);
                productModule.pictureBox2.Image = Image.FromStream(ms1);
                productModule.pictureBox3.Image = Image.FromStream(ms2);
                productModule.pictureBox4.Image = Image.FromStream(ms3);
                productModule.pictureBox5.Image = Image.FromStream(ms4);
                productModule.pictureBox2.Visible = false;
                productModule.pictureBox3.Visible = false;
                productModule.pictureBox4.Visible = false;
                productModule.pictureBox5.Visible = false;
                productModule.button2.Visible = false;
                productModule.button3.Visible = false;
                productModule.button5.Visible = false;
                productModule.button6.Visible = false;
                //button5.Visible = false;
                productModule.button7.Visible = false;
                productModule.button8.Visible = false;
                productModule.button9.Visible = true;
                this.Close();
                productModule.ShowDialog();


            }


            else if (colName == "Edit")
            {
                lblCId.Text = dgvCustomer.Rows[e.RowIndex].Cells[2].Value.ToString();
                comboCat.Text = dgvCustomer.Rows[e.RowIndex].Cells[4].Value.ToString();
                txtCName.Text = dgvCustomer.Rows[e.RowIndex].Cells[5].Value.ToString();
                textBox2.Text = dgvCustomer.Rows[e.RowIndex].Cells[6].Value.ToString();
                label13.Text = dgvCustomer.Rows[e.RowIndex].Cells[7].Value.ToString();
                txtCPhone.Text = dgvCustomer.Rows[e.RowIndex].Cells[8].Value.ToString();
                textBox1.Text = dgvCustomer.Rows[e.RowIndex].Cells[9].Value.ToString();
                textBox3.Text = dgvCustomer.Rows[e.RowIndex].Cells[10].Value.ToString();
                
                btnSave.Enabled = false;
                btnUpdate.Enabled = true;
                button5.Enabled = true;

            }

            else if (colName == "Det")
            {
                if (MessageBox.Show("هل انت متاكد من حذف البيانات", "جاري الحذف", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    con.Open();
                    cm = new SqlCommand("DELETE FROM Work WHERE nid LIKE '" + dgvCustomer.Rows[e.RowIndex].Cells[2].Value.ToString() + "'", con);
                    //dgvCustomer.Rows[e.RowIndex].Cells[3].Value.ToString() + "'", con);
                    cm.ExecuteNonQuery();
                    con.Close();
                    Clear();

                    WW();
                    w();
                    MessageBox.Show("تم الحذف بنجاح");
                    // MessageBox.Show("ملحوظه مهم جدا يرجاء التاكد من مسح جميع بيانات الخوارج في نهاية اليوم حتي لا يتم حسبها في اليوم التالي");
                }



            }


        }
        public void Clear()
        {
            textBox1.Clear();
            textBox2.Clear();
            txtCPhone.Clear();
            txtCName.Clear();
            textBox3.Clear();
            comboCat.Text = "";
           // WW();
           // w();



        }
        private void btnClear_Click(object sender, EventArgs e)
        {
            Clear();
            btnSave.Enabled = true;
            btnUpdate.Enabled = false;
            w();
            WW();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            WW();
            try
            {
                if (MessageBox.Show("هل انت متاكد من تعديل البيانات  ", "جاري التعديل", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {

                    //(Da, WT, Dpm, Mat, DpA, Ep, Sp, Ap, im1, im2, im3, im4, im5) VALUES(@Da, @WT, @Dpm, @Mat, @DpA, @Ep, @Sp, @Ap, @im1, @im2, @im3, @im4, @im5)"
                    cm = new SqlCommand("UPDATE Work SET WT=@WT,Dpm=@Dpm,Mat=@Mat,DpA=@DpA,Ep=@Ep,Sp=@Sp,Ap=@Ap WHERE nid LIKE '" + lblCId.Text + "' ", con);
                    cm.Parameters.AddWithValue("@WT", comboCat.Text);
                    cm.Parameters.AddWithValue("@Dpm", txtCName.Text);
                    cm.Parameters.AddWithValue("@Mat", textBox2.Text);
                    cm.Parameters.AddWithValue("@DpA", label13.Text);
                    cm.Parameters.AddWithValue("@Ep", txtCPhone.Text);
                    cm.Parameters.AddWithValue("@Sp", textBox1.Text);
                    cm.Parameters.AddWithValue("@Ap", textBox3.Text);

                    con.Open();
                    //w();

                    cm.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("تم تعديل اليبانات بنجاح ");
                    w();
                    WW();
                    btnSave.Enabled = true;
                    Clear();


                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            Clear();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            con.Open();
            cm = new SqlCommand("SELECT nid,Da,WT,Dpm,Mat,DpA,Ep,Sp,Ap,im1,im2,im3,im4,im5 from work where Da between @fdn and @sdn", con);
            cm.Parameters.AddWithValue("@fdn", dateTimePicker2.Value.Date);
            cm.Parameters.AddWithValue("@sdn", dateTimePicker3.Value.Date);
            SqlDataAdapter sd = new SqlDataAdapter(cm);
            DataTable dt = new DataTable();
            sd.Fill(dt);
            dgvCustomer.DataSource = dt;
            con.Close();
            Clear();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            MemoryStream ma = new MemoryStream();
            MemoryStream ma1 = new MemoryStream();
            MemoryStream ma2 = new MemoryStream();
            MemoryStream ma3 = new MemoryStream();
            MemoryStream ma4 = new MemoryStream();

            pictureBox2.Image.Save(ma, System.Drawing.Imaging.ImageFormat.Png);
            pictureBox2.Image.Save(ma1, System.Drawing.Imaging.ImageFormat.Png);
            pictureBox3.Image.Save(ma2, System.Drawing.Imaging.ImageFormat.Png);
            pictureBox4.Image.Save(ma3, System.Drawing.Imaging.ImageFormat.Png);
            pictureBox5.Image.Save(ma4, System.Drawing.Imaging.ImageFormat.Png);

            var _cover = ma.ToArray();
            var _cover1 = ma1.ToArray();
            var _cover2 = ma2.ToArray();
            var _cover3 = ma3.ToArray();
            var _cover4 = ma4.ToArray();
            //im1, im2, im3, im4, im5)
            try
            {

                

                if (MessageBox.Show("هل انت متاكد من تعديل الصور  ", "جاري التعديل", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    cm = new SqlCommand("UPDATE Work SET im1=@im1,im2=@im2,im3=@im3,im4=@im4,im5=@im5 WHERE nid LIKE '" + lblCId.Text + "' ", con);
                    cm.Parameters.AddWithValue("@im1", _cover);
                    cm.Parameters.AddWithValue("@im2", _cover1);
                    cm.Parameters.AddWithValue("@im3", _cover2);
                    cm.Parameters.AddWithValue("@im4", _cover3);
                    cm.Parameters.AddWithValue("@im5", _cover4);
                    con.Open();
                    cm.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("تم تعديل الصور بنجاح ");
                    w();
                    WW();
                    btnSave.Enabled = true;
                    Clear();
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            Clear();

        }
    }
}

