using HospitalManagementSystem.Context;
using HospitalManagementSystem.Models.UserAccount;
using HospitalManagementSystem.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HospitalManagementSystem.Controllers
{
    public class LoginsController : Controller
    {
        [HttpGet]
        // GET: Logins
        public ActionResult Login()
        {
            LoginViewModel model = new LoginViewModel();
            return View(model);
        }

        [HttpPost]
        // GET: Logins
        public ActionResult Login([Bind(Include = "UserName,Password")]LoginViewModel user)
        {
            if (ModelState.IsValid)
            {
                using (HospitalManagementSystemContext db = new HospitalManagementSystemContext())
                {
                    var getUserFromDatabase = db.Users.Single(x => x.UserName == user.UserName && x.Password == user.Password);
                    if (getUserFromDatabase != null)
                    {
                        Session["UserFound"] = user.UserName;
                        return RedirectToAction("LoggedUser");
                    }
                    else
                    {
                        ViewBag.UserNotFound = user.UserName + ""+ "is not registered in the system";
                        return View(user);
                    }
                }
            }
            return View(user);
        }
    }
}