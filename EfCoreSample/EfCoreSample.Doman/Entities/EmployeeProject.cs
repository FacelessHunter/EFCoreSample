using System;
using System.Collections.Generic;
using System.Text;

namespace EfCoreSample.Doman
{
    public class EmployeeProject
    {
        public long EmployeeId { get; set; }
        public Employee Employee { get; set; }

        public long ProjectId { get; set; }
        public Project Project { get; set; }
    }
}
