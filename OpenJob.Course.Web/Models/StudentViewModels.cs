﻿using OpenJob.Course.Web.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OpenJob.Course.Web.Models
{
    public class StudentViewModels : StudentDTO
    {
        public string Username { get; set; }
    }
}