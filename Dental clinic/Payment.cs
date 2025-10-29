using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data.Common;
using System.Drawing.Printing;

namespace Dental_clinic
{
    public partial class Payment : Form
    {
        SqlConnection con;
        SqlDataAdapter da;
        SqlDataAdapter da2;
        SqlDataAdapter da3;
        DataTable dt;
        DataTable dt2;
        DataTable dt3;
        SqlCommand cmd;
        int mouseX, mouseY;
        bool mouseDown;
        public Payment()
        {
            this.Opacity = 0;
            InitializeComponent();
        }

        private void Payment_Load(object sender, EventArgs e)
        {
            dataGridView1.ForeColor = Color.Black;
            timer1.Interval = 50;
            timer1.Start();
            con = new SqlConnection("server=.;database=clinic;Integrated security=true;");
            String q = "select * from patients";
            con.Open();
            da = new SqlDataAdapter(q,con);
            dt = new DataTable();
            da.Fill(dt);
            cmbName.DataSource = dt;
            cmbName.DisplayMember = "patient_name";
            cmbName.ValueMember = "ID";
            loadInvoicesTableToDataGridView();
            loadTreatmentTableToCmb();
        }

        private void loadTreatmentTableToCmb()
        {
            String q3 = "Select * from Treatments";
            dt3 = new DataTable();
            da3 = new SqlDataAdapter(q3,con);
            da3.Fill(dt3);
            cmbTreatment.DataSource = dt3;
            cmbTreatment.DisplayMember = "treatment_Name";
            cmbTreatment.ValueMember = "ID";
        }
        private void loadInvoicesTableToDataGridView()
        {
            String q = @"Select i.ID,
            p.patient_name,
            t.treatment_Name,
            t.price,
            i.Invoice_Date,
            i.Total_Amount
            FROM Invoices i 
            INNER JOIN patients p ON i.patientID = p.ID 
            INNER JOIN Treatments t ON i.treatment_ID = t.ID
            ";
            dt2 = new DataTable();
            da2 = new SqlDataAdapter(q, con);
            da2.Fill(dt2);
            dataGridView1.DataSource = dt2;
        }



        private void btnSave_Click(object sender, EventArgs e)
        {
            try {
                    if (cmbName.Text.Trim() == "" || cmbTreatment.Text.Trim() == "" 
                    || dateTimePicker1.Text.Trim()=="" || txtPrice.Text.Trim() == "") 
                    { MessageBox.Show("Enter All Data"); }
                    else
                    {
                        String q = "insert into Invoices(patientID, Invoice_Date,Total_Amount, treatment_ID)" +
                        "VALUES(@patientID, @InvoiceDate,@Total_Amount, @treatment_ID)";
                        cmd = new SqlCommand(q, con);
                        cmd.Parameters.AddWithValue("@patientID", cmbName.SelectedValue);
                        cmd.Parameters.AddWithValue("@InvoiceDate", dateTimePicker1.Value.Date);
                        cmd.Parameters.AddWithValue("@Total_Amount", float.Parse(txtPrice.Text));
                        cmd.Parameters.AddWithValue("@treatment_ID", Convert.ToInt32(cmbTreatment.SelectedValue));
                        cmd.ExecuteNonQuery();
                        loadInvoicesTableToDataGridView();
                        MessageBox.Show("inserted");
                    }
                }
            catch (Exception ex)
            {MessageBox.Show(ex.Message);}
            
        }

        private void cmbTreatment_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbTreatment.SelectedItem is DataRowView row)
            {
                txtPrice.Text = row["Price"].ToString();
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            printPreviewDialog1.Document = printDocument1;
            printPreviewDialog1.ShowDialog();
        }

        private void printDocument1_PrintPage(object sender, PrintPageEventArgs e)
        {
            e.PageSettings.PaperSize = new PaperSize("Receipt", 300, 400);

            Font headerFont = new Font("Arial", 24, FontStyle.Bold);
            Font textFont = new Font("Arial", 18, FontStyle.Regular);

            Brush brush = Brushes.Black;

            float y = 100;
            
            e.Graphics.DrawString("فاتورة العلاج", headerFont, brush, new PointF(250, y));
            y += 60;
            e.Graphics.DrawString("المريض: "+ cmbName.Text, textFont , brush, new PointF(100,y));
            y += 40;
            e.Graphics.DrawString("التاريخ: "+ dateTimePicker1.Text, textFont, brush, new PointF(100,y));
            y += 40;
            e.Graphics.DrawString("العلاج: " + cmbTreatment.Text, textFont, brush, new PointF(100,y));
            y += 40;
            e.Graphics.DrawString("السعر: " + txtPrice.Text , textFont, brush, new PointF(100, y));
            y += 60;
            e.Graphics.DrawString("---------------------------------------------", textFont, brush, new PointF(100, y));
            y += 40;
            e.Graphics.DrawString("شكرا لزيارتكم", textFont, brush, new PointF(220,y));
        }

        private void lblBack_Click(object sender, EventArgs e)
        {
            MainForm mainForm = new MainForm();
            mainForm.Show();
            this.Hide();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if(this.Opacity < 1)
            {
                this.Opacity += 0.3;
            }
            else { timer1.Stop(); }
        }

        private void lblClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Payment_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
            mouseX = e.X;
            mouseY = e.Y;
        }

        private void Payment_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                int newX = Cursor.Position.X;
                int newY = Cursor.Position.Y;
                this.SetDesktopLocation(newX-mouseX, newY-mouseY);
            }
        }
        private void Payment_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }
    }

}
