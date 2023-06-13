using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data;
using WebApp.Data;
using WebApp.Models;
using WebApp.Models.ViewModel;

namespace WebApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "SuperAdmin, Admin")]
    public class OrderAndDeliveryManagementController : Controller
    {
        private readonly ApplicationDbContext _context;

        public OrderAndDeliveryManagementController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            ViewData["CurrentPage"] = "Đơn hàng";
            return View();
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult GetAllOrder()
        {
            var ds = from order in _context.Order
                     where order.IsDeleted == false
                     select new OrderViewModel
                     {
                         Id = order.Id,
                         CustomerName = order.CustomerName,
                         Email = order.Email,
                         PhoneNumber = order.PhoneNumber,
                         ShippingAddress = order.ShippingAddress,
                         TotalAmount = order.TotalAmount,
                         PaymentMethods = order.PaymentMethods,
                         PaymentStatus = order.PaymentStatus,
                         Status = order.Status,
                         Items = (from orderDetail in _context.OrderDetail
                                  where orderDetail.OrderId == order.Id
                                  select new OrderDetailViewModel
                                  {
                                      Id = orderDetail.Id,
                                      OrderId = orderDetail.OrderId,
                                      ProductId = orderDetail.ProductId,
                                      Quantity = orderDetail.Quantity,
                                      UnitPrice = orderDetail.UnitPrice,
                                      Img = _context.Product.FirstOrDefault(i => i.Id == orderDetail.ProductId)!.Img1 ?? "",
                                      ProductName = _context.Product.FirstOrDefault(i => i.Id == orderDetail.ProductId)!.Name ?? "",

                                  }).ToList(),
                         CreatedBy = order.CreatedBy,
                         CreatedDate = order.CreatedDate,
                         IsDeleted = order.IsDeleted,
                     };

            return Ok(ds.ToList());
        }

        [HttpGet]
        public IActionResult ChangeStatus(int orderId, int status)
        {
            JsonResultViewModel json = new JsonResultViewModel();
            try
            {
                Order order = new Order();
                order = _context.Order.FirstOrDefault(i => i.Id == orderId && i.IsDeleted == false);
                order.Status = status;
                _context.Update(order);
                _context.SaveChanges();
                json.Success = true;
                json.Object = order;
                json.Mesaage = "";
                return Ok(json);
            }
            catch (Exception ex)
            {
                json.Success = false;
                json.Object = null;
                json.Mesaage = ex.Message;
                return Ok(json);
            }
        }
    }
}
