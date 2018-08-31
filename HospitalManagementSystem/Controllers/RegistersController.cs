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
                    var registertedUser = db.Users.Single(x => x.Email == account.User.Email);
                    if(registertedUser == null)
                    {
                        UserAccount newUser = new UserAccount()
                        {
                            FirstName = account.User.FirstName,
                            LastName = account.User.LastName,
                            Email = account.User.Email,
                            MobileNumber = account.User.MobileNumber,
                            UserName = account.User.UserName,
                            Password = account.User.Password
                        };
                        db.Users.Add(newUser);
                        db.SaveChanges();
                        //Redirect to login page
                        ViewBag["RegisteredUser"] = "Congratulations " + account.User.FirstName + ", you are registered with Email: " + account.User.Email;
                        ViewBag["EmailAreadyRegistered"] = null;
                        return RedirectToAction("Login","Logins");
                    }
                    else
                    {
                        ViewBag["EmailAreadyRegistered"] = "Sorry, " + account.User.Email + " is already registered";
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