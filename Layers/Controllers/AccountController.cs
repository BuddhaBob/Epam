using LayersDLL.BL;
using LayersDLL.Validation;
using LayersDAL.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using LayersDAL.Entity;

namespace Layers.Controllers
{
    public class AccountController : Controller
    {
        public static int UserId;
        

        public ActionResult Index()
        {
            /*            return email;
            */
            if (UserId == null)
            {
                /*SiteContext db = new SiteContext();
                string cookieName = FormsAuthentication.FormsCookieName; //Find cookie name
                HttpCookie authCookie = HttpContext.Request.Cookies[cookieName]; //Get the cookie by it's name
                FormsAuthenticationTicket ticket = FormsAuthentication.Decrypt(authCookie.Value); //Decrypt it
                string UserName = ticket.Name; //You have the UserName!
                var userId = db.Users.Where(u => u.Nickname == UserName).SingleOrDefault()?.UserId;
                HttpContext.Response.Cookies["id"].Value = userId.ToString();*/
                Session.Add("UserId", UserId);

                return RedirectToAction("MainPage", "Notes");
            }

            return RedirectToAction("Login", "Account");

        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                // поиск пользователя в бд
                User user = null;
                using (SiteContext db = new SiteContext())
                {
                    user = db.Users.FirstOrDefault(u => u.Email == model.Email && u.Password == model.Password);

                }
                if (user != null)
                {
                    FormsAuthentication.SetAuthCookie(model.Email, true);
                    SiteContext db = new SiteContext();
                    UserId = db.Users.Where(u => u.Email == model.Email).SingleOrDefault().UserId;
                    Session.Add("UserId", UserId);
                    return RedirectToAction("MainPage", "Notes");
                }
                else
                {
                    ModelState.AddModelError("", "User with such login is doesn't exist");
                }
            }

            return View(model);
        }

        public ActionResult Register()
        {
           

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                User user = null;
                using (SiteContext db = new SiteContext())
                {
                    user = db.Users.FirstOrDefault(u => u.Email == model.Email || u.Nickname == model.Nickname);
                }
                if (user == null)
                {

                    // создаем нового пользователя
                    using (SiteContext db = new SiteContext())
                    {
                        db.Users.Add(new User { Email = model.Email, Password = model.Password, Nickname = model.Nickname });
                        db.SaveChanges();

                        user = db.Users.Where(u => u.Email == model.Email && u.Password == model.Password).FirstOrDefault();
                    }
                    // если пользователь удачно добавлен в бд
                    if (user != null)
                    {
                        FormsAuthentication.SetAuthCookie(model.Email, true);
                        return RedirectToAction("MainPage", "Notes");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "User with same login/email is already exist");
                }
            }

            return View(model);
        }

        public ActionResult Logoff()
        {
          
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "Account");
        }
    }
}