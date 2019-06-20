using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using OpenJob.Course.DTOs;

namespace OpenJob.Course.DbCourse.Entities
{
    public partial class Lesson
    {
        private static async Task<List<Lesson>> GetAllClassRooms(DbCourseCtx ctx)
        {
            return await ctx.Lessons.ToListAsync();
        }
        public static async Task<List<LessonDTO>> GetAll(DbCourseCtx ctx)
        {
            var result = await GetAllClassRooms(ctx);

            return result.Select(x => new LessonDTO()
            {
                Name = x.LessonName,
                IdLesson = x.IdLesson
            }).ToList();
        }
    }
}
