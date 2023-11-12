using DesignInterierSite.AdminPanel.BLL.Interfaces.Models;
using DesignInterierSite.AdminPanel.BLL.Models;

namespace DesignInterierSite.AdminPanel.BLL.Interfaces.Services
{
    public interface IAboutService
    {
        public Task<AboutPageAbstract> GetAboutAsync();
        public Task AddNewAboutAsync(AboutPageAbstract aboutPageModel);
    }
}
