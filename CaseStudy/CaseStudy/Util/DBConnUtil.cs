using Microsoft.Extensions.Configuration;

namespace CaseStudy.Util
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

        public static string GetConnString()
        {
            return _iConfiguration.GetConnectionString("LocalConnectionString");
        }
    }
}
