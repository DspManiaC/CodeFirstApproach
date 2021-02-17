using CodeFirstApproach.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CodeFirstApproach.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        private StudentDbContext db = new StudentDbContext();
        public ActionResult Index()
        {

            return View(db.Users.ToList());
        }

        public ActionResult Register()
        {
            return View();
        }

        public ActionResult RegisterByPost(Users users)
        {
            if (ModelState.IsValid)
            {
                db.Users.Add(users);
                db.SaveChanges();
            }

            return RedirectToAction("Index", "User");
        }

        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Users users)
        {
            if (ModelState.IsValid)
            {
                var userData = db.Users.FirstOrDefault(e => e.UserName.Equals(users.UserName) && e.Password.Equals(users.Password));
                if (userData != null)
                {
                    Session["UserName"] = userData.UserName;
                    Session["UserId"] = userData.UserId;
                    return RedirectToAction("Index", "student");
                }
            }
            return RedirectToAction("Login");
        }

        public ActionResult LogOut()
        {
            Session.Abandon();
            return RedirectToAction("Login");
        }
    }
}
