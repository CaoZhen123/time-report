using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TimeRecordSystem1.Models;

namespace TimeRecordSystem1.ViewModels
{
    public class AssignProjectToUserCreationViewModel
    {
        public IEnumerable<Project> AllProjects { get; set; }
        public IEnumerable<User> AllUsers { get; set; }
        public int SelectedProjectId { get; set; }
        public List<int> SelectedUserIds { get; set; }

    }
}