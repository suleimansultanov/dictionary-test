using Common.Dto;

namespace BLL.Services.Interfaces
{
    public interface IDictionaryService
    {
        string TranslateWord(TranslateWordDto dto);
    }
}
