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


namespace Dental_clinic
{
    public partial class Reports : Form
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlCommand cmd2;
        SqlDataAdapter da;
        DataTable dt;
        int mouseX, mouseY;
        bool mouseDown;
        public Reports()
        {
            this.Opacity = 0;
            InitializeComponent();
        }

        private void btnTodayReport_Click(object sender, EventArgs e)
        {
            No_Patients();
            Revenues();
        }

        private void Reports_Load(object sender, EventArgs e)
        {
            timer1.Interval = 50;
            timer1.Start();
            con = new SqlConnection("server =.;database= clinic;integrated security= true;");
            con.Open();
        }
        
        private void No_Patients()
        {
            String q = "Select COUNT(DISTINCT PatientID) from Invoices Where Invoice_Date = @Invoice_Date";
            cmd = new SqlCommand(q, con);
            cmd.Parameters.AddWithValue("@Invoice_Date", DateTime.Today);
            object result = cmd.ExecuteScalar();
            if (result == DBNull.Value) 
            { lblNoOfPatients.Text = "0"; }
            else { lblNoOfPatients.Text = result.ToString(); }
        }

        private void Revenues()
        {
            String q2 = "SELECT (SUM(Total_Amount)) from Invoices where Invoice_Date = @Invoice_Date";
            cmd2 = new SqlCommand(q2, con);
            cmd2.Parameters.AddWithValue("@Invoice_Date", DateTime.Today);
            object result2 = cmd2.ExecuteScalar();
            if (result2 == DBNull.Value)
            { lblRevenues.Text = "0"; }
            else { lblRevenues.Text = result2.ToString(); }
        }

        private void No_Patients_Monthly()
        {
            String q = "Select COUNT(DISTINCT PatientID) from Invoices Where Month(Invoice_Date) = @Month AND YEAR(Invoice_Date) = @Year";
            cmd = new SqlCommand(q, con);
            cmd.Parameters.AddWithValue("@Month", DateTime.Now.Month);
            cmd.Parameters.AddWithValue("@Year", DateTime.Now.Year);
            object result = cmd.ExecuteScalar();
            if (result == DBNull.Value)
            { lblNoOfPatients.Text = "0"; }
            else { lblNoOfPatients.Text = result.ToString(); }
        }

        private void Revenues_Monthly()
        {
            String q2 = "SELECT (SUM(Total_Amount)) from Invoices Where Month(Invoice_Date) = @Month AND YEAR(Invoice_Date) = @Year";
            cmd2 = new SqlCommand(q2, con);
            cmd2.Parameters.AddWithValue("@Month", DateTime.Now.Month);
            cmd2.Parameters.AddWithValue("@Year", DateTime.Now.Year);
            object result2 = cmd2.ExecuteScalar();
            if (result2 == DBNull.Value)
            { lblRevenues.Text = "0"; }
            else { lblRevenues.Text = result2.ToString(); }
        }

        private void btnMonthlyReport_Click(object sender, EventArgs e)
        {
            No_Patients_Monthly();
            Revenues_Monthly();
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

        private void Reports_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
            mouseX = e.X;
            mouseY = e.Y;
        }

        private void Reports_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                int newX = Cursor.Position.X;
                int newY = Cursor.Position.Y;
                this.SetDesktopLocation(newX - mouseX, newY - mouseY);
            }
        }

        private void Reports_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }
    }
}
