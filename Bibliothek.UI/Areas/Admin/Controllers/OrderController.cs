using Bibliothek.Model.Entity;
using Bibliothek.Service.Option;
using Bibliothek.UI.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;

namespace Bibliothek.UI.Areas.Admin.Controllers
{
    [CustomAuthorize(Role.Admin)]
    public class OrderController : Controller
    {
        OrderService _orderService;
        OrderDetailService _orderDetailsService;
        ProductService _productService;

        public OrderController()
        {
            _productService = new ProductService();
            _orderDetailsService = new OrderDetailService();
            _orderService = new OrderService();
        }


        [HttpGet]
        public ActionResult List(int page = 1)
        {
            List<Order> model = _orderService.ListPendingOrders();
            return View(model.ToPagedList(page, 5));
        }

        public ActionResult Details(Guid Id)
        {
            List<OrderDetail> model = _orderDetailsService.GetDefault(x => x.Order.ID == Id);
            return View(model);
        }

        public RedirectResult ConfirmOrder(Guid Id)
        {
            Order order = new Order();
            order = _orderService.GetByID(Id);

            order.Confirmed = true;
            _orderService.Update(order);
            return Redirect("~/Admin/Order/List");
        }

        public RedirectResult RejectOrder(Guid Id)
        {
            Order order = _orderService.GetByID(Id);

            foreach (var item in order.OrderDetails)
            {
                Product p = _productService.GetByID(item.Product.ID);
                p.UnitsInStock += Convert.ToInt16(item.Product.Quantity);
                p.Status = Core.Enum.Status.Deleted;
                _productService.Update(p);
            }

            order.Confirmed = false;
            order.Status = Core.Enum.Status.Deleted;
            _orderService.Update(order);
            return Redirect("~/Admin/Order/List");

        }
    }
}