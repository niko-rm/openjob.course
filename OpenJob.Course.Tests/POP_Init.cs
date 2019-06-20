using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenJob.Course.DbCourse.Entities;

namespace OpenJob.Course.Tests
{
    [TestClass]
    public class POP_Init
    {
        [TestMethod]
        public void DataBase_Seed()
        {
            using  (var ctx = new DbCourseCtx())
            {
                for (var i = 0; i < 30; i++)
                {
                    ctx.Students.Add(new Student { StudentName = "Name " + i, StudentSurname = "Surname " + i });
                }
                ctx.SaveChanges();

                for (var i = 0; i < 10; i++)
                {
                    ctx.Lessons.Add(new Lesson { LessonName = "Lesson " + i });
                }
                ctx.SaveChanges();

                for (var i = 0; i < 15; i++)
                {
                    ctx.ClassRooms.Add(new ClassRoom { ClassRoomName = "Class " + i });
                }
                ctx.SaveChanges();
            }
        }
        [TestMethod]
        public void DataBase_Scheduler()
        {
            using (var ctx = new DbCourseCtx())
            {
                foreach (var r in ctx.ClassRooms)
                {
                    foreach (var l in ctx.Lessons)
                    {
                        foreach (var s in ctx.Students)
                        {
                            ctx.ClassRoom_Student.Add(new ClassRoom_Student
                            {
                                IdClassRoom = r.IdClassRoom,
                                IdLesson = l.IdLesson,
                                IdStudent = s.IdStudent,
                            });
                        }
                    }
                }
                ctx.SaveChanges();
            }
        }
    }
}
