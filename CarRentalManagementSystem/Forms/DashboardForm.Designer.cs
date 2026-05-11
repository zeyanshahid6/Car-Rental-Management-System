namespace CarRentalManagementSystem.Forms
{
    partial class DashboardForm
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
            this.panelSidebar = new System.Windows.Forms.Panel();
            this.btnLogout = new System.Windows.Forms.Button();
            this.btnPayments = new System.Windows.Forms.Button();
            this.btnBookings = new System.Windows.Forms.Button();
            this.btnCars = new System.Windows.Forms.Button();
            this.btnCustomers = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblWelcome = new System.Windows.Forms.Label();
            this.panelCustomers = new System.Windows.Forms.Panel();
            this.lblTotalCustomers = new System.Windows.Forms.Label();
            this.lblCustomerTitle = new System.Windows.Forms.Label();
            this.panelCars = new System.Windows.Forms.Panel();
            this.lblTotalCars = new System.Windows.Forms.Label();
            this.lblCarTitle = new System.Windows.Forms.Label();
            this.panelBookings = new System.Windows.Forms.Panel();
            this.lblTotalBookings = new System.Windows.Forms.Label();
            this.lblBookingTitle = new System.Windows.Forms.Label();
            this.panelSidebar.SuspendLayout();
            this.panelCustomers.SuspendLayout();
            this.panelCars.SuspendLayout();
            this.panelBookings.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelSidebar
            // 
            this.panelSidebar.BackColor = System.Drawing.Color.MidnightBlue;
            this.panelSidebar.Controls.Add(this.btnLogout);
            this.panelSidebar.Controls.Add(this.btnPayments);
            this.panelSidebar.Controls.Add(this.btnBookings);
            this.panelSidebar.Controls.Add(this.btnCars);
            this.panelSidebar.Controls.Add(this.btnCustomers);
            this.panelSidebar.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelSidebar.Location = new System.Drawing.Point(0, 0);
            this.panelSidebar.Name = "panelSidebar";
            this.panelSidebar.Size = new System.Drawing.Size(220, 497);
            this.panelSidebar.TabIndex = 0;
            // 
            // btnLogout
            // 
            this.btnLogout.BackColor = System.Drawing.Color.LawnGreen;
            this.btnLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogout.Location = new System.Drawing.Point(21, 352);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(180, 45);
            this.btnLogout.TabIndex = 4;
            this.btnLogout.Text = "Logout";
            this.btnLogout.UseVisualStyleBackColor = false;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // btnPayments
            // 
            this.btnPayments.BackColor = System.Drawing.Color.LawnGreen;
            this.btnPayments.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPayments.Location = new System.Drawing.Point(21, 291);
            this.btnPayments.Name = "btnPayments";
            this.btnPayments.Size = new System.Drawing.Size(180, 45);
            this.btnPayments.TabIndex = 3;
            this.btnPayments.Text = "Payments";
            this.btnPayments.UseVisualStyleBackColor = false;
            this.btnPayments.Click += new System.EventHandler(this.btnPayments_Click);
            // 
            // btnBookings
            // 
            this.btnBookings.BackColor = System.Drawing.Color.LawnGreen;
            this.btnBookings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBookings.Location = new System.Drawing.Point(21, 230);
            this.btnBookings.Name = "btnBookings";
            this.btnBookings.Size = new System.Drawing.Size(180, 45);
            this.btnBookings.TabIndex = 2;
            this.btnBookings.Text = "Bookings";
            this.btnBookings.UseVisualStyleBackColor = false;
            this.btnBookings.Click += new System.EventHandler(this.btnBookings_Click);
            // 
            // btnCars
            // 
            this.btnCars.BackColor = System.Drawing.Color.LawnGreen;
            this.btnCars.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCars.Location = new System.Drawing.Point(21, 165);
            this.btnCars.Name = "btnCars";
            this.btnCars.Size = new System.Drawing.Size(180, 45);
            this.btnCars.TabIndex = 1;
            this.btnCars.Text = "Cars";
            this.btnCars.UseVisualStyleBackColor = false;
            this.btnCars.Click += new System.EventHandler(this.btnCars_Click);
            // 
            // btnCustomers
            // 
            this.btnCustomers.BackColor = System.Drawing.Color.LawnGreen;
            this.btnCustomers.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCustomers.Location = new System.Drawing.Point(21, 98);
            this.btnCustomers.Name = "btnCustomers";
            this.btnCustomers.Size = new System.Drawing.Size(180, 45);
            this.btnCustomers.TabIndex = 0;
            this.btnCustomers.Text = "Customer";
            this.btnCustomers.UseVisualStyleBackColor = false;
            this.btnCustomers.Click += new System.EventHandler(this.btnCustomers_Click);
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.RoyalBlue;
            this.lblTitle.Location = new System.Drawing.Point(120, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(626, 65);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "CAR RENTAL DASHBOARD";
            this.lblTitle.Click += new System.EventHandler(this.lblTitle_Click);
            // 
            // lblWelcome
            // 
            this.lblWelcome.AutoSize = true;
            this.lblWelcome.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWelcome.ForeColor = System.Drawing.Color.Black;
            this.lblWelcome.Location = new System.Drawing.Point(339, 89);
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Size = new System.Drawing.Size(333, 54);
            this.lblWelcome.TabIndex = 1;
            this.lblWelcome.Text = "Welcome Admin";
            // 
            // panelCustomers
            // 
            this.panelCustomers.BackColor = System.Drawing.Color.White;
            this.panelCustomers.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelCustomers.Controls.Add(this.lblTotalCustomers);
            this.panelCustomers.Controls.Add(this.lblCustomerTitle);
            this.panelCustomers.Location = new System.Drawing.Point(239, 165);
            this.panelCustomers.Name = "panelCustomers";
            this.panelCustomers.Size = new System.Drawing.Size(220, 120);
            this.panelCustomers.TabIndex = 2;
            // 
            // lblTotalCustomers
            // 
            this.lblTotalCustomers.AutoSize = true;
            this.lblTotalCustomers.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalCustomers.Location = new System.Drawing.Point(72, 44);
            this.lblTotalCustomers.Name = "lblTotalCustomers";
            this.lblTotalCustomers.Size = new System.Drawing.Size(56, 65);
            this.lblTotalCustomers.TabIndex = 1;
            this.lblTotalCustomers.Text = "0";
            // 
            // lblCustomerTitle
            // 
            this.lblCustomerTitle.AutoSize = true;
            this.lblCustomerTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCustomerTitle.ForeColor = System.Drawing.Color.RoyalBlue;
            this.lblCustomerTitle.Location = new System.Drawing.Point(3, 12);
            this.lblCustomerTitle.Name = "lblCustomerTitle";
            this.lblCustomerTitle.Size = new System.Drawing.Size(198, 32);
            this.lblCustomerTitle.TabIndex = 0;
            this.lblCustomerTitle.Text = "Total Customers";
            // 
            // panelCars
            // 
            this.panelCars.BackColor = System.Drawing.Color.White;
            this.panelCars.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelCars.Controls.Add(this.lblTotalCars);
            this.panelCars.Controls.Add(this.lblCarTitle);
            this.panelCars.Location = new System.Drawing.Point(493, 165);
            this.panelCars.Name = "panelCars";
            this.panelCars.Size = new System.Drawing.Size(220, 120);
            this.panelCars.TabIndex = 3;
            // 
            // lblTotalCars
            // 
            this.lblTotalCars.AutoSize = true;
            this.lblTotalCars.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalCars.Location = new System.Drawing.Point(73, 44);
            this.lblTotalCars.Name = "lblTotalCars";
            this.lblTotalCars.Size = new System.Drawing.Size(56, 65);
            this.lblTotalCars.TabIndex = 1;
            this.lblTotalCars.Text = "0";
            // 
            // lblCarTitle
            // 
            this.lblCarTitle.AutoSize = true;
            this.lblCarTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCarTitle.ForeColor = System.Drawing.Color.RoyalBlue;
            this.lblCarTitle.Location = new System.Drawing.Point(3, 12);
            this.lblCarTitle.Name = "lblCarTitle";
            this.lblCarTitle.Size = new System.Drawing.Size(126, 32);
            this.lblCarTitle.TabIndex = 0;
            this.lblCarTitle.Text = "Total Cars";
            // 
            // panelBookings
            // 
            this.panelBookings.BackColor = System.Drawing.Color.White;
            this.panelBookings.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelBookings.Controls.Add(this.lblTotalBookings);
            this.panelBookings.Controls.Add(this.lblBookingTitle);
            this.panelBookings.Location = new System.Drawing.Point(375, 297);
            this.panelBookings.Name = "panelBookings";
            this.panelBookings.Size = new System.Drawing.Size(220, 120);
            this.panelBookings.TabIndex = 4;
            // 
            // lblTotalBookings
            // 
            this.lblTotalBookings.AutoSize = true;
            this.lblTotalBookings.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalBookings.Location = new System.Drawing.Point(79, 38);
            this.lblTotalBookings.Name = "lblTotalBookings";
            this.lblTotalBookings.Size = new System.Drawing.Size(56, 65);
            this.lblTotalBookings.TabIndex = 1;
            this.lblTotalBookings.Text = "0";
            // 
            // lblBookingTitle
            // 
            this.lblBookingTitle.AutoSize = true;
            this.lblBookingTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBookingTitle.ForeColor = System.Drawing.Color.RoyalBlue;
            this.lblBookingTitle.Location = new System.Drawing.Point(3, 6);
            this.lblBookingTitle.Name = "lblBookingTitle";
            this.lblBookingTitle.Size = new System.Drawing.Size(183, 32);
            this.lblBookingTitle.TabIndex = 0;
            this.lblBookingTitle.Text = "Total Bookings";
            // 
            // DashboardForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.BackgroundImage = global::CarRentalManagementSystem.Properties.Resources.download__3_;
            this.ClientSize = new System.Drawing.Size(827, 497);
            this.Controls.Add(this.panelBookings);
            this.Controls.Add(this.panelCars);
            this.Controls.Add(this.panelCustomers);
            this.Controls.Add(this.lblWelcome);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.panelSidebar);
            this.Name = "DashboardForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Dashboard";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.DashboardForm_Load);
            this.panelSidebar.ResumeLayout(false);
            this.panelCustomers.ResumeLayout(false);
            this.panelCustomers.PerformLayout();
            this.panelCars.ResumeLayout(false);
            this.panelCars.PerformLayout();
            this.panelBookings.ResumeLayout(false);
            this.panelBookings.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panelSidebar;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Button btnPayments;
        private System.Windows.Forms.Button btnBookings;
        private System.Windows.Forms.Button btnCars;
        private System.Windows.Forms.Button btnCustomers;
        private System.Windows.Forms.Label lblWelcome;
        private System.Windows.Forms.Panel panelCustomers;
        private System.Windows.Forms.Label lblCustomerTitle;
        private System.Windows.Forms.Label lblTotalCustomers;
        private System.Windows.Forms.Panel panelCars;
        private System.Windows.Forms.Label lblTotalCars;
        private System.Windows.Forms.Label lblCarTitle;
        private System.Windows.Forms.Panel panelBookings;
        private System.Windows.Forms.Label lblTotalBookings;
        private System.Windows.Forms.Label lblBookingTitle;
    }
}