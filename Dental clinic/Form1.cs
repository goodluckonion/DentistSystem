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
    public partial class Form1 : Form
    {
        SqlConnection con;
        SqlDataAdapter da;
        DataTable dt;
        SqlCommand cmd;
        int n;
        int xx;
        int xy;
        bool mouseDown;
        public Form1()
        {
            this.Opacity = 0;
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            style();
            timer1.Interval = 50;
            timer1.Start();
            con = new SqlConnection("server=.;database=clinic;integrated security=true;");
            con.Open();
            lblHide.Visible = false;
        }

        private void style()
        {
            txtPassword.PasswordChar = '*';
            btnLogIn.FlatStyle = FlatStyle.Flat;
            lblTitle.ForeColor = Color.White;
            lblName.ForeColor = Color.White;
            lblPassword.ForeColor = Color.White;
        }

        private void btnLogIn_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtName.Text.Trim() == "" || txtPassword.Text.Trim() == "")
                {
                    MessageBox.Show("Fill All Data!");
                }
                else
                {
                    String q = "SELECT COUNT(*) from admin where admin_name = @name AND password = @password";
                    cmd = new SqlCommand(q, con);
                    cmd.Parameters.AddWithValue("@name", txtName.Text);
                    cmd.Parameters.AddWithValue("password", txtPassword.Text);
                    int count = (int)cmd.ExecuteScalar();
                    if(count > 0)
                    {
                        MainForm mainForm = new MainForm();
                        mainForm.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("اسم المستخدم او كلمة المرور غير صحيحة","خطأ" ,MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if(this.Opacity < 1)
            {
                this.Opacity += 0.09;
            }
            else { timer1.Stop(); }
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                btnLogIn.PerformClick();
            }
        }

        private void lblHide_Click(object sender, EventArgs e)
        {
            txtPassword.PasswordChar = '*';
            //txtPassword.UseSystemPasswordChar = true;
            lblHide.Visible = false;
            lblVisible.Visible = true;
        }

        private void lblVisible_Click(object sender, EventArgs e)
        {
            txtPassword.PasswordChar = '\0';
            //txtPassword.UseSystemPasswordChar = false;
            lblVisible.Visible = false;
            lblHide.Visible = true;
        }

        private void label3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
            xx = e.X;
            xy = e.Y;
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown) { 
                int x = Cursor.Position.X;
                int y = Cursor.Position.Y;
                this.SetDesktopLocation(x-xx, y-xy);
            }
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
