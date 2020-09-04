using System.Linq;
using DAL.Entities;
using DAL.Interfaces.Repositories;

namespace Infrastructure.Implementations.Repositories
{
    public class LanguagesRepository : Repository<Language, int>, ILanguagesRepository
    {
        private readonly AppDbContext _context;
        public LanguagesRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }
        public Language GetLanguage(int id)
        {
            return _context.Language.FirstOrDefault(x => x.Id == id);
        }
    }
}
