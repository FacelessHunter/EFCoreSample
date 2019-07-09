using EfCoreSample.Doman.Abstraction;
using EfCoreSample.Doman.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace EfCoreSample.Doman
{
    public class Project : IEntity<long>
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Status Status { get; set; }
        public DateTime LastUpdatedTime { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }

        public ICollection<EmployeeProject> EmployeeProjects { get; set; }

    }
}
