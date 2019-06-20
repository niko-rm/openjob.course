using OpenJob.Course.DbCourse.Entities;
using OpenJob.Course.Web.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace OpenJob.Course.Web.Controllers
{
    public class HomeController : Controller
    {
        public async Task<ActionResult> Index()
        {
            List<StudentViewModels> studentsViewModels = new List<StudentViewModels>();
            using (var ctx = new DbCourseCtx())
            {
               var students = await Student.GetAll(ctx);
               studentsViewModels = students.Select(student =>
                    new StudentViewModels()
                    {
                        IdStudent = student.IdStudent,
                        Name = student.Name,
                        SurName = student.SurName,
                        Username = student.IdStudent.ToString().PadLeft(7, '0'),
                    }).ToList();
            }

            return View(studentsViewModels);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}