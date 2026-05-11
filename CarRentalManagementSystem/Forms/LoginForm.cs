using System;
using System.Collections.Generic;
using System.ComponentModel;
using CarRentalManagementSystem.Classes;
using MySql.Data.MySqlClient;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarRentalManagementSystem.Forms
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            MySqlConnection conn = DatabaseConnection.GetConnection();

            conn.Open();

            string query = "SELECT * FROM Admin WHERE Username=@user AND Password=@pass";

            MySqlCommand cmd = new MySqlCommand(query, conn);

            cmd.Parameters.AddWithValue("@user", txtUsername.Text);
            cmd.Parameters.AddWithValue("@pass", txtPassword.Text);

            MySqlDataReader reader = cmd.ExecuteReader();

            if (reader.HasRows)
            {
                MessageBox.Show("Login Successful");

                DashboardForm dashboard = new DashboardForm();
                dashboard.Show();

                this.Hide();
            }
            else
            {
                MessageBox.Show("Invalid Username or Password");
            }

            conn.Close();
        }

        private void btnCustomerPortal_Click(object sender, EventArgs e)
        {
            CustomerPortalForm portal = new CustomerPortalForm();
            portal.Show();
            this.Hide();
        }

    }
}
