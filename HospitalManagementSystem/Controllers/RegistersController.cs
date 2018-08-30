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
    public class RegistersController : Controller
    {
        HospitalManagementSystemContext db = new HospitalManagementSystemContext();
        [HttpGet]
        // GET: Registers
        public ActionResult Register()
        {
            RegisterViewModel registerVM = new RegisterViewModel();

            return View(registerVM);
        }

        [HttpPost]
        // Post: Registers
        public ActionResult Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                User register = new User()
                {
                    FirstName = model.User.FirstName,
                    LastName = model.User.LastName,
                    Email = model.User.Email,
                    Password = model.User.Password,
                    Role = model.User.Role
                };

                var query = db.Users.Where(x => x.Email.Contains(model.User.Email)).Select(x => x);
                if (query.Count() == 0)
                {
                    db.Users.Add(register);
                    db.SaveChanges();

                    string selectedRole = model.User.Role.ToString();
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
                    return RedirectToAction("Login", "Logins");
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