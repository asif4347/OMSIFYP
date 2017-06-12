using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using OMSIFYP.DAL;
using OMSIFYP.Models;

namespace OMSIFYP.Controllers
{
    public class SectionsController : Controller
    {
        private SchoolContext db = new SchoolContext();

        // GET: Sections
        public ActionResult Index()
        {
            return View(db.Sections.ToList());
        }

        // GET: Sections/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Section section = db.Sections.Find(id);
            if (section == null)
            {
                return HttpNotFound();
            }
            return View(section);
        }

        // GET: Sections/Create
        public ActionResult Create()
        {
            var courselst = new List<string>();
            var courseQry = from d in db.Courses
                            orderby d.Title
                            select d.Title;

            courselst.AddRange(courseQry.Distinct());
            ViewBag.course = new SelectList(courselst);

            var instlst = new List<string>();
            var instQry = from d in db.Instructors
                            orderby d.FirstMidName
                            select d.FirstMidName;

            instlst.AddRange(instQry.Distinct());
            ViewBag.instructor = new SelectList(instlst);

            return View();
        }

        // POST: Sections/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(string section,string course,string instructor)
        {
            Section sect = new Section();
            sect.sec = section;
            sect.cour = course;
            sect.ins = instructor;
            if (ModelState.IsValid) {
                db.Sections.Add(sect);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(sect);
           
           
        }

        // GET: Sections/Edit/5
      

        // POST: Sections/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
       

        // GET: Sections/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Section section = db.Sections.Find(id);
            if (section == null)
            {
                return HttpNotFound();
            }
            return View(section);
        }

        // POST: Sections/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Section section = db.Sections.Find(id);
            db.Sections.Remove(section);
            db.SaveChanges();
            return RedirectToAction("Index");
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
