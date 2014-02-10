using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Smatrves.Models;
using Smatrves.Models.Helpers;

namespace Smatrves.Controllers
{
    public class HomeController : Controller
    {
        private DataContext db = new DataContext();
        //Главная страница
        // GET: /Home/
        public ActionResult Index()
        {
            if (db.Admins.Count() == 0)
            {
                db.Admins.Add(new Admin() { Name = "Прохоров Евгений", Email = "evgwed@gmail.com", Login = "evgwed", Password = "123" });
                db.SaveChanges();
            }
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(User usr)
        {
            User tmp_usr = db.Users.FirstOrDefault(m => m.Password == usr.Password&&m.Login == usr.Login);
            if (tmp_usr != null)
            {
                UserHelper.SetUser(Session, tmp_usr);
            }
            if (UserHelper.IsOpen(Session, "Client"))
            {
                return RedirectToAction("Index", "Profile");
            }
            else
            {
                return HttpNotFound();
            }
        }
        public ActionResult Registration()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Registration(Client client)
        {
            client.DateLastEnter = DateTime.Now;
            client.Accbalance = 0;
            client.Acctype = TypeAccount.Newcomer;
            client.Accupgrade = UpgradeType.Basic;
            client.Crbalance = 0;
            client.Rating = 0;
            client.Regdate = DateTime.Today;
            client.Status = StatusClient.Open;
            client.Userip = UserHelper.GetUserIp(Request);
            db.Clients.Add(client);
            db.SaveChanges();
            return RedirectToAction("Index", "Home");
        }
        public ActionResult LoginApp(string l = null, string p = null, int r = 0)
        {
            User tmp_usr = db.Users.FirstOrDefault(m => m.Password == p && m.Login == l);
            if (tmp_usr != null)
            {
                UserHelper.SetUser(Session, tmp_usr);
            }
            else
            {
                UserHelper.SetUser(Session, null);
            }
            if (UserHelper.GetUser(Session) != null)
            {
                ViewData["ReturnText"] = "ok||" + UserHelper.GetUser(Session).IdUser.ToString();
            }
            else
            {
                ViewData["ReturnText"] = "no||1";
            }
            return View();
        }
    }
}
