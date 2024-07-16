using System.ComponentModel.DataAnnotations;

namespace MyWebApi.Models
{
    public abstract class BaseModel<TKey>
    {
        [Key]
        public TKey Id { get; set; }
        public DateTime CreateDate { get; set; } = DateTime.Now;
    }
}
