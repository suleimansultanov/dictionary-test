using System.ComponentModel.DataAnnotations;

namespace Common.Dto
{
    public class TranslateWordDto
    {
        [Required]
        public string Word { get; set; }
        [Required]
        public int TranslatingLangId { get; set; }
        [Required]
        public int TranslatedLangId { get; set; }
    }
}
