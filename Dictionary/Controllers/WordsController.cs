using System.Linq;
using System.Threading.Tasks;
using BLL.Services.Interfaces;
using DAL.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace Dictionary.Controllers
{
    [Authorize(Roles = "Admin")]
    public class WordsController : Controller
    {
        private IWordService wordService;
        private ILanguageService languageService;
        private readonly IConfiguration configuration;

        public WordsController(IWordService wordService, ILanguageService languageService, IConfiguration configuration)
        {
            this.wordService = wordService;
            this.languageService = languageService;
            this.configuration = configuration;
        }
        public IActionResult Index(int page = 1)
        {
            var isAjax = Request.Headers["X-Requested-With"] == "XMLHttpRequest";

            var pageSize = int.Parse(configuration.GetSection("WordsPageSize").Value);
            var words = wordService.GetWordsPaging(page, pageSize).AsEnumerable();
            if (isAjax)
            {
                return Ok(words);
            }
            return View(words);
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Languages = new SelectList(languageService.GetAll(), "Id", "Name");

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Word word)
        {
            await wordService.Create(word);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            wordService.Delete((int)id);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Update(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            ViewBag.Languages = new SelectList(languageService.GetAll(), "Id", "Name");

            var word = wordService.GetWord((int)id);
            return View(word);
        }

        [HttpPost]
        public async Task<IActionResult> Update(Word word)
        {
            await wordService.Update(word);
            return RedirectToAction(nameof(Index));
        }
    }
}