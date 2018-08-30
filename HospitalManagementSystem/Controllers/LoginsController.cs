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
        private HospitalManagementSystemContext db = new HospitalManagementSystemContext();
        [HttpGet]
        // GET: Logins
        public ActionResult Login()
        {
            ViewBag.RoleID = new SelectList(db.Roles, "RoleID", "RoleName");
            LoginViewModel model = new LoginViewModel();
            return View(model);
        }

        [HttpPost]
        // GET: Logins
        public ActionResult Login([Bind(Include = "Email,Password, RoleID")]LoginViewModel user)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }

            ViewBag.RoleID = new SelectList(db.Roles, "RoleID", "RoleName", user.RoleID);
            return View(user);
        }
    }
}