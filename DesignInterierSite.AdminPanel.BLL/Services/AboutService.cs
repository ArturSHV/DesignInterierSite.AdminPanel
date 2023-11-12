using DesignInterierSite.AdminPanel.BLL.Interfaces.Models;
using DesignInterierSite.AdminPanel.BLL.Interfaces.Services;
using DesignInterierSite.AdminPanel.BLL.Models;
using DesignInterierSite.AdminPanel.DAL.Context;
using DesignInterierSite.AdminPanel.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace DesignInterierSite.AdminPanel.BLL.Services
{
    public class AboutService : IAboutService
	{
		readonly AppDataContext _dataContext;

		public AboutService(DbContext dataContext)
		{
			_dataContext = (AppDataContext)dataContext;
		}
		public async Task<AboutPageAbstract> GetAboutAsync()
		{
			var model = new AboutPageModel()
			{
				AboutModel = await _dataContext.AboutModel.Include(x => x.Image).FirstOrDefaultAsync()
			};

			return model;
		}

		public async Task AddNewAboutAsync(AboutPageAbstract aboutPageModel)
		{
			if (aboutPageModel.AboutModel != null)
			{
				if (aboutPageModel.AboutModel.FormFile != null)
				{
					aboutPageModel.AboutModel.Image.Name = await FileService.UploadFileAsync(aboutPageModel.AboutModel.FormFile) 
						?? aboutPageModel.AboutModel.Image.Name;
				}

				_dataContext.AboutModel.Update(aboutPageModel.AboutModel);

				await _dataContext.SaveChangesAsync();
			}

			else
			{
				throw new NullReferenceException($"{nameof(AboutModel)} can't be null");
			}
		}
	}
}
