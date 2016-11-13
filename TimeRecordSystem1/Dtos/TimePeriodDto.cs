using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TimeRecordSystem1.Dtos
{
    public class TimePeriodDto
    {
        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}