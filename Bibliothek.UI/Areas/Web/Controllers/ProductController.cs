using Bibliothek.DAL.Context;
using Bibliothek.Model.Entity;
using Bibliothek.Service.Option;
using Bibliothek.UI.Areas.Web.Models.VM;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Bibliothek.UI.Areas.Web.Controllers
{
    public class ProductController : Controller
    {
     
        ProductService _productService;
        CommentService _commentService;
        public ProductController()
        {
            _productService = new ProductService();
            _commentService = new CommentService();
        }

        public ActionResult Index(Guid id, int page = 1)
        {
            if (id == null)
            {
                return RedirectToAction("Index", "Home");
            }

            List<Product> productList = _productService.GetActive().Where(x => x.Category.ID == id).ToList();
           
            return View(productList.ToPagedList(page, 6));
        }
    
        public ActionResult ProductDetails(Guid id /*int? id*/)
        {
            if (id != null)
            {
                Product model = _productService.GetByID(id);
                return View(model);
            }

            else
                //return Redirect("/Web/Home/Index");
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        }

        public ActionResult AddComment(CommentVM data)
        {
            Comment comment = new Comment();
            comment.ProductID = data.ID;
            comment.Content = data.Content;
            comment.Header = data.Header;
            comment.CreatedDate = DateTime.Now;
            _commentService.Add(comment);
            return Redirect("/Web/Product/ProductDetails/" + data.ID);
        }
    }
}