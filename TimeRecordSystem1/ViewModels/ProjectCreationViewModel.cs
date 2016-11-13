using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TimeRecordSystem1.Models;

namespace TimeRecordSystem1.ViewModels
{
    public class ProjectCreationViewModel
    {
        public Project Project { get; set; }
        public List<String> ProjectStatus { get; set; }
    }
}