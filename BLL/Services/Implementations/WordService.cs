using System;
using System.Linq;
using System.Threading.Tasks;
using BLL.Services.Interfaces;
using DAL.Entities;
using DAL.Interfaces.Repositories;

namespace BLL.Services.Implementations
{
    public class WordService : IWordService
    {
        private readonly IUnitOfWork uow;
        public WordService(IUnitOfWork uow)
        {
            this.uow = uow;
        }
        public IQueryable<Word> GetAll()
        {
            return uow.WordsRepository.GetAllInclud();
        }

        public async Task Create(Word entity)
        {
            await uow.WordsRepository.AddAsync(entity);
            await uow.SaveAsync();
        }

        public async Task Update(Word entity)
        {
            uow.WordsRepository.Update(entity);
            await uow.SaveAsync();
        }

        public async Task Delete(int id)
        {
            var word = uow.WordsRepository.GetWord(id);
            if(word==null)
                throw new Exception();
            uow.WordsRepository.Delete(word);
            await uow.SaveAsync();
        }

        public Word GetWord(int id)
        {
            return uow.WordsRepository.GetWord(id);
        }

        public IQueryable<Word> GetWordsPaging(int page, int pageSize)
        {
            return uow.WordsRepository.GetWordsPaging(page, pageSize);
        }
    }
}
