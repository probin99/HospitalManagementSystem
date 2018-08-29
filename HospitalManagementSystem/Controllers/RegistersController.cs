using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HospitalManagementSystem.Context;
using HospitalManagementSystem.Models.UserAccount;

namespace HospitalManagementSystem.Controllers
{
    public class RegistersController : Controller
    {
        private HospitalManagementSystemContext db = new HospitalManagementSystemContext();
        
        [HttpGet]
        //Get: View Register Page
        public ActionResult Index()
        {
            return View();
        }
        
        [HttpPost]
        
        public ActionResult Index([Bind(Include ="FullName,Email,Password,ConfirmPassword,Role")] User model)
        {
            if (ModelState.IsValid)
            {
                User register = new User()
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Email = model.Email,
                    Password = model.Password,
                    ConfirmPassword = model.ConfirmPassword,
                    Role = model.Role
                };

                var query = db.Users.Where(x => x.Email.Contains(model.Email)).Select(x => x);
                if (query.Count() == 0)
                {
                    db.Users.Add(register);
                    db.SaveChanges();

                    string selectedRole = model.Role.ToString();
                    //switch (selectedRole)
                    //{
                    //    case "Patient":
                    //        Patient patient = new Patient()
                    //        {
                    //            Email = model.Email,
                    //            Password = model.Password,
                    //            Role = model.Role
                    //        };
                    //        db.Patients.Add(patient);
                    //        db.SaveChanges();
                    //        return RedirectToAction("Index", "Patients");

                    //    case "Doctor":
                    //        Doctor doctor = new Doctor()
                    //        {
                    //            Email = model.Email,
                    //            Password = model.Password,
                    //            Role = model.Role
                    //        };
                    //        db.Doctors.Add(doctor);
                    //        db.SaveChanges();
                    //        return RedirectToAction("Index", "Doctors");

                    //    case "Pharmacist":
                    //        Pharmacist pharmacist = new Pharmacist()
                    //        {
                    //            Email = model.Email,
                    //            Password = model.Password,
                    //            Role = model.Role
                    //        };
                    //        db.Pharmacists.Add(pharmacist);
                    //        db.SaveChanges();
                    //        return RedirectToAction("Index", "Pharmacists");

                    //    case "Admin":
                    //        Admin admin = new Admin()
                    //        {
                    //            Email = model.Email,
                    //            Password = model.Password,
                    //            Role = model.Role
                    //        };
                    //        db.Admins.Add(admin);
                    //        db.SaveChanges();
                    //        return RedirectToAction("Index", "Admins");
                    //}
                    return RedirectToAction("Index", "Logins");
                }
                else
                {
                    return View(model);
                }
            }
            else
            {
                return View(model);
            }
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
