namespace WebApp.Models.ViewModel
{
    public class CategoryViewModel : EntityBase
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int ParentId { get; set; } = 0;
        public string? ParentName { get; set; }

        public static implicit operator Category(CategoryViewModel viewModel)
        {
            return new Category
            {
                Id = viewModel.Id,
                Name = viewModel.Name,
                ParentId = viewModel.ParentId,
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
                ParentId = category.ParentId,
                CreatedBy = category.CreatedBy,
                CreatedDate = category.CreatedDate,
                IsDeleted = category.IsDeleted,
            };
        }
    }
}
