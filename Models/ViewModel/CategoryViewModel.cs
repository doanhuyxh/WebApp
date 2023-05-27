using System.ComponentModel.DataAnnotations;

namespace WebApp.Models.ViewModel
{
    public class CategoryViewModel : EntityBase
    {
        public int Id { get; set; }
        public string Icon { get; set; } = "-";
        [Display(Name = "Tên loại")]
        public string Name { get; set; } = string.Empty;
        [Display(Name = "Danh mục cha")]
        public int ParentId { get; set; } = 0;
        public string? ParentName { get; set; }

        public static implicit operator Category(CategoryViewModel viewModel)
        {
            return new Category
            {
                Id = viewModel.Id,
                Name = viewModel.Name,
                ParentId = viewModel.ParentId,
                Icon = viewModel.Icon,
                CreatedBy = viewModel.CreatedBy,
                CreatedDate = viewModel.CreatedDate,
                IsDeleted = viewModel.IsDeleted,
            };
        }
        public static implicit operator CategoryViewModel(Category category)
        {
            return new CategoryViewModel
            {
                Id = category.Id,
                Name = category.Name,
                Icon = category.Icon,
                ParentId = category.ParentId,
                CreatedBy = category.CreatedBy,
                CreatedDate = category.CreatedDate,
                IsDeleted = category.IsDeleted,
            };
        }
    }
}
