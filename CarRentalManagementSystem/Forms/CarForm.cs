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
    public partial class CarForm : Form
    {
        int selectedCarID = 0;

        public CarForm()
        {
            InitializeComponent();
        }

        private void LoadCars()
        {
            MySqlConnection conn = DatabaseConnection.GetConnection();
            conn.Open();

            string query = "SELECT * FROM Car";

            MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
            DataTable table = new DataTable();
            adapter.Fill(table);

            dgvCars.DataSource = table;

            conn.Close();
        }

        private void ClearFields()
        {
            txtBrand.Clear();
            txtModel.Clear();
            txtPrice.Clear();
            txtSearch.Clear();

            cmbType.SelectedIndex = -1;
            cmbAvailability.SelectedIndex = -1;

            selectedCarID = 0;
        }

        private void CarForm_Load(object sender, EventArgs e)
        {
            LoadCars();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtBrand.Text == "" || txtModel.Text == "" || cmbType.Text == "" || txtPrice.Text == "" || cmbAvailability.Text == "")
            {
                MessageBox.Show("Please fill all fields");
                return;
            }

            MySqlConnection conn = DatabaseConnection.GetConnection();
            conn.Open();

            string query = "INSERT INTO Car(Brand, Model, Type, PricePerDay, AvailabilityStatus) VALUES(@brand, @model, @type, @price, @availability)";

            MySqlCommand cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@brand", txtBrand.Text);
            cmd.Parameters.AddWithValue("@model", txtModel.Text);
            cmd.Parameters.AddWithValue("@type", cmbType.Text);
            cmd.Parameters.AddWithValue("@price", txtPrice.Text);
            cmd.Parameters.AddWithValue("@availability", cmbAvailability.Text);

            cmd.ExecuteNonQuery();
            conn.Close();

            MessageBox.Show("Car Added Successfully");

            LoadCars();
            ClearFields();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (selectedCarID == 0)
            {
                MessageBox.Show("Please select a car first");
                return;
            }

            MySqlConnection conn = DatabaseConnection.GetConnection();
            conn.Open();

            string query = "UPDATE Car SET Brand=@brand, Model=@model, Type=@type, PricePerDay=@price, AvailabilityStatus=@availability WHERE CarID=@id";

            MySqlCommand cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@id", selectedCarID);
            cmd.Parameters.AddWithValue("@brand", txtBrand.Text);
            cmd.Parameters.AddWithValue("@model", txtModel.Text);
            cmd.Parameters.AddWithValue("@type", cmbType.Text);
            cmd.Parameters.AddWithValue("@price", txtPrice.Text);
            cmd.Parameters.AddWithValue("@availability", cmbAvailability.Text);

            cmd.ExecuteNonQuery();
            conn.Close();

            MessageBox.Show("Car Updated Successfully");

            LoadCars();
            ClearFields();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (selectedCarID == 0)
            {
                MessageBox.Show("Please select a car first");
                return;
            }

            MySqlConnection conn = DatabaseConnection.GetConnection();
            conn.Open();

            string query = "DELETE FROM Car WHERE CarID=@id";

            MySqlCommand cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@id", selectedCarID);

            cmd.ExecuteNonQuery();
            conn.Close();

            MessageBox.Show("Car Deleted Successfully");

            LoadCars();
            ClearFields();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        private void dgvCars_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvCars.Rows[e.RowIndex];

                selectedCarID = Convert.ToInt32(row.Cells["CarID"].Value);
                txtBrand.Text = row.Cells["Brand"].Value.ToString();
                txtModel.Text = row.Cells["Model"].Value.ToString();
                cmbType.Text = row.Cells["Type"].Value.ToString();
                txtPrice.Text = row.Cells["PricePerDay"].Value.ToString();
                cmbAvailability.Text = row.Cells["AvailabilityStatus"].Value.ToString();
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            MySqlConnection conn = DatabaseConnection.GetConnection();
            conn.Open();

            string query = "SELECT * FROM Car WHERE Brand LIKE @search OR Model LIKE @search OR Type LIKE @search OR AvailabilityStatus LIKE @search";

            MySqlCommand cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@search", "%" + txtSearch.Text + "%");

            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
            DataTable table = new DataTable();
            adapter.Fill(table);

            dgvCars.DataSource = table;

            conn.Close();
        }
    }
}


