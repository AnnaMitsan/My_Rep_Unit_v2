using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Rep_Unit2.Models;
using Rep_Unit2.DAL;
using PagedList;


namespace Rep_Unit2.Controllers
{
    public class EnrollmentController : Controller
    {
        private SchoolContext schoolcontext;

        // GET: /Course/Create

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(
            [Bind(Include = "EnrollmentID,CourseID,StudentID,Grade,DepartmentID")]
         Enrollment enrollment)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    schoolcontext.Enrollments.Add(enrollment);
                    schoolcontext.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (DataException /* dex */)
            {
                //Log the error (uncomment dex variable name after DataException and add a line here to write a log.)
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists, see your system administrator.");
            }
            return View(enrollment);
        }

        public ActionResult Edit(int id)
        {
            Enrollment enrollment = schoolcontext.Enrollments.ElementAt(id);     
            return View(enrollment);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(
             [Bind(Include = "EnrollmentID,CourseID,StudentID,Grade,DepartmentID")]
         Enrollment enrollment)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    schoolcontext.Enrollments.Add(enrollment);
                    schoolcontext.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (DataException /* dex */)
            {
                //Log the error (uncomment dex variable name after DataException and add a line here to write a log.)
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists, see your system administrator.");
            }
        
            return View(enrollment);
        }


        public ActionResult Delete(int id)
        {
            Enrollment enrollment = schoolcontext.Enrollments.ElementAt(id);
            return View(enrollment);
        }

        //
        // POST: /Course/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Enrollment enrollment = schoolcontext.Enrollments.ElementAt(id);
            schoolcontext.Enrollments.Remove(enrollment);
            schoolcontext.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}