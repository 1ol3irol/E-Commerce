using Bibliothek.Model.Entity;
using Bibliothek.Service.Option;
using Bibliothek.UI.Areas.Web.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Bibliothek.UI.Areas.Web.Controllers
{
    public class UserController : Controller
    {
        CustomerService _customerService;
        public UserController()
        {
            _customerService = new CustomerService();
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Update(Guid id)
        {
            Customer user = _customerService.GetByID(id);
            UserDTO model = new UserDTO();
            model.ID = user.ID;
            model.Name = user.Name;
            model.LastName = user.LastName;
            model.Password = user.Password;
            model.Address = user.Address;
            model.Phone = user.Phone;
            return View(model);
        }

        [HttpPost]
        public ActionResult Update(UserDTO data)
        {
            Customer user = _customerService.GetByID(data.ID);

            user.Name = data.Name;
            user.LastName = data.LastName;
            user.Address = data.Address;
            user.Password = data.Password;
            user.Phone = data.Phone;

            _customerService.Update(user);

            return Redirect("/Web/Home/Index");
        }
    }
}