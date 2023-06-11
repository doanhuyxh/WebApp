namespace WebApp.Models.ViewModel
{
    public class OrderDetailViewModel
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public int UnitPrice { get; set; }
        public string? ProductName { get; set; }
        public string? Img { get; set; }
        public int Quantity { get; set; }
        public static implicit operator OrderDetail(OrderDetailViewModel model)
        {
            return new OrderDetail
            {
                Id = model.Id,
                OrderId = model.OrderId,
                ProductId = model.ProductId,
                Quantity = model.Quantity,
                UnitPrice = model.UnitPrice,
            };
        }
        public static implicit operator OrderDetailViewModel(OrderDetail orderdetail)
        {
            return new OrderDetailViewModel
            {
                Id = orderdetail.Id,
                OrderId = orderdetail.OrderId,
                ProductId = orderdetail.ProductId,
                Quantity = orderdetail.Quantity,
                UnitPrice = orderdetail.UnitPrice,
            };
        }
    }
}
