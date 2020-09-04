using System.Linq;
using System.Threading.Tasks;
using BLL.Services.Interfaces;
using DAL.Entities;
using DAL.Interfaces.Repositories;

namespace BLL.Services.Implementations
{
    public class LanguageService : ILanguageService
    {
        private readonly IUnitOfWork uow;
        public LanguageService(IUnitOfWork uow)
        {
            this.uow = uow;
        }
        public IQueryable<Language> GetAll()
        {
            return uow.LanguagesRepository.All;
        }

        public async Task Create(Language entity)
        {
            await uow.LanguagesRepository.AddAsync(entity);
            await uow.SaveAsync();
        }

        public async Task Update(Language entity)
        {
            uow.LanguagesRepository.Update(entity);
            await uow.SaveAsync();
        }

        public async Task Delete(int id)
        {
            await uow.LanguagesRepository.DeleteByIdAsync(id);
            await uow.SaveAsync();
        }

        public Language GetLanguage(int id)
        {
            return uow.LanguagesRepository.GetLanguage(id);
        }
    }
}
