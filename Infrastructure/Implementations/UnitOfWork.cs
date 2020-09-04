using System;
using System.Threading.Tasks;
using DAL.Interfaces.Repositories;
using Infrastructure.Implementations.Repositories;

namespace Infrastructure.Implementations
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext context;
        private IWordsRepository wordsRepository;
        private ILanguagesRepository languagesRepository;

        public UnitOfWork(AppDbContext context)
        {
            this.context = context;
        }
        public IWordsRepository WordsRepository
        {
            get { return wordsRepository = new WordRepository(context); }
        }
        public ILanguagesRepository LanguagesRepository
        {
            get { return languagesRepository = new LanguagesRepository(context); }
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public async Task SaveAsync()
        {
            await context.SaveChangesAsync();
        }

        private bool _disposed;

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
