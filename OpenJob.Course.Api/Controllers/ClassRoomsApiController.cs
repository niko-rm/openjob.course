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
    public class ClassRoomsApiController : ApiController
    {
        Course.DbCourse.Entities.DbCourseCtx db = new DbCourse.Entities.DbCourseCtx();

        [HttpGet]
        [Route("ClassRooms/GetAll")]
        [ResponseType(typeof(List<ClassRoomDTO>))]
        public async Task<IHttpActionResult> GetAll()
        {
            var result = new List<ClassRoomDTO>();

            var classes = await db.ClassRooms.ToListAsync();
            foreach (var c in classes)
            {
                result.Add(new ClassRoomDTO() {
                    IdClassRoom = c.IdClassRoom,
                    Name = c.ClassRoomName
                });
            }
            return Ok(result);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}
