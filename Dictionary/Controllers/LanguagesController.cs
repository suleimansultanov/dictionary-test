using System.Linq;
using System.Threading.Tasks;
using BLL.Services.Interfaces;
using DAL.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Dictionary.Controllers
{
    [Authorize(Roles = "Admin")]
    public class LanguagesController : Controller
    {
        private ILanguageService languageService;

        public LanguagesController(ILanguageService languageService)
        {
            this.languageService = languageService;
        }

        public IActionResult Index()
        {
            var languages = languageService.GetAll().AsEnumerable();
            return View(languages);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Language language)
        {
            await languageService.Create(language);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            await languageService.Delete((int)id);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Update(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var language = languageService.GetLanguage((int)id);
            return View(language);
        }

        [HttpPost]
        public async Task<IActionResult> Update(Language language)
        {
            await languageService.Update(language);
            return RedirectToAction(nameof(Index));
        }
    }
}