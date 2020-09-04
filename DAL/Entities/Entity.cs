using System.ComponentModel.DataAnnotations;

namespace DAL.Entities
{
    public abstract class Entity<T>
    {
        [Key]
        public T Id { get; set; }
    }
}
