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
        [HttpGet]
        // GET: Registers
        public ActionResult Register()
        {
            RegisterViewModel registerVM = new RegisterViewModel();
            return View(registerVM);
        }

        [HttpPost]
        // Post: Registers
        public ActionResult Register([Bind(Include ="FirstName,LastName,Email,MobileNumber,UserName,Password,")] RegisterViewModel account)
        {
            if (ModelState.IsValid)
            {
                using (HospitalManagementSystemContext db = new HospitalManagementSystemContext())
                {
                    var registertedUser = db.Users.Single(x => x.Email == account.Email);
                    if(registertedUser == null)
                    {
                        UserAccount newUser = new UserAccount()
                        {
                            FirstName = account.FirstName,
                            LastName = account.LastName,
                            Email = account.Email,
                            MobileNumber = account.MobileNumber,
                            UserName = account.UserName,
                            Password = account.Password
                        };
                        db.Users.Add(newUser);
                        db.SaveChanges();
                        //Redirect to login page
                        ViewBag["RegisteredUser"] = "Congratulations " + account.FirstName + ", you are registered with Email: " + account.Email;
                        ViewBag["EmailAreadyRegistered"] = null;
                        return RedirectToAction("Login","Logins");
                    }
                    else
                    {
                        ViewBag["EmailAreadyRegistered"] = "Sorry, " + account.Email + " is already registered";
                        ViewBag["RegisteredUser"] = null;
                        return View(account);
                    }
                }
            }
            else
            {
                return View(account);
            }

        }
    }
}