using DesignInterierSite.AdminPanel.DAL.Context;
using Microsoft.EntityFrameworkCore;

namespace DesignInterierSite.AdminPanel.BLL.Tests
{
	public class TestDbContext : AppDataContext
	{
		public TestDbContext(DbContextOptions<AppDataContext> options) : base(options)
		{
			
		}

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			
		}
	}
}