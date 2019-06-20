using OpenJob.Course.DbCourse.Entities;
using OpenJob.Course.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace OpenJob.Course.Web.Controllers
{
    public class SchedulerController : Controller
    {
        private DbCourseCtx db = new DbCourseCtx();
        // GET: Scheduler
        public async Task<ActionResult> Index()
        {
            List<StudentViewModels> studentsViewModels = new List<StudentViewModels>();
            List<LessonViewModels> lessonViewModels = new List<LessonViewModels>();
            List<ClassRoomViewModels> classRoomViewModels = new List<ClassRoomViewModels>();
           
            using (var ctx = new DbCourseCtx())
            {
                var students = await Student.GetAll(ctx);
                studentsViewModels = students.Select(student =>
                     new StudentViewModels()
                     {
                         IdStudent = student.IdStudent,
                         
                     }).ToList();
                var lessons = await Lesson.GetAll(ctx);
                lessonViewModels = lessons.Select(lesson =>
                     new LessonViewModels()
                     {
                         IdLesson = lesson.IdLesson
                     }).ToList();
                var classRooms = await ClassRoom.GetAll(ctx);
                classRoomViewModels = classRooms.Select(classRoom =>
                     new ClassRoomViewModels()
                     {
                         IdClassRoom = classRoom.IdClassRoom
                     }).ToList();
            }
            SchedulerViewModel schedulerViewModel = new SchedulerViewModel()
            {
                lessons = lessonViewModels,
                students = studentsViewModels,
                classRooms = classRoomViewModels
            };

            return View(schedulerViewModel);
        }

        [HttpPost]
        public JsonResult Create(int idStudente, int idLesson, int idClass)
        {
            db.ClassRoom_Student.Add(new ClassRoom_Student { IdStudent = idStudente, IdLesson = idLesson, IdClassRoom = idClass });
            db.SaveChanges();

            return Json(true, JsonRequestBehavior.DenyGet);
        }
    }
}