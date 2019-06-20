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
    public class LessonsController : Controller
    {
        private DbCourseCtx db = new DbCourseCtx();

        public LessonsController()
        {//<== Put a breakpoint here to understand how does it works!
            //Inizialize Log here!
        }

        // GET: Lessons
        public async Task<ActionResult> Index()
        {
            var result = await Lesson.GetAll(db);
            return View(result.Select(x=> new LessonViewModels() { IdLesson = x.IdLesson, Name = x.Name }).ToList());
        }

        // GET: Lessons/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var lessons = await Lesson.GetAll(db);
            LessonViewModels lessonViewModels = lessons.Where(x=> x.IdLesson == id).Select(x=> new LessonViewModels() { IdLesson = x.IdLesson, Name = x.Name }).FirstOrDefault();
            if (lessonViewModels == null)
            {
                return HttpNotFound();
            }
            return View(lessonViewModels);
        }

        // GET: Lessons/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Lessons/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "IdLesson,Name")] LessonViewModels lessonViewModels)
        {
            if (ModelState.IsValid)
            {
                db.Lessons.Add(new Lesson
                {
                    LessonName = lessonViewModels.Name,
                });
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(lessonViewModels);
        }

        // GET: Lessons/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var lessons = await Lesson.GetAll(db);
            LessonViewModels lessonViewModels = lessons.Where(x => x.IdLesson == id).Select(x => new LessonViewModels() { IdLesson = x.IdLesson, Name = x.Name }).FirstOrDefault();
            if (lessonViewModels == null)
            {
                return HttpNotFound();
            }
            return View(lessonViewModels);
        }

        // POST: Lessons/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "IdLesson,Name")] LessonViewModels lessonViewModels)
        {
            if (ModelState.IsValid)
            {
                var entity = await db.Lessons.FindAsync(lessonViewModels.IdLesson);
                entity.LessonName = lessonViewModels.Name;
                db.Entry(entity).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(lessonViewModels);
        }

        // GET: Lessons/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var lessons = await Lesson.GetAll(db);
            LessonViewModels lessonViewModels = lessons.Where(x => x.IdLesson == id).Select(x => new LessonViewModels() { IdLesson = x.IdLesson, Name = x.Name }).FirstOrDefault();
            if (lessonViewModels == null)
            {
                return HttpNotFound();
            }
            return View(lessonViewModels);
        }

        // POST: Lessons/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {           
            db.Lessons.Remove(await db.Lessons.FindAsync(id));
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
