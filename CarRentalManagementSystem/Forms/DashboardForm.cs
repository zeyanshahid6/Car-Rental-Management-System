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
    public partial class DashboardForm : Form
    {
        public DashboardForm()
        {
            InitializeComponent();
        }

        private void LoadDashboardCounts()
        {
            MySqlConnection conn = DatabaseConnection.GetConnection();

            conn.Open();

            MySqlCommand cmdCustomers = new MySqlCommand("SELECT COUNT(*) FROM Customer", conn);
            lblTotalCustomers.Text = cmdCustomers.ExecuteScalar().ToString();

            MySqlCommand cmdCars = new MySqlCommand("SELECT COUNT(*) FROM Car", conn);
            lblTotalCars.Text = cmdCars.ExecuteScalar().ToString();

            MySqlCommand cmdBookings = new MySqlCommand("SELECT COUNT(*) FROM Booking", conn);
            lblTotalBookings.Text = cmdBookings.ExecuteScalar().ToString();

            conn.Close();
        }

        private void lblTitle_Click(object sender, EventArgs e)
        {

        }

        private void DashboardForm_Load(object sender, EventArgs e)
        {
            LoadDashboardCounts();
        }

        private void btnCustomers_Click(object sender, EventArgs e)
        {
            CustomerForm customerForm = new CustomerForm();
            customerForm.Show();
        }

        private void btnCars_Click(object sender, EventArgs e)
        {
            CarForm carForm = new CarForm();
            carForm.Show();
        }

        private void btnBookings_Click(object sender, EventArgs e)
        {
            BookingForm bookingForm = new BookingForm();
            bookingForm.Show();
        }

        private void btnPayments_Click(object sender, EventArgs e)
        {
            PaymentForm paymentForm = new PaymentForm();
            paymentForm.Show();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
      "Are you sure you want to logout?",
      "Logout",
      MessageBoxButtons.YesNo,
      MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                LoginForm loginForm = new LoginForm();
                loginForm.Show();

                this.Hide();
            }
        }
    }
}
   
