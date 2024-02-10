using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace DataAccess
{
    public class AppInfo
    {
        public AppInfo()
        {
	        Populate();
        }

        private void Populate()
        {
            var settings = new ConfigurationBuilder()
                .AddJsonFile("appSettingsData.json")
                .Build();

            var sqlBuilder = new SqlConnectionStringBuilder
            {
                DataSource = settings["Database:Server"],
                InitialCatalog = settings["Database:Name"],
                UserID = settings["Database:User"],
                Password = settings["Database:Password"] //Crypt.Decrypt(settings["Database:Password"])
            };

            ConnectionString = sqlBuilder.ToString();
            DbName = settings["Database:Name"];
            CompanyShortName = settings["CompanySpecific:ShortName"];
            CompanyFullName = settings["CompanySpecific:FullName"];
            CompanyLogo = settings["CompanySpecific:Logo"];
            SupportEmail = settings["SupportEmail"];
        }

        public string ConnectionString { get; set; } = null!;
        public string DbName { get; set; } = null!;
        public string CompanyShortName { get; set; } = null!;
        public string CompanyFullName { get; set; } = null!;
        public string CompanyLogo { get; set; } = null!;
        public string SupportEmail { get; set; } = null!;

    }
}