using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;

namespace BankingSystemAssignment.Tasks7_14.Util
{
    internal static class DBConnUtil
    {
        private static IConfiguration _iConfiguration;
        static DBConnUtil()
        {
            GetAppSettingsFile();
        }

        private static void GetAppSettingsFile()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");
            _iConfiguration = builder.Build();
        }

        private static string GetConnString()
        {
            return _iConfiguration.GetConnectionString("LocalConnectionString");
        }

        private static SqlConnection connection = null;
        public static SqlConnection GetDBConn()
        {
            string connectionString = GetConnString();
            connection = new SqlConnection(connectionString);
            return connection;
        }
    }
}
