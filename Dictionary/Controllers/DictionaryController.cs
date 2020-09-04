using BLL.Services.Interfaces;
using Common.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Dictionary.Controllers
{
    [Authorize(Roles = "Admin, User")]
    public class DictionaryController : Controller
    {
        private ILanguageService languageService;
        private IDictionaryService dictionaryService;

        public DictionaryController(ILanguageService languageService, IDictionaryService dictionaryService)
        {
            this.languageService = languageService;
            this.dictionaryService = dictionaryService;
        }

        public IActionResult Index()
        {
            ViewBag.Languages = new SelectList(languageService.GetAll(), "Id", "Name");

            return View();
        }

        public IActionResult Translate(TranslateWordDto model)
        {
            if (!ModelState.IsValid)
            {
                return Json(new {success = false, response="Введите правильные данные"});
            }

            var response = dictionaryService.TranslateWord(model);
            if(response==null)
                return Json(new { success = false, response = "В словаре нет подходящего слова" });

            return Json(new {success = true, response });
        }
    }
}