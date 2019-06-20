using OpenJob.Course.DbCourse.Entities;
using OpenJob.Course.Web.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;

namespace OpenJob.Course.Api.Controllers
{
    public class StudentsApiController : ApiController
    {
        Course.DbCourse.Entities.DbCourseCtx db = new DbCourse.Entities.DbCourseCtx();

        [HttpGet]
        [Route("Students/Search/{textToSearch}")]
        [ResponseType(typeof(List<StudentDTO>))]
        public async Task<IHttpActionResult> SearchStudent(string textToSearch)
        {
            var result = new List<StudentDTO>();

            var students = await Student.GetAll(db);                
            students.Where(student => 
                    student.Name.ToLower().Contains(textToSearch.ToLower())
                    ||
                    student.SurName.ToLower().Contains(textToSearch.ToLower())
                )
                .Select(student =>
                    new StudentDTO()
                    {
                        IdStudent = student.IdStudent,
                        Name = student.Name,
                        SurName = student.SurName
                    }
                )
                .ToList();

            return Ok(result);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}
