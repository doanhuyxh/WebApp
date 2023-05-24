using System.ComponentModel.DataAnnotations;

namespace WebApp.Models
{
    public class Category : EntityBase
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int ParentId { get; set; } = 0;
    }
}
