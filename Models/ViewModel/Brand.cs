using System.ComponentModel.DataAnnotations;

namespace WebApp.Models.ViewModel
{
    public class BrandViewModel
    {
        public int Id { get; set; }
        [Display(Name = "Tên thương hiệu")]
        public string BrandName { get; set; } = string.Empty;
        [Display(Name = "Mô tả")]
        public string BrandDescription { get; set; } = string.Empty;
        public string BrandImgLogo { get; set; } = string.Empty;
        [Display(Name = "Logo")]
        public IFormFile? BrandImgFile { get; set; }

        public static implicit operator Brand(BrandViewModel vm)
        {
            return new Brand
            {
                Id = vm.Id,
                BrandName = vm.BrandName,
                BrandDescription = vm.BrandDescription,
                BrandImgLogo = vm.BrandImgLogo,
            };
        }
        public static implicit operator BrandViewModel(Brand brand)
        {
            return new BrandViewModel
            {
                Id = brand.Id,
                BrandName = brand.BrandName,
                BrandDescription = brand.BrandDescription,
                BrandImgLogo = brand.BrandImgLogo,
            };
        }
    }
}
