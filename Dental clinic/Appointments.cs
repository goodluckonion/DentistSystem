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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Dental_clinic
{
    public partial class Appointments : Form
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataAdapter da;
        SqlDataAdapter da2;
        DataTable dt;
        DataTable dt2;
        int selectedAppointmentID;
        int mouseX, mouseY;
        bool mouseDown;
        public Appointments()
        {
            this.Opacity = 0;
            InitializeComponent();
        }

        private void Appointments_Load(object sender, EventArgs e)
        {
            dataGridView1.ForeColor = Color.Black;
            timer1.Interval = 50;
            timer1.Start();
            con = new SqlConnection("Server=.; database=clinic; integrated security=true;");
            con.Open();
            String q = "select ID,patient_name from patients";
            da = new SqlDataAdapter(q, con);
            dt = new DataTable();
            da.Fill(dt);
            cmbName.DataSource = dt;
            cmbName.DisplayMember = "patient_name";
            cmbName.ValueMember = "ID";
            //int n = dt.Rows.Count;
            //for(int i=0; i<n; i++)
            //{
            //    cmbName.Items.Add(dt.Rows[i]["patient_name"].ToString());
            //}
            loadAppointmentTableToDataGridView();
        }

        private void loadAppointmentTableToDataGridView() 
        {
            //string qq = @"SELECT 
            //    a.ID,
            //    p.ID,
            //    p.patient_name,
            //    a.Appointment_Date,
            //    a.Appointment_Time,
            //    a.appointment_State
            //FROM Appointments a
            //INNER JOIN patients p ON a.patient_ID = p.ID";

            String qq = @"Select a.ID,
                                 p.patient_name,
                                 a.Appointment_Date,
                                 a.Appointment_Time,
                                 a.Appointment_State
                          FROM Appointments a INNER JOIN patients p ON a.patient_ID = p.ID";
            dt2 = new DataTable();
            da2 = new SqlDataAdapter(qq, con);
            da2.Fill(dt2);
            dataGridView1.DataSource = dt2;
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if(cmbName.Text.Trim() == "" || cmbStatus.Text.Trim() == "" 
                    || dateTimePicker1.Text.Trim() == "" || dateTimePicker2.Text.Trim() == "")
                { MessageBox.Show("Fill All Data!"); }
                else
                {
                    string q = "INSERT INTO Appointments (patient_ID, Appointment_Date, Appointment_Time, appointment_State) " +
                               "VALUES (@patient_ID, @Date, @Time, @status)";

                    cmd = new SqlCommand(q, con);
                    cmd.Parameters.AddWithValue("@patient_ID", cmbName.SelectedValue);
                    cmd.Parameters.AddWithValue("@Date", dateTimePicker1.Value.Date); // نوع DateTime تلقائياً
                    cmd.Parameters.AddWithValue("@Time", dateTimePicker2.Value.TimeOfDay); // نوع TimeSpan تلقائياً
                    cmd.Parameters.AddWithValue("@status", cmbStatus.SelectedItem.ToString().Trim());

                    cmd.ExecuteNonQuery();
                    loadAppointmentTableToDataGridView();
                    MessageBox.Show("Inserted successfully!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btn_Delete_Click(object sender, EventArgs e)
        {
            if(selectedAppointmentID == 0)
            {
                MessageBox.Show("تنبيه","يرجى اختيار صف من الجدول قبل الحذف ", MessageBoxButtons.OK);
                return;
            }
            DialogResult result = MessageBox.Show(" هل انت متاكد انك تريد حذف هذا الموعد؟ ",
                "تاكيد الحذف",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button2);
            if(result == DialogResult.Yes)
            {
                String q3 = "delete Appointments Where ID=@id";
                cmd = new SqlCommand(q3,con);
                cmd.Parameters.AddWithValue("@id", selectedAppointmentID);
                cmd.ExecuteNonQuery();
                loadAppointmentTableToDataGridView();
                MessageBox.Show("Deleted");
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                selectedAppointmentID = Convert.ToInt32(row.Cells["ID"].Value);
                cmbName.Text = row.Cells["patient_name"].Value.ToString();
                dateTimePicker1.Text = row.Cells["Appointment_Date"].Value.ToString();
                dateTimePicker2.Text = row.Cells["Appointment_Time"].Value.ToString();
                cmbStatus.SelectedItem = row.Cells["Appointment_State"].Value.ToString();
            }
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
            else
            {
                timer1.Stop();
            }
        }

        private void lblClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Appointments_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
            mouseX = e.X;
            mouseY = e.Y;
        }

        private void Appointments_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                int newX = Cursor.Position.X;
                int newY = Cursor.Position.Y;
                this.SetDesktopLocation(newX - mouseX, newY - mouseY);
            }
        }
        private void Appointments_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }

    }
}
