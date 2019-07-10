using EfCoreSample.Doman;
using EfCoreSample.Doman.Enum;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EfCoreSample.Services
{
    public interface IProjectService : IBaseService
    {
        Task<IEnumerable<Project>> Get(Status? status, string title, DateTime? startTime, DateTime? endTime, int page, int pageSize, SortState sortOrder);
        Task<Project> Get(long id);
        Task<IEnumerable<Project>> GetProjects(long key);
        Task<Project> Create(Project item);
        Project Update(Project item);
        bool Remove(Project item);
        bool Remove(long id);
    }
}
