using DesignInterierSite.AdminPanel.PL.Interfaces;

namespace DesignInterierSite.AdminPanel.PL.Controllers
{

    public class AboutController : AboutControllerAbstract<AboutPageModel>
	{
		public AboutController(IAboutService aboutService) : base(aboutService)
		{

		}
	}
}
