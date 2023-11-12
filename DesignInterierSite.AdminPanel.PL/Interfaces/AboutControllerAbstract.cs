using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DesignInterierSite.AdminPanel.PL.Interfaces
{
    public abstract class AboutControllerAbstract<T> : Controller where T : AboutPageAbstract
    {
        private readonly IAboutService _aboutService;
        public AboutControllerAbstract(IAboutService aboutService)
        {
            _aboutService = aboutService;
        }

        public async Task<IActionResult> Index()
        {
            var result = await _aboutService.GetAboutAsync();

            return View(result);
        }

        [HttpPost]
        public async Task<IActionResult> AboutHandler(T aboutPageModel)
        {
            try
            {
                await _aboutService.AddNewAboutAsync(aboutPageModel);

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex switch
                {
                    DbUpdateException => "Обязательные поля для заполнения: Заголовок, описание, картинка",
                    NullReferenceException => ex.Message,
                    _ => ex.Message,
                };
            }

            return View(nameof(Index), aboutPageModel);
        }
    }
}
