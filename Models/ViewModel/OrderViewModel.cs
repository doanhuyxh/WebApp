namespace WebApp.Models.ViewModel
{
    public class OrderViewModel : EntityBase
    {
        public int Id { get; set; }
        public string ShippingAddress { get; set; }
        public int TotalAmount { get; set; }
        public int Status { get; set; } // 1 Đang Chờ 2//Đang Giao 3//Hoàn thành

        public static implicit operator OrderViewModel(Order order)
        {
            return new OrderViewModel
            {
                Id = order.Id,
                ShippingAddress = order.ShippingAddress,
                TotalAmount = order.TotalAmount,
                Status = order.Status,
                IsDeleted = order.IsDeleted,
                CreatedBy = order.CreatedBy,
                CreatedDate = order.CreatedDate,
            };
        }
        public static implicit operator Order(OrderViewModel model)
        {
            return new Order
            {
                Id = model.Id,
                ShippingAddress = model.ShippingAddress,
                TotalAmount = model.TotalAmount,
                Status = model.Status,
                IsDeleted = model.IsDeleted,
                CreatedBy = model.CreatedBy,
                CreatedDate = model.CreatedDate,
            };
        }
    }
}
