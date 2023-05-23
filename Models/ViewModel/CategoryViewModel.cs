namespace WebApp.Models.ViewModel
{
    public class CategoryViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int ParentId { get; set; } = 0;

        public static implicit operator Category(CategoryViewModel viewModel)
        {
            return new Category
            {
                Id = viewModel.Id,
                Name = viewModel.Name,
                ParentId = viewModel.ParentId
            };
        }
        public static implicit operator CategoryViewModel(Category category)
        {
            return new CategoryViewModel
            {
                Id = category.Id,
                Name = category.Name,
                ParentId = category.ParentId
            };
        }
    }
}
