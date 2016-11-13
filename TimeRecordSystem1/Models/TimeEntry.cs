using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TimeRecordSystem1.Models
{
    public enum StatusType
    {

        Approved,
        Unsubmited,
        OnProcessing,
        Rejected
    }
    public class TimeEntry
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public Double WorkTime { get; set; }
        public string Comment { get; set; }
        public StatusType Status { get; set; }

        public virtual Project Project { get; set; }
        public virtual User User { get; set; }
    }
}