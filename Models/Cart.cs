using System.ComponentModel.DataAnnotations;

namespace WebApp.Models
{
    public class Cart : EntityBase
    {
        [Key] public int Id { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }


    }
}
