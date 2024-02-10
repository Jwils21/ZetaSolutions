using Data.Models;
using DataObjects;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories
{
	public class BaseRepository
	{
		protected readonly ZetaSolutionsContext Database;
		internal readonly AppInfo AppInfo;

		public BaseRepository()
		{
			AppInfo = new AppInfo();
			Database = new ZetaSolutionsContext().CreateDbContext(AppInfo.ConnectionString, 0);
		}
	}
	
	
	public class AppSettings
	{
		public AppSettings(string databaseServer, string databaseName, string databaseUser, string databasePassword){
			DbPassword = databaseServer;
			DbName = databaseName;
			DbUser = databaseUser;
			DbPassword = databasePassword;
		}

		public string DbServer { get; set; }
		public string DbName { get; set; }
		public string DbUser { get; set; }
		public string DbPassword { get; set; }
	}
}
