using System.ComponentModel.DataAnnotations;

namespace WebApp.Models.ViewModel
{
    public class ProductViewModel : EntityBase
    {
        public int Id { get; set; }
        [Display(Name = "Mã sản phẩm")]
        public string ProductCode { get; set; } = string.Empty;
        [Display(Name = "Tên sản phẩm")]
        public string Name { get; set; } = string.Empty;
        [Display(Name = "Mô tả / Thông số sản phẩm")]
        public string Description { get; set; } = string.Empty;
        [Display(Name = "Giá sản phẩm")]
        public int Price { set; get; }
        [Display(Name = "Số lượng")]
        public int Quantity { set; get; }
        [Display(Name = "Loại sản phẩm")]
        public int CategoryId { get; set; }
        public string? CategoryName { get; set; }
        [Display(Name = "Thương hiệu")]
        public int BrandId { get; set; }
        public string? BrandName { get; set; }
        [Display(Name = "Bán chạy")]
        public bool HotSale { set; get; }
        [Display(Name = "Xu hướng")]
        public bool HotTrend { set; get; }
        [Display(Name = "Slug")]
        public string Slug { get; set; } = string.Empty;
        public string Img1 { get; set; } = string.Empty;
        public string Img2 { get; set; } = string.Empty;
        public string Img3 { get; set; } = string.Empty;
        public bool Stop { set; get; }
        [Display(Name = "Ảnh 1")]
        public IFormFile? Img1File1 { get; set; }
        [Display(Name = "Ảnh 2")]
        public IFormFile? Img1File2 { get; set; }
        [Display(Name = "Ảnh 3")]
        public IFormFile? Img1File3 { get; set; }

        public static implicit operator Product(ProductViewModel model)
        {
            return new Product
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
                Stop = model.Stop,
                CreatedBy = model.CreatedBy,
                CreatedDate = model.CreatedDate,
                IsDeleted = model.IsDeleted,
            };
        }

        public static implicit operator ProductViewModel(Product proudct)
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
                Stop = proudct.Stop,
                CreatedBy = proudct.CreatedBy,
                CreatedDate = proudct.CreatedDate,
                IsDeleted = proudct.IsDeleted,
            };
        }
    }
}
