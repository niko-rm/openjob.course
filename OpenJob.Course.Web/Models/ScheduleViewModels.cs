using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OpenJob.Course.Web.Models
{
    public class ScheduleViewModels
    {
        public List<StudentViewModels> listStudents { get; set; }
        public List<ClassRoomViewModels> listClassroom { get; set; }
        public List<LessonViewModels> listLessons { get; set; }


    }
}