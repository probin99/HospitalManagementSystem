using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HospitalManagementSystem.Context;
using HospitalManagementSystem.Models.UserAccount;

namespace HospitalManagementSystem.Controllers
{
    public class LoginsController : Controller
    {


        //public ActionResult Login([Bind(Include = "Email,Password,Role")] Login model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        Register login = new Register()
        //        {
        //            Email = model.Email,
        //            Password = model.Password,
        //            Role = model.Role
        //        };

        //        var query = db.Registers.Where(x => x.Email == (login.Email) && x.Role == (login.Role) && x.Password == (login.Password)).Select(x => x);
        //        if (query.Count() == 1)
        //        {
        //            //Handle page as per user role
        //            switch (login.Role.ToString())
        //            {
        //                case "Patient":
        //                    return RedirectToAction("Index", "Patients");

        //                case "Doctor":
        //                    return RedirectToAction("Index", "Doctors");

        //                case "Pharmacist":
        //                    return RedirectToAction("Index", "Pharmacists");

        //                case "Admin":
        //                    return RedirectToAction("Index", "Admins");
        //            }
        //        }
        //        else
        //        {
        //            return View(model);
        //        }
        //    }
        //    return View(model);
        //}

        private HospitalManagementSystemContext db = new HospitalManagementSystemContext();

        // GET: Logins
        
        // GET: Logins/Create
        public ActionResult Index()
        {
            ViewBag.RoleID = new SelectList(db.Roles, "RoleID", "RoleName");
            return View();
        }

        // POST: Logins/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index([Bind(Include = "UserID,FirstName,LastName,Email,MobileNumber,Password,RoleID")] User user)
        {
            if (ModelState.IsValid)
            {
                db.Users.Add(user);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.RoleID = new SelectList(db.Roles, "RoleID", "RoleName", user.RoleID);
            return View(user);
        }
        
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
