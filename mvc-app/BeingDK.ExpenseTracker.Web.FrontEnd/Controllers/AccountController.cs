using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using BeingDK.ExpenseTracker.Data;
using BeingDK.ExpenseTracker.Web.FrontEnd.Models;

namespace BeingDK.ExpenseTracker.Web.FrontEnd.Controllers
{
    public class AccountController : Controller
    {
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel model, string returnUrl)
        {
            if (!ModelState.IsValid)
            {
                return View(nameof(AccountController.Login), model);
            }

            if (model.TryAuthenticate(out User user))
            {
                SetupLoginCookie(model, user);

                if (Url.IsLocalUrl(returnUrl))
                {
                    return Redirect(returnUrl);
                }
                return RedirectToAction("Index", "Dashboard");
            }

            ModelState.AddModelError("", "Incorrect email/password");

            return View(nameof(AccountController.Login), model);
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [Route(nameof(Logout))]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToRoute("Home");
        }

        private void SetupLoginCookie(LoginViewModel model, User user)
        {
            var issueDate = DateTime.Now;
            var expireAt = model.RememberMe ? issueDate.AddDays(30) : issueDate.AddMinutes(20);
            var sessionToken = Guid.NewGuid();

            var ticket = new FormsAuthenticationTicket(
                1 /*version*/,
                model.UserName,
                issueDate,
                expireAt,
                model.RememberMe,
                user.Id.ToString(),
                FormsAuthentication.FormsCookiePath);

            var encryptedTicket = FormsAuthentication.Encrypt(ticket);

            var cookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket)
            {
                HttpOnly = true
            };

            if (ticket.IsPersistent)
            {
                cookie.Expires = ticket.Expiration;
            }
            //cookie.Secure = FormsAuthentication.RequireSSL;
            cookie.Path = FormsAuthentication.FormsCookiePath;
            if (FormsAuthentication.CookieDomain != null)
            {
                cookie.Domain = FormsAuthentication.CookieDomain;
            }
            Response.SetCookie(cookie);
        }
    }
}