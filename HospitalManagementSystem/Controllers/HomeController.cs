using HospitalManagementSystem.Context;
using HospitalManagementSystem.Models.Home;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HospitalManagementSystem.Controllers
{
    public class HomeController : Controller
    {
        HospitalManagementSystemContext db = new HospitalManagementSystemContext();
        // GET: Home
        public ActionResult Welcome()
        {
            //ViewBag.Doctors = db.Registers.Where(x=>x.Role.ToString() == "Doctor").Select(x => x).Count();
            //ViewBag.Patients = db.Registers.Where(x => x.Role.ToString() == "Patient").Select(x => x).Count();
            //ViewBag.Pharmacists = db.Registers.Where(x => x.Role.ToString() == "Pharmacist").Select (x=>x).Count();
            return View();
        }
        
        public ActionResult About()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Contact()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Contact([Bind(Include ="Name,Email,Telephone,Message")] ContactUs model)
        {
            if (ModelState.IsValid && model != null)
            {
                ContactUs contact = new ContactUs()
                {
                    Name = model.Name,
                    Email = model.Email,
                    Telephone = model.Telephone,
                    Message = model.Message
                };

                db.ContactUs.Add(contact);
                db.SaveChanges();
                
                return RedirectToAction("Welcome", "Home");
            }
            else
            {
                return View(model);
            }
        }
    }
}