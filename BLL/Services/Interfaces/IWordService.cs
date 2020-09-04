using System.Linq;
using DAL.Entities;

namespace BLL.Services.Interfaces
{
    public interface IWordService : IService<IQueryable<Word>, Word>
    {
        Word GetWord(int id);
        IQueryable<Word> GetWordsPaging(int page, int count);
    }
}
