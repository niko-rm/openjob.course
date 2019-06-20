using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OpenJob.Course.Web.Dto
{
    public class StudentDTO
    {
        [Key]
        public int IdStudent { get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }
        public string Username { get; set; }

        public string GetFullName()
        {
            return Name + " " + SurName;
        }
    }
}