using EfCoreSample.Doman;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using EfCoreSample.Infrastructure;
using EfCoreSample.Doman.Enum;

namespace EfCoreSample.Services
{
    class ProjectService : IService
    {
        ProjectRepository projectRepository { get; set; }
        public ProjectService(ProjectRepository projectRepository)
        {
            this.projectRepository = projectRepository;
        }

        public async Task<IEnumerable<Project>> Get()
        {
            return await projectRepository.GetAllAsync();
        }

        public async Task<Project> Get(long key)
        {
            return await projectRepository.FindAsync(key);
        }

        /*public async Task<IEnumerable<Project>> GetMembersAsync(long key)
        {
            return await projectRepository.GetMembersAsync(key);
        }*/
        public async Task<bool> Create(Project item)
        {
            await projectRepository.InsertAsync(item);
            return await projectRepository.IsExistAsync(item.Id);
        }

        public Project Update(Project item)
        {
            return projectRepository.Update(item);

        }

        public void UpdateRange(IEnumerable<Project> item)
        {
            projectRepository.UpdateRange(item);

        }

        public bool Remove(Project item)
        {
            if (item.Status != Status.InProgress)
                return projectRepository.Remove(item);
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
