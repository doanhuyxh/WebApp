using System.ComponentModel.DataAnnotations;

namespace WebApp.Models
{
    public class Proudct : EntityBase
    {
        [Key]
        public int Id { get; set; }
        public string ProductCode { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int Price { set; get; }
        public int Quantity { set; get; }
        public int CategoryId { get; set; }
        public int BrandId { get; set; }
        public bool HotSale { set; get; }
        public bool HotTrend { set; get; }
        public string Slug { get; set; } = string.Empty;
        public string Img1 { get; set; } = string.Empty;
        public string Img2 { get; set; } = string.Empty;
        public string Img3 { get; set; } = string.Empty;
    }
}
