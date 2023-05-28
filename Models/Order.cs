using System.ComponentModel.DataAnnotations;

namespace WebApp.Models
{
    public class Order : EntityBase
    {
        [Key]
        public int Id { get; set; }
        public string ShippingAddress { get; set; }
        public int TotalAmount { get; set; }
        public int Status { get; set; } // 1 Đang Chờ 2//Đang Giao 3//Hoàn thành
    }
}
