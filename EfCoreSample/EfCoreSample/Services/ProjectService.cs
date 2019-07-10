using EfCoreSample.Doman;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using EfCoreSample.Infrastructure;
using EfCoreSample.Doman.Enum;
using System.Linq;
using EfCoreSample.Infrastructure.Abstraction;

namespace EfCoreSample.Services
{
    class ProjectService : IProjectService
    {
        IRepository<Project, long> projectRepository { get; set; }
        public ProjectService(IRepository<Project, long> projectRepository)
        {
            this.projectRepository = projectRepository;
        }

        public async Task<IEnumerable<Project>> Get(Status? status, string title, DateTime? startTime, DateTime? endTime, int page, int pageSize, SortState sortOrder)
        {
            
            IEnumerable<Project> projects = await projectRepository.GetAllAsync();

            if(startTime != null && endTime != null)
            {
                projects = await projectRepository.GetAsync(p => p.StartTime >= startTime && p.EndTime <= endTime);
            }
            if (!String.IsNullOrEmpty(title))
            {
                projects = await projectRepository.GetAsync(p => p.Title.Contains(title));
            }
            if (status != null)
            {
                if (status == Status.Pending)
                    projects = await projectRepository.GetAsync(p => p.Status == Status.Pending);
                else if(status == Status.InProgress)
                    projects = await projectRepository.GetAsync(p => p.Status == Status.InProgress);
                else if(status == Status.Completed)
                    projects = await projectRepository.GetAsync(p => p.Status == Status.Completed);
                else
                    projects = await projectRepository.GetAsync(p => p.Status == Status.Cancelled);
            }
            switch (sortOrder)
            {
                case SortState.LastUpdateTimeDesc:
                    projects = projects.OrderByDescending(p => p.LastUpdatedTime);
                    break;
                case SortState.TitleAsc:
                    projects = projects.OrderBy(p => p.Title);
                    break;
                case SortState.TitleDesc:
                    projects = projects.OrderByDescending(p => p.Title);
                    break;
                case SortState.StartTimeAsc:
                    projects = projects.OrderBy(p => p.StartTime);
                    break;
                case SortState.StartTimeDesc:
                    projects = projects.OrderByDescending(p => p.StartTime);
                    break;
                case SortState.EndTimeAsc:
                    projects = projects.OrderBy(p => p.EndTime);
                    break;
                case SortState.EndTimeDesc:
                    projects = projects.OrderByDescending(p => p.EndTime);
                    break;
                default:
                    projects = projects.OrderBy(p => p.LastUpdatedTime);
                    break;
            }
       
            return projects.Skip((page - 1) * pageSize).Take(pageSize).ToList<Project>();
        }

        public async Task<Project> Get(long key)
        {
            var project = await projectRepository.FindAsync(key);
            if(project !=null)
                return await projectRepository.FindAsync(key);
            return null;
        }

        public async Task<Project> Create(Project item)
        {
            if (!projectRepository.IsExist(item.Id))
                return await projectRepository.InsertAsync(item);
            return null;
        }

        public Project Update(Project item)
        {
            if (projectRepository.IsExist(item.Id))
                return projectRepository.Update(item);
            else return null;
        }


        public bool Remove(Project item)
        {
            
            if (!projectRepository.IsExist(item.Id))
            { 
                if (item.Status != Status.InProgress)
                    return projectRepository.Remove(item);
                return false;
            }
            else return false;
        }

        public bool Remove(long key)
        {
            var project = projectRepository.Find(key);
            if (project.Status != Status.InProgress)
                return projectRepository.Remove(key);
            else return false;
        }

    }
}
