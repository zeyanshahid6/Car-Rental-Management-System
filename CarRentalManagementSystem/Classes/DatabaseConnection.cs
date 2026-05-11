using MySql.Data.MySqlClient;

namespace CarRentalManagementSystem.Classes
{
    class DatabaseConnection
    {
        public static string connStr =
            "server=localhost;database=car_rental_system;uid=root;password=;";

        public static MySqlConnection GetConnection()
        {
            return new MySqlConnection(connStr);
        }
    }
}