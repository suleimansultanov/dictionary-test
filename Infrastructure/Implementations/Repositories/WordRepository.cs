using System.Linq;
using DAL.Entities;
using DAL.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Implementations.Repositories
{
    public class WordRepository : Repository<Word, int>, IWordsRepository
    {
        private readonly AppDbContext _context;
        public WordRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public IQueryable<Word> GetAllInclud()
        {
            return _context.Words.Include(x => x.OriginalLanguage).Include(z => z.TranslateLanguage);
        }

        public Word GetWord(int? id)
        {
            return _context.Words.FirstOrDefault(x => x.Id == id);
        }

        public Word TranslateWord(string word, int translatingWordId, int translatedWordId)
        {
            var wordPair = _context.Words.Where(x =>
                x.OriginalId == translatingWordId && x.TranslateId == translatedWordId ||
                x.TranslateId == translatingWordId && x.OriginalId == translatedWordId);

            return wordPair.FirstOrDefault(x => x.Original.ToLower().Equals(word.ToLower()) 
                                                || x.Translate.ToLower().Equals(word.ToLower()));
        }

        public IQueryable<Word> GetWordsPaging(int page, int pageSize)
        {
            return GetAllInclud().Skip((page - 1) * pageSize).Take(pageSize);
        }
    }
}
