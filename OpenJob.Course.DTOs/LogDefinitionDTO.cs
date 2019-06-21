using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenJob.Course.DTOs
{
    public class LogDefinitionDTO
    {
        [Key]
        public Guid UidLog { get; set; }
        public Enum LogAction { get; set; }
        public Enum LogSeverity { get; set; }
        public string LogMessage { get; set; }

    }
}
