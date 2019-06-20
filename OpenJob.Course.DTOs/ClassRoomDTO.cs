using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenJob.Course.DTOs
{
    public class ClassRoomDTO
    {
        [Key]
        public int IdClassRoom { get; set; }
        public string Name { get; set; }
    }
}
