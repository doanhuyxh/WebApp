namespace WebApp.Models.ViewModel
{
    public class OrderViewModel : EntityBase
    {
        public int Id { get; set; }
        public string CustomerName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string ShippingAddress { get; set; }
        public int TotalAmount { get; set; }
        public int PaymentMethods { get; set; }
        public bool PaymentStatus { get; set; }
        public int Status { get; set; } // 1 Đang Chờ 2//Đang Giao 3//Hoàn thành

        public List<OrderDetailViewModel> Items { get; set; }

        public static implicit operator OrderViewModel(Order order)
        {
            return new OrderViewModel
            {
                Id = order.Id,
                CustomerName = order.CustomerName,
                Email = order.Email,
                PhoneNumber = order.PhoneNumber,
                PaymentMethods = order.PaymentMethods,
                PaymentStatus = order.PaymentStatus,
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
                CustomerName = model.CustomerName,
                Email = model.Email,
                PhoneNumber = model.PhoneNumber,
                PaymentMethods = model.PaymentMethods,
                PaymentStatus = model.PaymentStatus,
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
