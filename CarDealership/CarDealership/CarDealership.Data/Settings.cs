using System.Configuration;

namespace CarDealership.Data
{ 
    public class Settings
    {
        private static string _connectionString;

        public static string GetConnectionString()
        {
            if (string.IsNullOrEmpty(_connectionString))
            {
                _connectionString = ConfigurationManager.ConnectionStrings["GuildCars"].ConnectionString;

            }
            return _connectionString;
        }
    }
}

