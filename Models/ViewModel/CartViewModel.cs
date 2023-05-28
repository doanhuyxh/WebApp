namespace WebApp.Models.ViewModel
{
    public class CartViewModel : EntityBase
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string? ProductName { get; set; }
        public int UnitPrice { get; set; }
        public int Quantity { get; set; }
        public int SubToTal { get; set; }

        public static implicit operator CartViewModel(Cart cart)
        {
            return new CartViewModel
            {
                Id = cart.Id,
                ProductId = cart.ProductId,
                UnitPrice = cart.UnitPrice,
                Quantity = cart.Quantity,
                SubToTal = cart.SubToTal,
                IsDeleted = cart.IsDeleted,
                CreatedBy = cart.CreatedBy,
                CreatedDate = cart.CreatedDate,
            };
        }
        public static implicit operator Cart(CartViewModel model)
        {
            return new CartViewModel
            {

                Id = model.Id,
                ProductId = model.ProductId,
                UnitPrice = model.UnitPrice,
                Quantity = model.Quantity,
                SubToTal = model.SubToTal,
                IsDeleted = model.IsDeleted,
                CreatedBy = model.CreatedBy,
                CreatedDate = model.CreatedDate,
            };
        }
    }
}
