using OpenJob.Course.Web.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace OpenJob.Course.DbCourse.Entities
{
    public partial class Student
    {
        private static async Task<List<Student>> GetAllStudents(DbCourseCtx ctx)
        {
            return await ctx.Students.ToListAsync();
        }

        public static async Task<List<StudentDTO>> GetAll(DbCourseCtx ctx)
        {
            List<StudentDTO> result = new List<StudentDTO>();
            var students = await GetAllStudents(ctx);

            result = students
                .Select(student => new StudentDTO
                {
                    Name = student.StudentName,
                    SurName = student.StudentSurname,
                    IdStudent = student.IdStudent,
                })
                .ToList();

            return result;
        }

        public static async Task<List<StudentDTO>> GetAll(DbCourseCtx ctx, string search)
        {
            List<StudentDTO> result = new List<StudentDTO>();
            var students = await GetAllStudents(ctx);

            result = students
                .Select(student => new StudentDTO
                {

                    Name = student.StudentName,
                    SurName = student.StudentSurname,
                    IdStudent = student.IdStudent,
                })
                .ToList();

            return result;
        }
    }
}
