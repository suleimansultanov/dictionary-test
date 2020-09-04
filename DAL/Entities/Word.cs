using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Entities
{
    public class Word : Entity<int>
    {
        public string Original { get; set; }
        public string Translate { get; set; }
        [ForeignKey("OriginalLanguage")]
        public int OriginalId { get; set; }
        public virtual Language OriginalLanguage { get; set; }
        [ForeignKey("TranslateLanguage")]
        public int TranslateId { get; set; }
        public virtual Language TranslateLanguage { get; set; }
    }
}
