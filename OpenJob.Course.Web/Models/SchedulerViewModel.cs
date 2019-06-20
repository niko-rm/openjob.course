using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OpenJob.Course.Web.Models
{
    public class SchedulerViewModel
    {
        public int IdSelectedStudent { get; set; }
        public List<StudentViewModels> students { get; set; }
        public List<LessonViewModels> lessons { get; set; }
        public List<ClassRoomViewModels> classRooms { get; set; }
    }
}