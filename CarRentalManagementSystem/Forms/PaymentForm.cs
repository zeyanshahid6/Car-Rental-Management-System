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
    public partial class PaymentForm : Form
    {
        int selectedPaymentID = 0;
        public PaymentForm()
        {
            InitializeComponent();
        }
        private void LoadBookings()
        {
            MySqlConnection conn = DatabaseConnection.GetConnection();
            conn.Open();

            string query = @"SELECT 
                    Booking.BookingID,
                    CONCAT('Booking #', Booking.BookingID, ' - ', Customer.Name, ' - ', Car.Brand, ' ', Car.Model) AS BookingInfo,
                    Booking.TotalAmount
                    FROM Booking
                    INNER JOIN Customer ON Booking.CustomerID = Customer.CustomerID
                    INNER JOIN Car ON Booking.CarID = Car.CarID";

            MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
            DataTable table = new DataTable();
            adapter.Fill(table);

            cmbBooking.DataSource = table;
            cmbBooking.DisplayMember = "BookingInfo";
            cmbBooking.ValueMember = "BookingID";
            cmbBooking.SelectedIndex = -1;

            conn.Close();
        }
        private void LoadPayments()
        {
            MySqlConnection conn = DatabaseConnection.GetConnection();
            conn.Open();

            string query = @"SELECT 
                    Payment.PaymentID,
                    Payment.BookingID,
                    Customer.Name AS CustomerName,
                    CONCAT(Car.Brand, ' ', Car.Model) AS CarName,
                    Payment.PaymentDate,
                    Payment.Amount,
                    Payment.PaymentMethod,
                    Payment.PaymentStatus
                    FROM Payment
                    INNER JOIN Booking ON Payment.BookingID = Booking.BookingID
                    INNER JOIN Customer ON Booking.CustomerID = Customer.CustomerID
                    INNER JOIN Car ON Booking.CarID = Car.CarID";

            MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
            DataTable table = new DataTable();
            adapter.Fill(table);

            dgvPayments.DataSource = table;

            conn.Close();
        }
        private void ClearFields()
        {
            cmbBooking.SelectedIndex = -1;
            cmbMethod.SelectedIndex = -1;
            cmbStatus.SelectedIndex = -1;

            txtAmount.Clear();
            txtSearch.Clear();

            dtPaymentDate.Value = DateTime.Now;

            selectedPaymentID = 0;
        }

        private void PaymentForm_Load(object sender, EventArgs e)
        {
            LoadBookings();
            LoadPayments();
        }

        private void cmbBooking_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbBooking.SelectedIndex != -1)
            {
                DataRowView row = cmbBooking.SelectedItem as DataRowView;

                if (row != null)
                {
                    txtAmount.Text = row["TotalAmount"].ToString();
                }
            }

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (cmbBooking.SelectedIndex == -1 || txtAmount.Text == "" || cmbMethod.Text == "" || cmbStatus.Text == "")
            {
                MessageBox.Show("Please fill all fields");
                return;
            }

            MySqlConnection conn = DatabaseConnection.GetConnection();
            conn.Open();

            string query = @"INSERT INTO Payment
                (PaymentDate, Amount, PaymentMethod, PaymentStatus, BookingID)
                VALUES
                (@paymentDate, @amount, @method, @status, @bookingID)";

            MySqlCommand cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@paymentDate", dtPaymentDate.Value.Date);
            cmd.Parameters.AddWithValue("@amount", txtAmount.Text);
            cmd.Parameters.AddWithValue("@method", cmbMethod.Text);
            cmd.Parameters.AddWithValue("@status", cmbStatus.Text);
            cmd.Parameters.AddWithValue("@bookingID", cmbBooking.SelectedValue);

            cmd.ExecuteNonQuery();
            conn.Close();

            MessageBox.Show("Payment Added Successfully");

            LoadPayments();
            ClearFields();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (selectedPaymentID == 0)
            {
                MessageBox.Show("Please select a payment first");
                return;
            }

            MySqlConnection conn = DatabaseConnection.GetConnection();
            conn.Open();

            string query = @"UPDATE Payment SET
                PaymentDate=@paymentDate,
                Amount=@amount,
                PaymentMethod=@method,
                PaymentStatus=@status
                WHERE PaymentID=@id";

            MySqlCommand cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@id", selectedPaymentID);
            cmd.Parameters.AddWithValue("@paymentDate", dtPaymentDate.Value.Date);
            cmd.Parameters.AddWithValue("@amount", txtAmount.Text);
            cmd.Parameters.AddWithValue("@method", cmbMethod.Text);
            cmd.Parameters.AddWithValue("@status", cmbStatus.Text);

            cmd.ExecuteNonQuery();
            conn.Close();

            MessageBox.Show("Payment Updated Successfully");

            LoadPayments();
            ClearFields();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (selectedPaymentID == 0)
            {
                MessageBox.Show("Please select a payment first");
                return;
            }

            MySqlConnection conn = DatabaseConnection.GetConnection();
            conn.Open();

            string query = "DELETE FROM Payment WHERE PaymentID=@id";

            MySqlCommand cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@id", selectedPaymentID);

            cmd.ExecuteNonQuery();
            conn.Close();

            MessageBox.Show("Payment Deleted Successfully");

            LoadPayments();
            ClearFields();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        private void dgvPayments_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvPayments.Rows[e.RowIndex];

                selectedPaymentID = Convert.ToInt32(row.Cells["PaymentID"].Value);
                cmbBooking.SelectedValue = row.Cells["BookingID"].Value;
                dtPaymentDate.Value = Convert.ToDateTime(row.Cells["PaymentDate"].Value);
                txtAmount.Text = row.Cells["Amount"].Value.ToString();
                cmbMethod.Text = row.Cells["PaymentMethod"].Value.ToString();
                cmbStatus.Text = row.Cells["PaymentStatus"].Value.ToString();
            }

        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            MySqlConnection conn = DatabaseConnection.GetConnection();
            conn.Open();

            string query = @"SELECT 
                Payment.PaymentID,
                Payment.BookingID,
                Customer.Name AS CustomerName,
                CONCAT(Car.Brand, ' ', Car.Model) AS CarName,
                Payment.PaymentDate,
                Payment.Amount,
                Payment.PaymentMethod,
                Payment.PaymentStatus
                FROM Payment
                INNER JOIN Booking ON Payment.BookingID = Booking.BookingID
                INNER JOIN Customer ON Booking.CustomerID = Customer.CustomerID
                INNER JOIN Car ON Booking.CarID = Car.CarID
                WHERE Customer.Name LIKE @search
                OR Car.Brand LIKE @search
                OR Car.Model LIKE @search
                OR Payment.PaymentMethod LIKE @search
                OR Payment.PaymentStatus LIKE @search";

            MySqlCommand cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@search", "%" + txtSearch.Text + "%");

            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
            DataTable table = new DataTable();
            adapter.Fill(table);

            dgvPayments.DataSource = table;

            conn.Close();
        }

    }
}
