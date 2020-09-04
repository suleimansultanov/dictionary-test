using DAL.Entities;

namespace DAL.Interfaces.Repositories
{
    public interface ILanguagesRepository : IRepository<Language, int>
    {
        Language GetLanguage(int id);
    }
}
