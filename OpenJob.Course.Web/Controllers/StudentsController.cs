using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using OpenJob.Course.DbCourse.Entities;
using OpenJob.Course.Web.Models;

namespace OpenJob.Course.Web.Controllers
{
    public class StudentsController : Controller
    {
        private DbCourseCtx db = new DbCourseCtx();

        public StudentsController()
        {//<== Put a breakpoint here to understand how does it works!
            //Inizialize Log here!
        }

        // GET: Students
        public async Task<ActionResult> Index()
        {
            var result = await Student.GetAll(db);
            return View(
                result.Select(x=> new StudentViewModels() {
                    IdStudent = x.IdStudent,
                    Username =x.Username,
                    Name = x.Name,
                    SurName = x.SurName
                }).ToList());
        }

        // GET: Students/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var students = await Student.GetAll(db);
            StudentViewModels studentViewModels = students.Where(
                x=> x.IdStudent == id)
                .Select(x=>new StudentViewModels() {
                    IdStudent = x.IdStudent,
                    Username = x.Username,
                    Name = x.Name,
                    SurName = x.SurName })
                .FirstOrDefault();

            if (studentViewModels == null)
            {
                return HttpNotFound();
            }
            return View(studentViewModels);
        }

        // GET: Students/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Students/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "IdStudent,Username,Name,SurName")] StudentViewModels studentViewModels)
        {
            if (ModelState.IsValid)
            {
                db.Students.Add(
                    new Student {
                        StudentName = studentViewModels.Name,
                        StudentSurname = studentViewModels.SurName,
                        StudentUsername = studentViewModels.Username
                    });

                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(studentViewModels);
        }

        // GET: Students/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var students = await Student.GetAll(db);
            StudentViewModels studentViewModels = students.Where(x => x.IdStudent == id).Select(x => new StudentViewModels() { IdStudent = x.IdStudent, Name = x.Name, SurName = x.SurName }).FirstOrDefault();
            if (studentViewModels == null)
            {
                return HttpNotFound();
            }
            return View(studentViewModels);
        }

        // POST: Students/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "IdStudent,Username,Name,SurName")] StudentViewModels studentViewModels)
        {
            if (ModelState.IsValid)
            {
                var entity = await db.Students.FindAsync(studentViewModels.IdStudent);
                entity.StudentName = studentViewModels.Name;
                entity.StudentSurname= studentViewModels.SurName;
                db.Entry(entity).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(studentViewModels);
        }

        // GET: Students/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var students = await Student.GetAll(db);
            StudentViewModels studentViewModels = students.Where(x => x.IdStudent == id).Select(x => new StudentViewModels() { IdStudent = x.IdStudent, Name = x.Name, SurName = x.SurName }).FirstOrDefault();
            if (studentViewModels == null)
            {
                return HttpNotFound();
            }
            return View(studentViewModels);
        }

        // POST: Students/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            db.Students.Remove(await db.Students.FindAsync(id));
            await db.SaveChangesAsync();
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
