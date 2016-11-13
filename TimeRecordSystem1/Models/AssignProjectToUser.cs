using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TimeRecordSystem1.Models
{
    public class AssignProjectToUser
    {
        public int Id { get; set; }

        public virtual Project Project { get; set; }

        public virtual User User { get; set; }
    }
}