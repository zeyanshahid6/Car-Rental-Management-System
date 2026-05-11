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
    public partial class CustomerForm : Form
    {
        int selectedCustomerID = 0;

        public CustomerForm()
        {
            InitializeComponent();
        }

        private void LoadCustomers()
        {
            MySqlConnection conn = DatabaseConnection.GetConnection();
            conn.Open();

            string query = "SELECT * FROM Customer";

            MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
            DataTable table = new DataTable();
            adapter.Fill(table);

            dgvCustomers.DataSource = table;

            conn.Close();
        }

        private void CustomerForm_Load(object sender, EventArgs e)
        {
            LoadCustomers();
        }
        private void ClearFields()
        {
            txtName.Clear();
            txtEmail.Clear();
            txtPhone.Clear();
            txtLicense.Clear();
            txtSearch.Clear();

            selectedCustomerID = 0;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtName.Text == "" || txtEmail.Text == "" || txtPhone.Text == "" || txtLicense.Text == "")
            {
                MessageBox.Show("Please fill all fields");
                return;
            }

            MySqlConnection conn = DatabaseConnection.GetConnection();
            conn.Open();

            string query = "INSERT INTO Customer(Name, Email, PhoneNumber, DrivingLicenseNumber) VALUES(@name, @email, @phone, @license)";

            MySqlCommand cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@name", txtName.Text);
            cmd.Parameters.AddWithValue("@email", txtEmail.Text);
            cmd.Parameters.AddWithValue("@phone", txtPhone.Text);
            cmd.Parameters.AddWithValue("@license", txtLicense.Text);

            cmd.ExecuteNonQuery();
            conn.Close();

            MessageBox.Show("Customer Added Successfully");

            LoadCustomers();
            ClearFields();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (selectedCustomerID == 0)
            {
                MessageBox.Show("Please select a customer first");
                return;
            }

            MySqlConnection conn = DatabaseConnection.GetConnection();
            conn.Open();

            string query = "UPDATE Customer SET Name=@name, Email=@email, PhoneNumber=@phone, DrivingLicenseNumber=@license WHERE CustomerID=@id";

            MySqlCommand cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@id", selectedCustomerID);
            cmd.Parameters.AddWithValue("@name", txtName.Text);
            cmd.Parameters.AddWithValue("@email", txtEmail.Text);
            cmd.Parameters.AddWithValue("@phone", txtPhone.Text);
            cmd.Parameters.AddWithValue("@license", txtLicense.Text);

            cmd.ExecuteNonQuery();
            conn.Close();

            MessageBox.Show("Customer Updated Successfully");

            LoadCustomers();
            ClearFields();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (selectedCustomerID == 0)
            {
                MessageBox.Show("Please select a customer first");
                return;
            }

            MySqlConnection conn = DatabaseConnection.GetConnection();
            conn.Open();

            string query = "DELETE FROM Customer WHERE CustomerID=@id";

            MySqlCommand cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@id", selectedCustomerID);

            cmd.ExecuteNonQuery();
            conn.Close();

            MessageBox.Show("Customer Deleted Successfully");

            LoadCustomers();
            ClearFields();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        private void dgvCustomers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvCustomers.Rows[e.RowIndex];

                selectedCustomerID = Convert.ToInt32(row.Cells["CustomerID"].Value);
                txtName.Text = row.Cells["Name"].Value.ToString();
                txtEmail.Text = row.Cells["Email"].Value.ToString();
                txtPhone.Text = row.Cells["PhoneNumber"].Value.ToString();
                txtLicense.Text = row.Cells["DrivingLicenseNumber"].Value.ToString();
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            MySqlConnection conn = DatabaseConnection.GetConnection();
            conn.Open();

            string query = "SELECT * FROM Customer WHERE Name LIKE @search OR Email LIKE @search OR PhoneNumber LIKE @search";

            MySqlCommand cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@search", "%" + txtSearch.Text + "%");

            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
            DataTable table = new DataTable();
            adapter.Fill(table);

            dgvCustomers.DataSource = table;

            conn.Close();
        }
    }
}


