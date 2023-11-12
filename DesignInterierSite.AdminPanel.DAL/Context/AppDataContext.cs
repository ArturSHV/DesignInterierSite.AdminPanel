using DesignInterierSite.AdminPanel.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace DesignInterierSite.AdminPanel.DAL.Context
{
	public class AppDataContext : DbContext
	{
		public DbSet<AboutModel> AboutModel { get; set; }
		public DbSet<ImagesModel> ImagesModel { get; set; }

        public AppDataContext()
        {
            
        }
        public AppDataContext(DbContextOptions<AppDataContext> options) : base(options)
		{
			
		}
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			var connectionString = Environment.GetEnvironmentVariable("TestConnection", EnvironmentVariableTarget.Machine);

            optionsBuilder.UseSqlServer(connectionString);
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);
		}
	}
}