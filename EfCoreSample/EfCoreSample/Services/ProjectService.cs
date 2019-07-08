using EfCoreSample.Doman;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using EfCoreSample.Infrastructure;

namespace EfCoreSample.Services
{
    class ProjectService : IService
    {
        ProjectRepository projectRepository { get; set; }
        public ProjectService(ProjectRepository projectRepository)
        {
            this.projectRepository = projectRepository;
        }

        public async Task<Project> Get(long id)
        {
            return await projectRepository.FindAsync(id);
        }
    }
}
