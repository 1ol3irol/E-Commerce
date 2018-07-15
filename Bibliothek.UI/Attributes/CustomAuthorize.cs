using Bibliothek.DAL.Context;
using Bibliothek.Model.Entity;
using Bibliothek.Service.Option;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Bibliothek.UI.Attributes
{
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class, Inherited = true, AllowMultiple = false)]
    public class CustomAuthorize : AuthorizeAttribute
    {
        private string[] UserProfilesRequired { get; set; }

        public CustomAuthorize(params object[] userProfilesRequired)
        {
            if (userProfilesRequired.Any(p => p.GetType().BaseType != typeof(Enum)))
                throw new ArgumentException("userProfilesRequired");
            this.UserProfilesRequired = userProfilesRequired.Select(p => Enum.GetName(p.GetType(), p)).ToArray();

        }

        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            bool authorized = false;

            if (HttpContext.Current.Session["role"] == null)
            {
                AppUserService service = new AppUserService();
                AppUser dbUser = service.FindByUserName(HttpContext.Current.User.Identity.Name);
                HttpContext.Current.Session["role"] = dbUser;
            }

            var user = HttpContext.Current.Session["role"] as AppUser;
            string userRole = Enum.GetName(typeof(Role), user.Role);

            foreach (var role in this.UserProfilesRequired)
            {
                if (userRole == role)
                {
                    authorized = true;
                    break;
                }
            }

            if (!authorized)
            {
                var url = new UrlHelper(filterContext.RequestContext);
                var logonUrl = url.Action("NotAuthorized", "Account", new { Id = 302, Area = "Admin" });
                filterContext.Result = new RedirectResult(logonUrl);

                return;
            }
        }
    }
}