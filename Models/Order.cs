using System.ComponentModel.DataAnnotations;

namespace WebApp.Models
{
    public class Order : EntityBase
    {
        [Key]
        public int Id { get; set; }
        public string CustomerName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string ShippingAddress { get; set; }
        public int TotalAmount { get; set; }
        public int PaymentMethods { get; set; } // 1 là thanh toán khi nhận hàng  2 là thanh toán qua chuyển khoản
        public bool PaymentStatus { get; set; } // true là đã thanh toán false là chưa thanh toán
        public int Status { get; set; } // 1 Đang Chờ 2//Đang Giao 3//Hoàn thành
    }
}
