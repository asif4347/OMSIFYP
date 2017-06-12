using OMSIFYP.DAL;
using OMSIFYP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace OMSIFYP.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        private SchoolContext db=new SchoolContext();
        public string Name;
        public string Email; 
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost,ActionName("Login")]
        public ActionResult LoginConfirm(Login log) {
            //  var pers = from m in db.People select m;

            //   Person per = db.People.Find(log.id);
            Person per = db.People.FirstOrDefault(i => i.email == log.email);
            if (per != null)
            {
                if (per.password == log.password)
                {
                    UserInfo uInfo = new UserInfo();
                    uInfo.ID = per.ID;
                    uInfo.firstName = per.FirstMidName;
                    uInfo.LastName = uInfo.LastName;
                    uInfo.Email = per.email;
                    uInfo.imgUrl = per.imgUrl;
                    if (per.Role == "Student")
                    {
                        Student st = (Student)per;
                        return RedirectToAction("Details", "Login", new { id = st.ID });
                    }
                    else if (per.Role == "Instructor")
                    {
                        Instructor ins = (Instructor)per;
                        return RedirectToAction("Details_Ins", "Login", new { id = ins.ID });
                    }
                    else if (per.Role == "Admin")
                    {
                        return RedirectToAction("About", "Home");
                    }
                    else if (per.Role == "SuperAdmin")
                    {
                        return RedirectToAction("Index","SuperAdmin");
                    }
                   
                }
                else
                {
                    ViewBag.loginMessage = "Password Incorrect!";
                }

            }
           else {
                ViewBag.loginMessage = "User Not Found!";
            }


            return View();
        }
        public ActionResult resetPassword(Student std)
        {
            
            return View(std);
        }
        [HttpPost,ActionName("resetPassword")]
        public ActionResult resetPasswordConfirm(Student std)
        {
            std.logCont = 1;
            db.Entry(std).State = System.Data.Entity.EntityState.Modified;
            
            db.SaveChanges();
            return View();
        }
        public string returnName()
        {
            return Name;
        }
        public string returnEmail()
        {
            return Email;
        }
        //Student Details
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = db.Students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }
        public ActionResult DetailsParent(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = db.Students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }
        //Instructor Details
        public ActionResult Details_Ins(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Instructor ins = db.Instructors.Find(id);
            if (ins == null)
            {
                return HttpNotFound();
            }
            return View(ins);
        }
    }
}