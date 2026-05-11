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
    public partial class BookingForm : Form
    {
        int selectedBookingID = 0;
        decimal selectedCarPrice = 0;
        public BookingForm()
        {
            InitializeComponent();
        }
        private void LoadCustomers()
        {
            MySqlConnection conn = DatabaseConnection.GetConnection();
            conn.Open();

            string query = "SELECT CustomerID, Name FROM Customer";

            MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
            DataTable table = new DataTable();
            adapter.Fill(table);

            cmbCustomer.DataSource = table;
            cmbCustomer.DisplayMember = "Name";
            cmbCustomer.ValueMember = "CustomerID";
            cmbCustomer.SelectedIndex = -1;

            conn.Close();
        }
        private void LoadCars()
        {
            MySqlConnection conn = DatabaseConnection.GetConnection();
            conn.Open();

            string query = "SELECT CarID, CONCAT(Brand, ' ', Model) AS CarName, PricePerDay FROM Car WHERE AvailabilityStatus='Available'";

            MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
            DataTable table = new DataTable();
            adapter.Fill(table);

            cmbCar.DataSource = table;
            cmbCar.DisplayMember = "CarName";
            cmbCar.ValueMember = "CarID";
            cmbCar.SelectedIndex = -1;

            conn.Close();
        }
        private void LoadBookings()
        {
            MySqlConnection conn = DatabaseConnection.GetConnection();
            conn.Open();

            string query = @"SELECT 
                    Booking.BookingID,
                    Customer.Name AS CustomerName,
                    CONCAT(Car.Brand, ' ', Car.Model) AS CarName,
                    Booking.BookingDate,
                    Booking.StartDate,
                    Booking.EndDate,
                    Booking.TotalAmount,
                    Booking.BookingStatus
                    FROM Booking
                    INNER JOIN Customer ON Booking.CustomerID = Customer.CustomerID
                    INNER JOIN Car ON Booking.CarID = Car.CarID";

            MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
            DataTable table = new DataTable();
            adapter.Fill(table);

            dgvBookings.DataSource = table;

            conn.Close();
        }
        private void ClearFields()
        {
            cmbCustomer.SelectedIndex = -1;
            cmbCar.SelectedIndex = -1;
            cmbStatus.SelectedIndex = -1;

            txtTotal.Clear();
            txtSearch.Clear();

            dtStart.Value = DateTime.Now;
            dtEnd.Value = DateTime.Now;

            selectedBookingID = 0;
            selectedCarPrice = 0;
        }

        private void BookingForm_Load(object sender, EventArgs e)
        {
            LoadCustomers();
            LoadCars();
            LoadBookings();
        }

        private void cmbCar_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbCar.SelectedIndex != -1)
            {
                DataRowView row = cmbCar.SelectedItem as DataRowView;

                if (row != null)
                {
                    selectedCarPrice = Convert.ToDecimal(row["PricePerDay"]);
                }
            }
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            if (cmbCar.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a car first");
                return;
            }

            if (dtEnd.Value.Date <= dtStart.Value.Date)
            {
                MessageBox.Show("End date must be after start date");
                return;
            }

            int days = (dtEnd.Value.Date - dtStart.Value.Date).Days;
            decimal total = days * selectedCarPrice;

            txtTotal.Text = total.ToString();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (cmbCustomer.SelectedIndex == -1 || cmbCar.SelectedIndex == -1 || txtTotal.Text == "" || cmbStatus.Text == "")
            {
                MessageBox.Show("Please fill all fields and calculate total");
                return;
            }

            MySqlConnection conn = DatabaseConnection.GetConnection();
            conn.Open();

            string query = @"INSERT INTO Booking
                (BookingDate, StartDate, EndDate, TotalAmount, BookingStatus, CustomerID, CarID)
                VALUES
                (@bookingDate, @startDate, @endDate, @total, @status, @customerID, @carID)";

            MySqlCommand cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@bookingDate", DateTime.Now.Date);
            cmd.Parameters.AddWithValue("@startDate", dtStart.Value.Date);
            cmd.Parameters.AddWithValue("@endDate", dtEnd.Value.Date);
            cmd.Parameters.AddWithValue("@total", txtTotal.Text);
            cmd.Parameters.AddWithValue("@status", cmbStatus.Text);
            cmd.Parameters.AddWithValue("@customerID", cmbCustomer.SelectedValue);
            cmd.Parameters.AddWithValue("@carID", cmbCar.SelectedValue);

            cmd.ExecuteNonQuery();

            string updateCar = "UPDATE Car SET AvailabilityStatus='Booked' WHERE CarID=@carID";
            MySqlCommand cmdCar = new MySqlCommand(updateCar, conn);
            cmdCar.Parameters.AddWithValue("@carID", cmbCar.SelectedValue);
            cmdCar.ExecuteNonQuery();

            conn.Close();

            MessageBox.Show("Booking Added Successfully");

            LoadCars();
            LoadBookings();
            ClearFields();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (selectedBookingID == 0)
            {
                MessageBox.Show("Please select a booking first");
                return;
            }

            MySqlConnection conn = DatabaseConnection.GetConnection();
            conn.Open();

            string query = @"UPDATE Booking SET 
                StartDate=@startDate,
                EndDate=@endDate,
                TotalAmount=@total,
                BookingStatus=@status
                WHERE BookingID=@id";

            MySqlCommand cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@id", selectedBookingID);
            cmd.Parameters.AddWithValue("@startDate", dtStart.Value.Date);
            cmd.Parameters.AddWithValue("@endDate", dtEnd.Value.Date);
            cmd.Parameters.AddWithValue("@total", txtTotal.Text);
            cmd.Parameters.AddWithValue("@status", cmbStatus.Text);

            cmd.ExecuteNonQuery();
            conn.Close();

            MessageBox.Show("Booking Updated Successfully");

            LoadBookings();
            ClearFields();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (selectedBookingID == 0)
            {
                MessageBox.Show("Please select a booking first");
                return;
            }

            MySqlConnection conn = DatabaseConnection.GetConnection();
            conn.Open();

            string query = "DELETE FROM Booking WHERE BookingID=@id";

            MySqlCommand cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@id", selectedBookingID);

            cmd.ExecuteNonQuery();
            conn.Close();

            MessageBox.Show("Booking Deleted Successfully");

            LoadBookings();
            ClearFields();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        private void dgvBookings_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvBookings.Rows[e.RowIndex];

                selectedBookingID = Convert.ToInt32(row.Cells["BookingID"].Value);
                dtStart.Value = Convert.ToDateTime(row.Cells["StartDate"].Value);
                dtEnd.Value = Convert.ToDateTime(row.Cells["EndDate"].Value);
                txtTotal.Text = row.Cells["TotalAmount"].Value.ToString();
                cmbStatus.Text = row.Cells["BookingStatus"].Value.ToString();
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            MySqlConnection conn = DatabaseConnection.GetConnection();
            conn.Open();

            string query = @"SELECT 
                Booking.BookingID,
                Customer.Name AS CustomerName,
                CONCAT(Car.Brand, ' ', Car.Model) AS CarName,
                Booking.BookingDate,
                Booking.StartDate,
                Booking.EndDate,
                Booking.TotalAmount,
                Booking.BookingStatus
                FROM Booking
                INNER JOIN Customer ON Booking.CustomerID = Customer.CustomerID
                INNER JOIN Car ON Booking.CarID = Car.CarID
                WHERE Customer.Name LIKE @search
                OR Car.Brand LIKE @search
                OR Car.Model LIKE @search
                OR Booking.BookingStatus LIKE @search";

            MySqlCommand cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@search", "%" + txtSearch.Text + "%");

            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
            DataTable table = new DataTable();
            adapter.Fill(table);

            dgvBookings.DataSource = table;

            conn.Close();
        }
    }
}
