using OpenJob.Course.Web.Models;
using OpenJob.Course.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OpenJob.Course.DbCourse.Entities;
using Microsoft.VisualBasic.Logging;

namespace OpenJob.Course.Web.Controllers
{
    public class LogDefinitionController : Controller
    {
   
        private DbCourseCtx db = new DbCourseCtx();
        // GET: LogDefinition
        public ActionResult Index()
        {
            return View();
        }

        public void Insert(LogDefinitionDTO logDef)
        {

            // List<Log> result = new List<Log>();
            var logDaInserire = new  OpenJob.Course.DbCourse.Entities.LogDefinition()
             
            {
                UidLog = logDef.UidLog,
                LogAction = logDef.LogAction.ToString(),
                LogSeverity = logDef.LogSeverity.ToString(),
                LogMessage = logDef.LogMessage
            };
            db.LogDefinitions.Add(logDaInserire);
            db.SaveChanges();
            
            //return View();
        }

    }
}