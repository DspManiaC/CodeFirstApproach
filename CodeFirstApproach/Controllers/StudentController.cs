using CodeFirstApproach.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CodeFirstApproach.Controllers
{
    public class StudentController : Controller
    {
        StudentDbContext db = new StudentDbContext();
        // GET: Student
        public ActionResult Index()
        {
            if(Session["UserName"]!= null)
            {
                var data = db.Students.ToList();
                return View(data);
            }
            else
            {
                return RedirectToAction("Login", "user");
            }
            
        }
        public ActionResult Create()
        {
            return View();
        }
        public ActionResult CreateByPost(Student student)
        {
            if(ModelState.IsValid)
            {
                db.Students.Add(student);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            var stud=db.Students.FirstOrDefault(a => a.Id == id);
            return View(stud);
        }

        public ActionResult EditByPost(Student student)
        {
            if(ModelState.IsValid)
            {
                db.Entry(student).State = EntityState.Modified;
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            var studentEntity = db.Students.FirstOrDefault(e => e.Id == id);
            db.Entry(studentEntity).State = EntityState.Deleted;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {
            var stud = db.Students.FirstOrDefault(a => a.Id == id);
            return View(stud);
        }
    }
}