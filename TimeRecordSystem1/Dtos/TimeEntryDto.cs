using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TimeRecordSystem1.Models;

namespace TimeRecordSystem1.Dtos
{
    public class TimeEntryDto
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public Double WorkTime { get; set; }
        public string Comment { get; set; }
        public StatusType Status { get; set; }

        public virtual ProjectDto Project { get; set; }
        public virtual UserDto User { get; set; }
    }
}