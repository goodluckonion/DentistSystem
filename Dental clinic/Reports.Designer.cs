namespace Dental_clinic
{
    partial class Reports
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.lblTitle = new System.Windows.Forms.Label();
            this.btnTodayReport = new System.Windows.Forms.Button();
            this.btnMonthlyReport = new System.Windows.Forms.Button();
            this.lblNoOfPatients = new System.Windows.Forms.Label();
            this.lblRevenues = new System.Windows.Forms.Label();
            this.No_Of_PatientsT = new System.Windows.Forms.Label();
            this.RevenuesT = new System.Windows.Forms.Label();
            this.lblBack = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.lblClose = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(256, 25);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(114, 45);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "التقارير";
            // 
            // btnTodayReport
            // 
            this.btnTodayReport.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnTodayReport.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTodayReport.Location = new System.Drawing.Point(320, 119);
            this.btnTodayReport.Name = "btnTodayReport";
            this.btnTodayReport.Size = new System.Drawing.Size(129, 55);
            this.btnTodayReport.TabIndex = 1;
            this.btnTodayReport.Text = "تقرير اليوم";
            this.btnTodayReport.UseVisualStyleBackColor = false;
            this.btnTodayReport.Click += new System.EventHandler(this.btnTodayReport_Click);
            // 
            // btnMonthlyReport
            // 
            this.btnMonthlyReport.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnMonthlyReport.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMonthlyReport.Location = new System.Drawing.Point(159, 119);
            this.btnMonthlyReport.Name = "btnMonthlyReport";
            this.btnMonthlyReport.Size = new System.Drawing.Size(129, 55);
            this.btnMonthlyReport.TabIndex = 2;
            this.btnMonthlyReport.Text = "تقرير الشهر";
            this.btnMonthlyReport.UseVisualStyleBackColor = false;
            this.btnMonthlyReport.Click += new System.EventHandler(this.btnMonthlyReport_Click);
            // 
            // lblNoOfPatients
            // 
            this.lblNoOfPatients.AutoSize = true;
            this.lblNoOfPatients.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNoOfPatients.Location = new System.Drawing.Point(217, 234);
            this.lblNoOfPatients.Name = "lblNoOfPatients";
            this.lblNoOfPatients.Size = new System.Drawing.Size(22, 25);
            this.lblNoOfPatients.TabIndex = 3;
            this.lblNoOfPatients.Text = "0";
            // 
            // lblRevenues
            // 
            this.lblRevenues.AutoSize = true;
            this.lblRevenues.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRevenues.Location = new System.Drawing.Point(217, 298);
            this.lblRevenues.Name = "lblRevenues";
            this.lblRevenues.Size = new System.Drawing.Size(22, 25);
            this.lblRevenues.TabIndex = 4;
            this.lblRevenues.Text = "0";
            // 
            // No_Of_PatientsT
            // 
            this.No_Of_PatientsT.AutoSize = true;
            this.No_Of_PatientsT.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.No_Of_PatientsT.Location = new System.Drawing.Point(301, 234);
            this.No_Of_PatientsT.Name = "No_Of_PatientsT";
            this.No_Of_PatientsT.Size = new System.Drawing.Size(106, 25);
            this.No_Of_PatientsT.TabIndex = 5;
            this.No_Of_PatientsT.Text = "عدد المرضى";
            // 
            // RevenuesT
            // 
            this.RevenuesT.AutoSize = true;
            this.RevenuesT.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RevenuesT.Location = new System.Drawing.Point(315, 298);
            this.RevenuesT.Name = "RevenuesT";
            this.RevenuesT.Size = new System.Drawing.Size(77, 25);
            this.RevenuesT.TabIndex = 6;
            this.RevenuesT.Text = "الايرادات";
            // 
            // lblBack
            // 
            this.lblBack.AutoSize = true;
            this.lblBack.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBack.Location = new System.Drawing.Point(60, 31);
            this.lblBack.Name = "lblBack";
            this.lblBack.Size = new System.Drawing.Size(53, 25);
            this.lblBack.TabIndex = 7;
            this.lblBack.Text = "عودة";
            this.lblBack.Click += new System.EventHandler(this.lblBack_Click);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // lblClose
            // 
            this.lblClose.AutoSize = true;
            this.lblClose.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblClose.ForeColor = System.Drawing.Color.White;
            this.lblClose.Location = new System.Drawing.Point(547, 9);
            this.lblClose.Name = "lblClose";
            this.lblClose.Size = new System.Drawing.Size(30, 32);
            this.lblClose.TabIndex = 18;
            this.lblClose.Text = "X";
            this.lblClose.Click += new System.EventHandler(this.lblClose_Click);
            // 
            // Reports
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.ClientSize = new System.Drawing.Size(589, 408);
            this.ControlBox = false;
            this.Controls.Add(this.lblClose);
            this.Controls.Add(this.lblBack);
            this.Controls.Add(this.RevenuesT);
            this.Controls.Add(this.No_Of_PatientsT);
            this.Controls.Add(this.lblRevenues);
            this.Controls.Add(this.lblNoOfPatients);
            this.Controls.Add(this.btnMonthlyReport);
            this.Controls.Add(this.btnTodayReport);
            this.Controls.Add(this.lblTitle);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Reports";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.Reports_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Reports_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Reports_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Reports_MouseUp);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnTodayReport;
        private System.Windows.Forms.Button btnMonthlyReport;
        private System.Windows.Forms.Label lblNoOfPatients;
        private System.Windows.Forms.Label lblRevenues;
        private System.Windows.Forms.Label No_Of_PatientsT;
        private System.Windows.Forms.Label RevenuesT;
        private System.Windows.Forms.Label lblBack;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label lblClose;
    }
}