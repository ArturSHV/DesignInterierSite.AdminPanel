using DesignInterierSite.AdminPanel.DAL.Context;
using Microsoft.EntityFrameworkCore;

namespace DesignInterierSite.AdminPanel.BLL.Services
{
    public class DbConnectionService : AppDataContext
	{
        public DbConnectionService()
        {
            
        }
        public DbConnectionService(DbContextOptions<AppDataContext> options) : base(options)
		{

		}
	}
}
