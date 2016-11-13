using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TimeRecordSystem1.Models;

namespace TimeRecordSystem1.ViewModels
{
    public class TimeEntryCreationViewModel
    {
        public IEnumerable<Project> Projects { get; set; }
        public IEnumerable<User> Users { get; set; }
        public int SeletctedProjectId { get; set; }
        public int SelectedUserId { get; set; }
        public TimeEntry TimeEntry { get; set; }
    }
}