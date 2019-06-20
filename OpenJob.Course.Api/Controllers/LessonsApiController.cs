using OpenJob.Course.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using System.Data.Entity;

namespace OpenJob.Course.Api.Controllers
{
    public class LessonsApiController : ApiController
    {
        Course.DbCourse.Entities.DbCourseCtx db = new DbCourse.Entities.DbCourseCtx();

        [HttpGet]
        [Route("Lessons/GetAll")]
        [ResponseType(typeof(List<LessonDTO>))]
        public async Task<IHttpActionResult> GetAll()
        {
            var result = new List<LessonDTO>();

            var lessons = await db.Lessons.ToListAsync();

            result.AddRange(lessons.Select(x=> new LessonDTO() { IdLesson = x.IdLesson, Name = x.LessonName }));
           
            return Ok(result);
        }
        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}
