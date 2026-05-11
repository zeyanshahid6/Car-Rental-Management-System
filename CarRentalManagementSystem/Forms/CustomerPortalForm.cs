using System;
using System.Collections.Generic;
using System.ComponentModel;
using MySql.Data.MySqlClient;
using CarRentalManagementSystem.Classes;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarRentalManagementSystem.Forms
{
    public partial class CustomerPortalForm : Form
    {
        int loggedInCustomerID = 0;
        int selectedCarID = 0;
        int selectedBookingID = 0;
        decimal selectedCarPrice = 0;
        public CustomerPortalForm()
        {
            InitializeComponent();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            panelMain.Controls.Clear();

            Label lbl = new Label();
            lbl.Text = "Register Customer";
            lbl.Font = new Font("Segoe UI", 20, FontStyle.Bold);
            lbl.ForeColor = Color.RoyalBlue;
            lbl.Location = new Point(30, 20);
            lbl.AutoSize = true;
            panelMain.Controls.Add(lbl);

            // NAME LABEL
            Label lblName = new Label();
            lblName.Text = "Full Name";
            lblName.Location = new Point(30, 60);
            lblName.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            panelMain.Controls.Add(lblName);

            TextBox txtName = new TextBox();
            txtName.Name = "txtName";
            txtName.Location = new Point(30, 85);
            txtName.Size = new Size(300, 30);
            panelMain.Controls.Add(txtName);

            // EMAIL LABEL
            Label lblEmail = new Label();
            lblEmail.Text = "Email Address";
            lblEmail.Location = new Point(30, 120);
            lblEmail.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            panelMain.Controls.Add(lblEmail);

            TextBox txtEmail = new TextBox();
            txtEmail.Name = "txtEmail";
            txtEmail.Location = new Point(30, 145);
            txtEmail.Size = new Size(300, 30);
            panelMain.Controls.Add(txtEmail);

            // PHONE LABEL
            Label lblPhone = new Label();
            lblPhone.Text = "Phone Number";
            lblPhone.Location = new Point(30, 180);
            lblPhone.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            panelMain.Controls.Add(lblPhone);

            TextBox txtPhone = new TextBox();
            txtPhone.Name = "txtPhone";
            txtPhone.Location = new Point(30, 205);
            txtPhone.Size = new Size(300, 30);
            panelMain.Controls.Add(txtPhone);

            // LICENSE LABEL
            Label lblLicense = new Label();
            lblLicense.Text = "Driving License Number";
            lblLicense.Location = new Point(30, 240);
            lblLicense.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            panelMain.Controls.Add(lblLicense);

            TextBox txtLicense = new TextBox();
            txtLicense.Name = "txtLicense";
            txtLicense.Location = new Point(30, 265);
            txtLicense.Size = new Size(300, 30);
            panelMain.Controls.Add(txtLicense);

            // PASSWORD LABEL
            Label lblPassword = new Label();
            lblPassword.Text = "Password";
            lblPassword.Location = new Point(30, 300);
            lblPassword.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            panelMain.Controls.Add(lblPassword);

            TextBox txtPassword = new TextBox();
            txtPassword.Name = "txtPassword";
            txtPassword.UseSystemPasswordChar = true;
            txtPassword.Location = new Point(30, 325);
            txtPassword.Size = new Size(300, 30);
            panelMain.Controls.Add(txtPassword);

            // CREATE BUTTON
            Button btnCreate = new Button();
            btnCreate.Text = "CREATE ACCOUNT";
            btnCreate.Location = new Point(30, 380);
            btnCreate.Size = new Size(300, 45);
            btnCreate.BackColor = Color.RoyalBlue;
            btnCreate.ForeColor = Color.White;
            btnCreate.FlatStyle = FlatStyle.Flat;
            btnCreate.Click += BtnCreate_Click;
            panelMain.Controls.Add(btnCreate);
        }

        private void BtnCreate_Click(object sender, EventArgs e)
        {
            TextBox txtName = panelMain.Controls["txtName"] as TextBox;
            TextBox txtEmail = panelMain.Controls["txtEmail"] as TextBox;
            TextBox txtPhone = panelMain.Controls["txtPhone"] as TextBox;
            TextBox txtLicense = panelMain.Controls["txtLicense"] as TextBox;
            TextBox txtPassword = panelMain.Controls["txtPassword"] as TextBox;

            if (txtName.Text == "" || txtEmail.Text == "" || txtPhone.Text == "" || txtLicense.Text == "" || txtPassword.Text == "")
            {
                MessageBox.Show("Please fill all fields");
                return;
            }

            MySqlConnection conn = DatabaseConnection.GetConnection();
            conn.Open();

            string query = "INSERT INTO Customer(Name, Email, PhoneNumber, DrivingLicenseNumber, Password) VALUES(@name, @email, @phone, @license, @password)";

            MySqlCommand cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@name", txtName.Text);
            cmd.Parameters.AddWithValue("@email", txtEmail.Text);
            cmd.Parameters.AddWithValue("@phone", txtPhone.Text);
            cmd.Parameters.AddWithValue("@license", txtLicense.Text);
            cmd.Parameters.AddWithValue("@password", txtPassword.Text);

            cmd.ExecuteNonQuery();
            conn.Close();

            MessageBox.Show("Account Created Successfully. Please login now.");
        }
        private void btnLogin_Click(object sender, EventArgs e)
        {
            panelMain.Controls.Clear();

            // TITLE
            Label lbl = new Label();
            lbl.Text = "Customer Login";
            lbl.Font = new Font("Segoe UI", 20, FontStyle.Bold);
            lbl.ForeColor = Color.RoyalBlue;
            lbl.Location = new Point(30, 20);
            lbl.AutoSize = true;
            panelMain.Controls.Add(lbl);

            // EMAIL LABEL
            Label lblEmail = new Label();
            lblEmail.Text = "Email Address";
            lblEmail.Location = new Point(30, 90);
            lblEmail.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            panelMain.Controls.Add(lblEmail);

            // EMAIL TEXTBOX
            TextBox txtEmail = new TextBox();
            txtEmail.Name = "txtLoginEmail";
            txtEmail.Location = new Point(30, 115);
            txtEmail.Size = new Size(300, 30);
            panelMain.Controls.Add(txtEmail);

            // PASSWORD LABEL
            Label lblPassword = new Label();
            lblPassword.Text = "Password";
            lblPassword.Location = new Point(30, 160);
            lblPassword.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            panelMain.Controls.Add(lblPassword);

            // PASSWORD TEXTBOX
            TextBox txtPassword = new TextBox();
            txtPassword.Name = "txtLoginPassword";
            txtPassword.UseSystemPasswordChar = true;
            txtPassword.Location = new Point(30, 185);
            txtPassword.Size = new Size(300, 30);
            panelMain.Controls.Add(txtPassword);

            // LOGIN BUTTON
            Button btnCustomerLogin = new Button();
            btnCustomerLogin.Text = "LOGIN";
            btnCustomerLogin.Location = new Point(30, 250);
            btnCustomerLogin.Size = new Size(300, 45);
            btnCustomerLogin.BackColor = Color.RoyalBlue;
            btnCustomerLogin.ForeColor = Color.White;
            btnCustomerLogin.FlatStyle = FlatStyle.Flat;
            btnCustomerLogin.Click += BtnCustomerLogin_Click;
            panelMain.Controls.Add(btnCustomerLogin);
        }
        private void BtnCustomerLogin_Click(object sender, EventArgs e)
        {
            TextBox txtEmail = panelMain.Controls["txtLoginEmail"] as TextBox;
            TextBox txtPassword = panelMain.Controls["txtLoginPassword"] as TextBox;

            MySqlConnection conn = DatabaseConnection.GetConnection();
            conn.Open();

            string query = "SELECT CustomerID FROM Customer WHERE Email=@email AND Password=@password";

            MySqlCommand cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@email", txtEmail.Text);
            cmd.Parameters.AddWithValue("@password", txtPassword.Text);

            object result = cmd.ExecuteScalar();

            conn.Close();

            if (result != null)
            {
                loggedInCustomerID = Convert.ToInt32(result);
                MessageBox.Show("Customer Login Successful");
            }
            else
            {
                MessageBox.Show("Invalid Email or Password");
            }
        }

        private void btnViewCars_Click(object sender, EventArgs e)
        {
            if (loggedInCustomerID == 0)
            {
                MessageBox.Show("Please login first");
                return;
            }

            panelMain.Controls.Clear();

            Label lbl = new Label();
            lbl.Text = "Available Cars";
            lbl.Font = new Font("Segoe UI", 20, FontStyle.Bold);
            lbl.ForeColor = Color.RoyalBlue;
            lbl.Location = new Point(30, 20);
            lbl.AutoSize = true;
            panelMain.Controls.Add(lbl);

            DataGridView dgvCars = new DataGridView();
            dgvCars.Name = "dgvCars";
            dgvCars.Location = new Point(30, 70);
            dgvCars.Size = new Size(900, 180);
            dgvCars.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvCars.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCars.ReadOnly = true;
            dgvCars.CellClick += DgvCars_CellClick;
            panelMain.Controls.Add(dgvCars);

            Label lblStart = new Label();
            lblStart.Text = "Start Date";
            lblStart.Location = new Point(30, 280);
            lblStart.AutoSize = true;
            panelMain.Controls.Add(lblStart);

            DateTimePicker dtStart = new DateTimePicker();
            dtStart.Name = "dtStart";
            dtStart.Location = new Point(120, 275);
            panelMain.Controls.Add(dtStart);

            Label lblEnd = new Label();
            lblEnd.Text = "End Date";
            lblEnd.Location = new Point(30, 330);
            lblEnd.AutoSize = true;
            panelMain.Controls.Add(lblEnd);

            DateTimePicker dtEnd = new DateTimePicker();
            dtEnd.Name = "dtEnd";
            dtEnd.Location = new Point(120, 325);
            panelMain.Controls.Add(dtEnd);

            TextBox txtTotal = new TextBox();
            txtTotal.Name = "txtTotal";
            txtTotal.Location = new Point(120, 375);
            txtTotal.Size = new Size(200, 30);
            txtTotal.ReadOnly = true;
            panelMain.Controls.Add(txtTotal);

            Button btnCalculate = new Button();
            btnCalculate.Text = "CALCULATE";
            btnCalculate.Location = new Point(360, 325);
            btnCalculate.Size = new Size(150, 40);
            btnCalculate.BackColor = Color.DarkOrange;
            btnCalculate.ForeColor = Color.White;
            btnCalculate.FlatStyle = FlatStyle.Flat;
            btnCalculate.Click += BtnCalculate_Click;
            panelMain.Controls.Add(btnCalculate);

            Button btnBook = new Button();
            btnBook.Text = "BOOK NOW";
            btnBook.Location = new Point(360, 375);
            btnBook.Size = new Size(150, 40);
            btnBook.BackColor = Color.RoyalBlue;
            btnBook.ForeColor = Color.White;
            btnBook.FlatStyle = FlatStyle.Flat;
            btnBook.Click += BtnBook_Click;
            panelMain.Controls.Add(btnBook);

            LoadAvailableCars();
        }
        private void LoadAvailableCars()
        {
            DataGridView dgvCars = panelMain.Controls["dgvCars"] as DataGridView;

            MySqlConnection conn = DatabaseConnection.GetConnection();
            conn.Open();

            string query = "SELECT CarID, Brand, Model, Type, PricePerDay, AvailabilityStatus FROM Car WHERE AvailabilityStatus='Available'";

            MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
            DataTable table = new DataTable();
            adapter.Fill(table);

            dgvCars.DataSource = table;

            conn.Close();
        }
        private void DgvCars_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridView dgvCars = panelMain.Controls["dgvCars"] as DataGridView;
                DataGridViewRow row = dgvCars.Rows[e.RowIndex];

                selectedCarID = Convert.ToInt32(row.Cells["CarID"].Value);
                selectedCarPrice = Convert.ToDecimal(row.Cells["PricePerDay"].Value);

                MessageBox.Show("Car Selected");
            }
        }
        private void BtnCalculate_Click(object sender, EventArgs e)
        {
            if (selectedCarID == 0)
            {
                MessageBox.Show("Please select a car first");
                return;
            }

            DateTimePicker dtStart = panelMain.Controls["dtStart"] as DateTimePicker;
            DateTimePicker dtEnd = panelMain.Controls["dtEnd"] as DateTimePicker;
            TextBox txtTotal = panelMain.Controls["txtTotal"] as TextBox;

            if (dtEnd.Value.Date <= dtStart.Value.Date)
            {
                MessageBox.Show("End date must be after start date");
                return;
            }

            int days = (dtEnd.Value.Date - dtStart.Value.Date).Days;
            decimal total = days * selectedCarPrice;

            txtTotal.Text = total.ToString();
        }
        private void BtnBook_Click(object sender, EventArgs e)
        {
            if (selectedCarID == 0 || loggedInCustomerID == 0)
            {
                MessageBox.Show("Please login and select a car first");
                return;
            }

            DateTimePicker dtStart = panelMain.Controls["dtStart"] as DateTimePicker;
            DateTimePicker dtEnd = panelMain.Controls["dtEnd"] as DateTimePicker;
            TextBox txtTotal = panelMain.Controls["txtTotal"] as TextBox;

            if (txtTotal.Text == "")
            {
                MessageBox.Show("Please calculate total first");
                return;
            }

            MySqlConnection conn = DatabaseConnection.GetConnection();
            conn.Open();

            string query = @"INSERT INTO Booking
                    (BookingDate, StartDate, EndDate, TotalAmount, BookingStatus, CustomerID, CarID)
                    VALUES
                    (@bookingDate, @startDate, @endDate, @total, 'Confirmed', @customerID, @carID)";

            MySqlCommand cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@bookingDate", DateTime.Now.Date);
            cmd.Parameters.AddWithValue("@startDate", dtStart.Value.Date);
            cmd.Parameters.AddWithValue("@endDate", dtEnd.Value.Date);
            cmd.Parameters.AddWithValue("@total", txtTotal.Text);
            cmd.Parameters.AddWithValue("@customerID", loggedInCustomerID);
            cmd.Parameters.AddWithValue("@carID", selectedCarID);

            cmd.ExecuteNonQuery();

            string updateCar = "UPDATE Car SET AvailabilityStatus='Booked' WHERE CarID=@carID";
            MySqlCommand cmdCar = new MySqlCommand(updateCar, conn);
            cmdCar.Parameters.AddWithValue("@carID", selectedCarID);
            cmdCar.ExecuteNonQuery();

            conn.Close();

            MessageBox.Show("Booking Confirmed Successfully");

            selectedCarID = 0;
            selectedCarPrice = 0;

            LoadAvailableCars();
        }

        private void btnMyBookings_Click(object sender, EventArgs e)
        {
            if (loggedInCustomerID == 0)
            {
                MessageBox.Show("Please login first");
                return;
            }

            panelMain.Controls.Clear();

            Label lbl = new Label();
            lbl.Text = "My Bookings";
            lbl.Font = new Font("Segoe UI", 20, FontStyle.Bold);
            lbl.ForeColor = Color.RoyalBlue;
            lbl.Location = new Point(30, 20);
            lbl.AutoSize = true;
            panelMain.Controls.Add(lbl);

            DataGridView dgvMyBookings = new DataGridView();
            dgvMyBookings.Name = "dgvMyBookings";
            dgvMyBookings.Location = new Point(30, 80);
            dgvMyBookings.Size = new Size(900, 250);
            dgvMyBookings.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvMyBookings.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvMyBookings.ReadOnly = true;
            dgvMyBookings.CellClick += DgvMyBookings_CellClick;
            panelMain.Controls.Add(dgvMyBookings);

            Button btnCancel = new Button();
            btnCancel.Text = "CANCEL BOOKING";
            btnCancel.Location = new Point(30, 360);
            btnCancel.Size = new Size(200, 45);
            btnCancel.BackColor = Color.Crimson;
            btnCancel.ForeColor = Color.White;
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.Click += BtnCancelBooking_Click;
            panelMain.Controls.Add(btnCancel);

            LoadMyBookings();
        }
        private void LoadMyBookings()
        {
            DataGridView dgvMyBookings = panelMain.Controls["dgvMyBookings"] as DataGridView;

            MySqlConnection conn = DatabaseConnection.GetConnection();
            conn.Open();

            string query = @"SELECT 
                    Booking.BookingID,
                    Booking.CarID,
                    CONCAT(Car.Brand, ' ', Car.Model) AS CarName,
                    Booking.BookingDate,
                    Booking.StartDate,
                    Booking.EndDate,
                    Booking.TotalAmount,
                    Booking.BookingStatus
                    FROM Booking
                    INNER JOIN Car ON Booking.CarID = Car.CarID
                    WHERE Booking.CustomerID=@customerID";

            MySqlCommand cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@customerID", loggedInCustomerID);

            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
            DataTable table = new DataTable();
            adapter.Fill(table);

            dgvMyBookings.DataSource = table;

            conn.Close();
        }
        private void DgvMyBookings_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridView dgvMyBookings = panelMain.Controls["dgvMyBookings"] as DataGridView;
                DataGridViewRow row = dgvMyBookings.Rows[e.RowIndex];

                selectedBookingID = Convert.ToInt32(row.Cells["BookingID"].Value);
                selectedCarID = Convert.ToInt32(row.Cells["CarID"].Value);

                MessageBox.Show("Booking Selected");
            }
        }
        private void BtnCancelBooking_Click(object sender, EventArgs e)
        {
            if (selectedBookingID == 0)
            {
                MessageBox.Show("Please select a booking first");
                return;
            }

            DialogResult result = MessageBox.Show(
                "Are you sure you want to cancel this booking?",
                "Cancel Booking",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                MySqlConnection conn = DatabaseConnection.GetConnection();
                conn.Open();

                string query = "UPDATE Booking SET BookingStatus='Cancelled' WHERE BookingID=@bookingID";

                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@bookingID", selectedBookingID);
                cmd.ExecuteNonQuery();

                string updateCar = "UPDATE Car SET AvailabilityStatus='Available' WHERE CarID=@carID";

                MySqlCommand cmdCar = new MySqlCommand(updateCar, conn);
                cmdCar.Parameters.AddWithValue("@carID", selectedCarID);
                cmdCar.ExecuteNonQuery();

                conn.Close();

                MessageBox.Show("Booking Cancelled Successfully");

                selectedBookingID = 0;
                selectedCarID = 0;

                LoadMyBookings();
            }
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            loggedInCustomerID = 0;
            selectedCarID = 0;
            selectedBookingID = 0;
            selectedCarPrice = 0;

            panelMain.Controls.Clear();

            MessageBox.Show("Logged out successfully");
        }

    }
}
