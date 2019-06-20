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
    public class ClassRoomsController : Controller
    {
        private DbCourseCtx db = new DbCourseCtx();

        public ClassRoomsController()
        { //<== Put a breakpoint here to understand how does it works!
            //Inizialize Log here!
        }
        // GET: ClassRooms
        public async Task<ActionResult> Index()
        {
            var result = await ClassRoom.GetAll(db);
            return View(result.Select(x=> new ClassRoomViewModels() { IdClassRoom = x.IdClassRoom, Name = x.Name }).ToList());
        }

        // GET: ClassRooms/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var classes = await ClassRoom.GetAll(db);
            ClassRoomViewModels classRoomViewModels = classes.Where(x=> x.IdClassRoom == id).Select(x=> new ClassRoomViewModels() { IdClassRoom = x.IdClassRoom, Name = x.Name }).FirstOrDefault();
            if (classRoomViewModels == null)
            {
                return HttpNotFound();
            }
            return View(classRoomViewModels);
        }

        // GET: ClassRooms/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ClassRooms/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "IdClassRoom,Name")] ClassRoomViewModels classRoomViewModels)
        {
            if (ModelState.IsValid)
            {
                db.ClassRooms.Add(new ClassRoom { ClassRoomName = classRoomViewModels.Name });
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(classRoomViewModels);
        }

        // GET: ClassRooms/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var classes = await ClassRoom.GetAll(db);
            ClassRoomViewModels classRoomViewModels = classes.Where(x => x.IdClassRoom == id).Select(x => new ClassRoomViewModels() { IdClassRoom = x.IdClassRoom, Name = x.Name }).FirstOrDefault();
            if (classRoomViewModels == null)
            {
                return HttpNotFound();
            }
            return View(classRoomViewModels);
        }

        // POST: ClassRooms/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "IdClassRoom,Name")] ClassRoomViewModels classRoomViewModels)
        {
            if (ModelState.IsValid)
            {
                var entity = await db.ClassRooms.FindAsync(classRoomViewModels.IdClassRoom);
                entity.ClassRoomName = classRoomViewModels.Name;
                db.Entry(entity).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(classRoomViewModels);
        }

        // GET: ClassRooms/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var classes = await ClassRoom.GetAll(db);
            ClassRoomViewModels classRoomViewModels = classes.Where(x => x.IdClassRoom == id).Select(x => new ClassRoomViewModels() { IdClassRoom = x.IdClassRoom, Name = x.Name }).FirstOrDefault();
            if (classRoomViewModels == null)
            {
                return HttpNotFound();
            }
            return View(classRoomViewModels);
        }

        // POST: ClassRooms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            db.ClassRooms.Remove(await db.ClassRooms.FindAsync(id));
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
