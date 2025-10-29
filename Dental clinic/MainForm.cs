using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dental_clinic
{
    public partial class MainForm : Form
    {
        int mouseX, mouseY;
        bool mouseDown;
        public MainForm()
        {
            this.Opacity = 0;
            InitializeComponent();
        }

        private void btnAddPatient_Click(object sender, EventArgs e)
        {
            Patient patient = new Patient();
            patient.Show();
            this.Hide();
        }

        private void btnAppointments_Click(object sender, EventArgs e)
        {
            Appointments appointments = new Appointments();
            appointments.Show();
            this.Hide();
        }

        private void btnPayment_Click(object sender, EventArgs e)
        {
            Payment payment = new Payment();
            payment.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Reports reports = new Reports();
            reports.Show();
            this.Hide();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (this.Opacity < 1)
            {
                this.Opacity += 0.3;
            }
            else { timer1.Stop(); }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            timer1.Interval = 50;
            timer1.Start();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }


        private void MainForm_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
            mouseX = e.X;
            mouseY = e.Y;
        }

        private void MainForm_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                int newX = Cursor.Position.X;
                int newY = Cursor.Position.Y;
                this.SetDesktopLocation(newX - mouseX, newY - mouseY);
            }
        }

        private void MainForm_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }
    }
}
