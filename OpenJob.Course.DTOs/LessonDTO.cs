using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenJob.Course.DTOs
{
    public class LessonDTO
    {
        [Key]
        public int IdLesson { get; set; }
        public string Name { get; set; }
    }
}
