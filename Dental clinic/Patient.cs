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
    public partial class Patient : Form
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataAdapter da;
        DataTable dt;
        int selectedPatientID;
        int xx, xy;
        bool mouseDown;
        public Patient()
        {
            this.Opacity = 0;
            InitializeComponent();
        }

        private void Patient_Load(object sender, EventArgs e)
        {
            con = new SqlConnection("server=.;database=clinic;integrated security=true;");
            con.Open();
            loadPatientTableToDataGridView();
            timer1.Interval = 50;
            timer1.Start();
            dataGridView1.ForeColor = Color.Black;
        }

        private void loadPatientTableToDataGridView()
        {
            String qq = "select * from patients";
            da = new SqlDataAdapter(qq, con);
            dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if(txtName.Text.Trim() == "" || txtPhone.Text.Trim() == ""
                  || cmbAge.Text.Trim() == "" || cmbGender.Text.Trim() == "")
                { MessageBox.Show("Enter All Data"); }
                else
                {
                    String q = "insert into patients values(@name , @phone, @Age, @Gender)";
                    cmd = new SqlCommand(q, con);
                    cmd.Parameters.AddWithValue("@name", txtName.Text);
                    cmd.Parameters.AddWithValue("@phone", txtPhone.Text);
                    cmd.Parameters.AddWithValue("@Age", Convert.ToInt32(cmbAge.SelectedItem.ToString()));
                    cmd.Parameters.AddWithValue("@Gender", cmbGender.SelectedItem.ToString());
                    cmd.ExecuteNonQuery();
                    loadPatientTableToDataGridView();
                    MessageBox.Show("successful");
                }
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnMod_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtName.Text.Trim() == "" || txtPhone.Text.Trim() == ""
                  || cmbAge.Text.Trim() == "" || cmbGender.Text.Trim() == "")
                { MessageBox.Show("Enter All Data"); }
                else
                {
                    String q = "update patients SET patient_name=@name,Phone_No=@phone, Age=@age, Gender=@gender WHERE ID = @id";
                    cmd = new SqlCommand(q,con);
                    cmd.Parameters.AddWithValue("@name", txtName.Text);
                    cmd.Parameters.AddWithValue("@phone", txtPhone.Text);
                    cmd.Parameters.AddWithValue("@age", Convert.ToInt32(cmbAge.SelectedItem.ToString()));
                    cmd.Parameters.AddWithValue("@gender", cmbGender.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@id", selectedPatientID);
                    cmd.ExecuteNonQuery();
                    loadPatientTableToDataGridView();
                    MessageBox.Show("update");
                }
            }catch(Exception ex)
            { MessageBox.Show(ex.Message); }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                if(txtName.Text.Trim() == "")
                {
                    MessageBox.Show("Enter The Patient name!");
                }
                else
                {
                    String name = txtName.Text;
                    DataTable dt = (DataTable)dataGridView1.DataSource;
                    DataView dv = new DataView(dt);
                    dv.RowFilter = "patient_name LIKE '%"+name+"%'";
                    dataGridView1.DataSource = dv;
                }
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                selectedPatientID = Convert.ToInt32(row.Cells["ID"].Value);
                txtName.Text = row.Cells["patient_name"].Value.ToString();
                txtPhone.Text = row.Cells["Phone_No"].Value.ToString();
                cmbAge.SelectedItem = row.Cells["Age"].Value.ToString();
                cmbGender.SelectedItem = row.Cells["Gender"].Value.ToString();
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

        private void label1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void Patient_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
            xx = e.X;
            xy = e.Y;
        }

        private void Patient_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                int x = Cursor.Position.X;
                int y = Cursor.Position.Y;
                this.SetDesktopLocation(x-xx,y-xy);
            }
        }

        private void Patient_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }

    }
}
