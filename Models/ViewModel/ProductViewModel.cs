using System.ComponentModel.DataAnnotations;

namespace WebApp.Models.ViewModel
{
    public class ProductViewModel : EntityBase
    {
        public int Id { get; set; }
        public string ProductCode { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int Price { set; get; }
        public int Quantity { set; get; }
        public int CategoryId { get; set; }
        public string? CategoryName { get; set; }
        public int BrandId { get; set; }
        public string? BrandName { get; set; }
        public bool HotSale { set; get; }
        public bool HotTrend { set; get; }
        public string Slug { get; set; } = string.Empty;
        public string Img1 { get; set; } = string.Empty;
        public string Img2 { get; set; } = string.Empty;
        public string Img3 { get; set; } = string.Empty;
        public IFormFile? Img1File1 { get; set; }
        public IFormFile? Img1File2 { get; set; }
        public IFormFile? Img1File3 { get; set; }

        public static implicit operator Proudct(ProductViewModel model)
        {
            return new Proudct
            {
                Id = model.Id,
                Name = model.Name,
                Price = model.Price,
                CategoryId = model.CategoryId,
                BrandId = model.BrandId,
                HotSale = model.HotSale,
                HotTrend = model.HotTrend,
                Description = model.Description,
                Quantity = model.Quantity,
                ProductCode = model.ProductCode,
                Img1 = model.Img1,
                Img2 = model.Img2,
                Img3 = model.Img3,
                Slug = model.Slug,
                CreatedBy = model.CreatedBy,
                CreatedDate = model.CreatedDate,
                IsDeleted = model.IsDeleted,
            };
        }

        public static implicit operator ProductViewModel(Proudct proudct)
        {
            return new ProductViewModel
            {
                Id = proudct.Id,
                Name = proudct.Name,
                Price = proudct.Price,
                CategoryId = proudct.CategoryId,
                BrandId = proudct.BrandId,
                HotSale = proudct.HotSale,
                HotTrend = proudct.HotTrend,
                Description = proudct.Description,
                Quantity = proudct.Quantity,
                ProductCode = proudct.ProductCode,
                Img1 = proudct.Img1,
                Img2 = proudct.Img2,
                Img3 = proudct.Img3,
                Slug = proudct.Slug,
                CreatedBy = proudct.CreatedBy,
                CreatedDate = proudct.CreatedDate,
                IsDeleted = proudct.IsDeleted,
            };
        }
    }
}
