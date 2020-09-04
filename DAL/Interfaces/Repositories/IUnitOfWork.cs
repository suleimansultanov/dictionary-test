using System;
using System.Threading.Tasks;

namespace DAL.Interfaces.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        IWordsRepository WordsRepository { get; }
        ILanguagesRepository LanguagesRepository { get; }

        void Save();
        Task SaveAsync();
    }
}
