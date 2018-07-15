using Bibliothek.Model.Entity;
using Bibliothek.Service.Option;
using Bibliothek.UI.Areas.Admin.Models.DTO;
using Bibliothek.UI.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Bibliothek.UI.Areas.Admin.Controllers
{
    [CustomAuthorize(Role.Admin)]
    public class AppUserController : Controller
    {
        AppUserService _appUserService;

        public AppUserController()
        {
            _appUserService = new AppUserService();
        }

        public ActionResult List()
        {
            List<AppUser> model = _appUserService.GetActive();
            return View(model);
        }

        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(AppUser data)
        {
            _appUserService.Add(data);
            return Redirect("/Admin/AppUser/List");
        }

        public ActionResult Update(Guid id)
        {
            AppUser user = _appUserService.GetByID(id);
            AppUserDTO model = new AppUserDTO();
            model.ID = user.ID;
            model.Name = user.Name;
            model.LastName = user.LastName;
            model.Username = user.Username;
            model.Password = user.Password;
            model.Role = user.Role;
            return View(model);
        }

        [HttpPost]
        public ActionResult Update(AppUserDTO data)
        {
            AppUser user = _appUserService.GetByID(data.ID);

            user.Name = data.Name;
            user.LastName = data.LastName;
            user.Username = data.Username;
            user.Password = data.Password;
            user.Role = data.Role;

            _appUserService.Update(user);

            return Redirect("/Admin/AppUser/List");
        }

        public RedirectResult Delete(Guid id)
        {
            _appUserService.Remove(id);
            return Redirect("/Admin/AppUser/List");
        }
    }
}