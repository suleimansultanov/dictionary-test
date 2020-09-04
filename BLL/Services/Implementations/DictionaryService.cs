using BLL.Services.Interfaces;
using Common.Dto;
using DAL.Interfaces.Repositories;

namespace BLL.Services.Implementations
{
    public class DictionaryService : IDictionaryService
    {
        private readonly IUnitOfWork uow;

        public DictionaryService(IUnitOfWork uow)
        {
            this.uow = uow;
        }

        public string TranslateWord(TranslateWordDto dto)
        {
            var result = uow.WordsRepository.TranslateWord(dto.Word, dto.TranslatingLangId, dto.TranslatedLangId);

            return dto.Word.Equals(result?.Translate) ? result?.Original : result?.Translate;
        }
    }
}
