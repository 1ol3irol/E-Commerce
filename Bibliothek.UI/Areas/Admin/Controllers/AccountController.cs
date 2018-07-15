using Bibliothek.DAL.Context;
using Bibliothek.UI.Areas.Admin.Models.VM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Bibliothek.UI.Areas.Admin.Controllers
{
    public class AccountController : Controller
    {

        public ActionResult Login()
        {

            if (User.Identity.IsAuthenticated)
            {

                return RedirectToAction("Index", "Home");
            }

            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Login(LoginVM data)
        {
            if (ModelState.IsValid)
            {
                using (ProjectContext db = new ProjectContext())
                {
                    var user = db.Users.FirstOrDefault(x => x.Username == data.Username && x.Password == data.Password);

                    if (user != null)
                    {
                        Session["role"] = user;
                        FormsAuthentication.SetAuthCookie(user.Username, true);

                        return RedirectToAction("Index", "Home");
                    }

                    else
                    {
                        ModelState.AddModelError("", "Kullanıcı adı veya şifre hatalı!");
                    }
                }
            }

            return View(data);
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "Account", new { Area = "Admin" });
        }

        public ActionResult NotAuthorized()
        {
            return View();
        }
    }
}