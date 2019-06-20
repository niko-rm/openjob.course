using OpenJob.Course.DbCourse.Entities;
using OpenJob.Course.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace OpenJob.Course.Api.Controllers
{
    public class ScheduleController : Controller
    {
        private DbCourseCtx db = new DbCourseCtx();

        // GET: Schedule
        public async Task<ActionResult> Index()
        {
            var ScheduleViewModels = new OpenJob.Course.Web.Models.ScheduleViewModels();
            var listStudentDTO = await Student.GetAll(db);
            var listLessonDTO = await Lesson.GetAll(db);
            var listClassroomDTO = await ClassRoom.GetAll(db);

            //logica per il caricamento
            ScheduleViewModels.listStudents = listStudentDTO.Select(x => new StudentViewModels() { IdStudent = x.IdStudent, Name = x.Name, SurName = x.SurName }).ToList();
            ScheduleViewModels.listLessons = listLessonDTO.Select(x => new LessonViewModels() { IdLesson = x.IdLesson, Name = x.Name}).ToList();
            ScheduleViewModels.listClassroom = listClassroomDTO.Select(x => new ClassRoomViewModels() { IdClassRoom = x.IdClassRoom, Name = x.Name }).ToList();
            return View(ScheduleViewModels);
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