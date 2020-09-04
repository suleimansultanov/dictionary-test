using System.Linq;
using DAL.Entities;

namespace DAL.Interfaces.Repositories
{
    public interface IWordsRepository : IRepository<Word, int>
    {
        IQueryable<Word> GetAllInclud();
        Word GetWord(int? id);
        Word TranslateWord(string word, int translateWordId, int translatedWordId);
        IQueryable<Word> GetWordsPaging(int page, int count);
    }
}
