using Bibliothek.Model.Entity;
using Bibliothek.Service.Option;
using Bibliothek.UI.Areas.Web.Models;
using Bibliothek.UI.Areas.Web.Models.VM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Bibliothek.UI.Areas.Web.Controllers
{
    public class CartController : Controller
    {
        ProductService _productService;

        public CartController()
        {
            _productService = new ProductService();
        }

        public ActionResult Index()
        {
            return View();
        }

        public JsonResult List()
        {
            if (Session["sepet"] != null)
            {
                
                ProductCart cart = Session["sepet"] as ProductCart;
                List<ProductVM> productList = cart.CartProductList.Select(x => new ProductVM
                {
                    ID = x.ID,
                    Name = x.Name,
                    Price = x.Price,
                    UnitsInStock = x.UnitsInStock,
                    Quantity = x.Quantity
                }).ToList();
                return Json(productList, JsonRequestBehavior.AllowGet);
            }
            return Json("Empty", JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Add(Guid id)
        {
            Product product = _productService.GetByID(id);
            ProductVM model = new ProductVM
            {
                ID = product.ID,
                Name = product.Name,
                Price = product.Price,
                UnitsInStock = product.UnitsInStock,
                Quantity = 1
            };

            if (Session["sepet"] != null)
            {
                ProductCart cart = Session["sepet"] as ProductCart;
                cart.AddCart(model);
                Session["sepet"] = cart;
            }
            else
            {
                ProductCart cart = new ProductCart();
                cart.AddCart(model);
                Session.Add("sepet", cart);
            }

            return Json("OK", JsonRequestBehavior.AllowGet);
        }

        public JsonResult IncreaseCart(Guid id)
        {
            ProductCart cart = Session["sepet"] as ProductCart;
            cart.IncreaseCart(id);
            Session["sepet"] = cart;
            return Json("");
        }

        public JsonResult DecreaseCart(Guid id)
        {
            if (Session["sepet"] != null)
            {
                ProductCart cart = Session["sepet"] as ProductCart;
                cart.DecreaseCart(id);
                Session["sepet"] = cart;
            }
            return Json("");
        }

        public JsonResult RemoveCart(Guid id)
        {

            ProductCart cart = Session["sepet"] as ProductCart;
            cart.RemoveCart(id);
            Session["sepet"] = cart;
            return Json("");
        }
    }
}