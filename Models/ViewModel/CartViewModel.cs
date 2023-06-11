namespace WebApp.Models.ViewModel
{
    public class CartViewModel : EntityBase
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public Product? Product { get; set; }


        public static implicit operator CartViewModel(Cart cart)
        {
            return new CartViewModel
            {
                Id = cart.Id,
                ProductId = cart.ProductId,
                IsDeleted = cart.IsDeleted,
                CreatedBy = cart.CreatedBy,
                CreatedDate = cart.CreatedDate,
            };
        }
        public static implicit operator Cart(CartViewModel model)
        {
            return new Cart
            {

                Id = model.Id,
                Quantity = model.Quantity,
                ProductId = model.ProductId,
                IsDeleted = model.IsDeleted,
                CreatedBy = model.CreatedBy,
                CreatedDate = model.CreatedDate,
            };
        }
    }
}
