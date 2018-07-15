using Bibliothek.Model.Entity;
using Bibliothek.Service.Option;
using Bibliothek.UI.Areas.Admin.Models.DTO;
using Bibliothek.UI.Areas.Admin.Models.VM;
using Bibliothek.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Bibliothek.UI.Areas.Admin.Controllers
{
    [Authorize]
    public class ProductController : Controller
    {
        ProductService _productService;
        CategoryService _categoryService;
        

        public ProductController()
        {
            _productService = new ProductService();
            _categoryService = new CategoryService();
        }
        

        public ActionResult List()
        {
            List<Product> model = _productService.GetActive();
            return View(model);
        }
        

        public ActionResult Add()
        {
            List<Category> model = _categoryService.GetActive();
            return View(model);
        }

        [HttpPost]
        public ActionResult Add(Product data, HttpPostedFileBase Image)
        {
            data.ImagePath = ImageUploader.UploadSingleImage("/Uploads/", Image);

            if (data.ImagePath == "0" || data.ImagePath == "1" || data.ImagePath == "2")
                data.ImagePath = "/Content/Images/Web/Home/product.jpg";

            _productService.Add(data);

            return Redirect("/Admin/Product/List");
        }
        

        public ActionResult Update(Guid id)
        {
            ProductUpdateVM model = new ProductUpdateVM();

            Product product = _productService.GetByID(id);
            model.Product.Name = product.Name;
            model.Product.ID = product.ID;
            model.Product.UnitsInStock = product.UnitsInStock;
            model.Product.Quantity = product.Quantity;
            model.Product.Price = product.Price;
            model.Product.ImagePath = product.ImagePath;
            model.Product.Director = product.Director;
            model.Product.Star = product.Star;
            model.Product.Artist = product.Artist;
            model.Product.TradeMark = product.TradeMark;

            model.Categories = _categoryService.GetActive();

            return View(model);
        }

        [HttpPost]
        public ActionResult Update(ProductDTO data, HttpPostedFileBase Image)
        {
            data.ImagePath = ImageUploader.UploadSingleImage("~/Uploads/", Image);

            Product product = _productService.GetByID(data.ID);

            if (data.ImagePath == "0" || data.ImagePath == "1" || data.ImagePath == "2")
            {
                if (product.ImagePath == null || product.ImagePath == "/Content/Images/Web/Home/product.jpg")
                {
                    product.ImagePath = "~/Content/Images/Web/Home/product.jpg";
                }
            }
            else
            {
                product.ImagePath = data.ImagePath;
            }

            product.Name = data.Name;
            product.Price = data.Price;
            product.UnitsInStock = data.UnitsInStock;
            product.Quantity = data.Quantity;
            product.CategoryID = data.CategoryID;
            product.Director = data.Director;
            product.Artist = data.Artist;
            product.Star = data.Star;
            product.TradeMark = data.TradeMark;

            _productService.Update(product);

            return Redirect("/Admin/Product/List");
        }
        

        public RedirectResult Delete(Guid id)
        {
            _productService.Remove(id);
            return Redirect("/Admin/Product/List");
        }
    }
}