using Bibliothek.Model.Entity;
using Bibliothek.Service.Option;
using Bibliothek.UI.Areas.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Bibliothek.UI.Areas.Web.Controllers
{
    public class CheckoutController : Controller
    {
        OrderService _orderService;
        ProductService _productService;
        CustomerService _customerService;
        OrderDetailService _orderDetailService;

        public CheckoutController()
        {
            _orderService = new OrderService();
            _productService = new ProductService();
            _customerService = new CustomerService();
            _orderDetailService = new OrderDetailService();
        }

        public ActionResult Add()
        {
            if (Session["sepet"] == null)
            {
                return Redirect("~/Home/Index");
            }

            ProductCart cart = Session["sepet"] as ProductCart;

            Order o = new Order();

            Customer customer = null;
            if (Session["login"] != null)
            {
                customer = Session["login"] as Customer;
            }

            o.CustomerID = customer.ID;
            o.ShipAddress = customer.Address;
            _customerService.DetachEntity(customer);

            OrderDetail od = new OrderDetail();
            Product p;

            foreach (var item in cart.CartProductList)
            {
                p = _productService.GetByID(item.ID);
                p.UnitsInStock -= item.Quantity;
                _productService.Update(p);
                od.ProductID = item.ID;
                od.Price = item.Price;
                od.Quantity = item.Quantity;
                od.Phone = customer.Phone;
                od.Address = o.ShipAddress;
                o.OrderDetails.Add(od);
                _orderDetailService.DetachEntity(od);
            }

            _orderService.Add(o);

            Session["order"] = o;
            Session["login"] = customer;

            return RedirectToAction("OrderCompleted");
        }

        public ActionResult OrderCompleted()
        {
            Session["sepet"] = null;
            return View();
        }
    }
}