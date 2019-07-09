using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EfCoreSample.Doman;
using EfCoreSample.Doman.Enum;
using EfCoreSample.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace EfCoreSample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectsController : ControllerBase
    {
        private IProjectService Service { get; set; }

        public ProjectsController(IProjectService service)
        {
            Service = service;
        }

        [HttpGet]
        public async Task<IEnumerable<Project>> Get(
                                                    Status? status, 
                                                    string title, 
                                                    DateTime? startTime, 
                                                    DateTime? endTime, 
                                                    int page = 1, 
                                                    int pageSize = 3,
                                                    SortState sortOrder = SortState.LastUpdateTimeAsc)
        {
            return await Service.Get(status, title, startTime, endTime, page, pageSize, sortOrder);
        }


        [Route("{key}")]
        public async Task<Project> Get(long key)
        {
            return await Service.Get(key);
        }

        [HttpPost]
        public async Task<Project> Create([FromBody]Project project)
        {
            return await Service.Create(project);
        }

        [HttpPut()]
        public Project Update([FromBody]Project project)
        {
            return  Service.Update(project);
        }

        [HttpPut]
        public void Update([FromBody]IEnumerable<Project> projects)
        {
             Service.UpdateRange(projects);
        }

        [HttpDelete()]
        public bool Delete([FromBody]Project project)
        {
            return Service.Remove(project);
        }

        [HttpDelete("{key}")]
        public bool Delete(long key)
        {
            return Service.Remove(key);
        }
        
    }
}