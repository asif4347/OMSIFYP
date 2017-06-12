using OMSIFYP.DAL;
using OMSIFYP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OMSIFYP.ViewModels;
using System.Data.Entity;

namespace OMSIFYP.Controllers
{
    public class SuperAdminController : Controller
    {
        private SchoolContext db = new SchoolContext();
        // GET: SuperAdmin
        public ActionResult Index()
        {
            var viewModel = new AdminData();
            viewModel.Admins = db.Admin;
            return View(viewModel);
        }
        public ActionResult CreateAdmin()
        {
           
            return View();
        }
        [HttpPost]
        public ActionResult CreateAdmin(Admin ad)
        {
            if (ModelState.IsValid) {
                ad.logCont = 0;
                ad.Role = "Admin";
                db.Admin.Add(ad);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
           
            return View();
        }

        public ActionResult Edit(int? id)
        {
            Admin ad = db.Admin.Find(id);
            if (ad == null)
            {
                return HttpNotFound();
            }
            return View(ad);
        }
        [HttpPost]
        public ActionResult Edit(Admin ad)
        {
            if (ModelState.IsValid)
            {
               
                db.Entry(ad).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View();
        }
        public ActionResult Delete(int? id)
        {
            Admin ad = db.Admin.Find(id);
            if (ad == null)
            {
                return HttpNotFound();
            }
            db.Admin.Remove(ad);
            db.SaveChanges();
            ViewBag.delete = "Admin Deleted Sucessfully!";
            return RedirectToAction("Index");
        }
    }
}