using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using OpenJob.Course.DTOs;

namespace OpenJob.Course.DbCourse.Entities
{
    public partial class ClassRoom
    {
        private static async Task<List<ClassRoom>> GetAllClassRooms(DbCourseCtx ctx)
        {
            return await ctx.ClassRooms.ToListAsync();
        }

        public static async Task<List<ClassRoomDTO>> GetAll(DbCourseCtx ctx)
        {
            var result = await GetAllClassRooms(ctx);

            return result.Select(x => new ClassRoomDTO()
            {
                Name = x.ClassRoomName,
                IdClassRoom = x.IdClassRoom
            }).ToList();
        }
    }
}
