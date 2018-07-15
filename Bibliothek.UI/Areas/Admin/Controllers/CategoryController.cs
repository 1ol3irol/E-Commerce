using Bibliothek.Model.Entity;
using Bibliothek.Service.Option;
using Bibliothek.UI.Areas.Admin.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Bibliothek.UI.Areas.Admin.Controllers
{
    [Authorize]
    public class CategoryController : Controller
    {
        CategoryService _categoryService;

        public CategoryController()
        {
            _categoryService = new CategoryService();
        }

        public ActionResult List()
        {
            List<Category> model = _categoryService.GetActive();
            return View(model);
        }

        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(Category data)
        {
            _categoryService.Add(data);
            return Redirect("/Admin/Category/List");
        }

        public ActionResult Update(Guid id)
        {
            Category cat = _categoryService.GetByID(id);
            CategoryDTO model = new CategoryDTO();
            model.ID = cat.ID;
            model.Name = cat.Name;
            return View(model);
        }

        [HttpPost]
        public ActionResult Update(CategoryDTO data)
        {
            Category cat = _categoryService.GetByID(data.ID);
            cat.Name = data.Name;
            _categoryService.Update(cat);
            return Redirect("/Admin/Category/List");
        }

        public ActionResult Delete(Guid id)
        {
            _categoryService.Remove(id);
            return Redirect("/Admin/Category/List");
        }
    }
}