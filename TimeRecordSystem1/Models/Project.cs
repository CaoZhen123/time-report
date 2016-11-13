using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TimeRecordSystem1.Models
{
    public class Project
    {
        public int Id { get; set; }
        public string ProjectName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int Duration { get; set; }
        public string Status { get; set; }
    }
}