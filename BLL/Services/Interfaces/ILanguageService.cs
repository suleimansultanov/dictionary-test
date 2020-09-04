using System.Linq;
using DAL.Entities;

namespace BLL.Services.Interfaces
{
    public interface ILanguageService : IService<IQueryable<Language>, Language>
    {
        Language GetLanguage(int id);
    }
}
