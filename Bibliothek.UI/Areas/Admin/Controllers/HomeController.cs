using Bibliothek.Model.Entity;
using Bibliothek.Service.Option;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Bibliothek.UI.Areas.Admin.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        OrderService _orderService;
        OrderDetailService _orderDetailService;
        public HomeController()
        {
            _orderService = new OrderService();
            _orderDetailService = new OrderDetailService();
        }

        public ActionResult Index()
        {
            ViewBag.CurrentUser = User.Identity.Name;
            List<Order> model = _orderService.GetDefault(x => x.Confirmed == false && x.Status == Core.Enum.Status.Active);
            ViewBag.Siparis = model.Count;

            return View();
        }
    }
}