using System.ComponentModel.DataAnnotations;

namespace WebApp.Models
{
    public class Brand : EntityBase
    {
        [Key]
        public int Id { get; set; }
        public string BrandName { get; set; } = string.Empty;
        public string BrandDescription { get; set; } = string.Empty;
        public string BrandImgLogo { get; set; } = string.Empty;
    }
}
