using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EfCoreSample.Doman;
using EfCoreSample.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace EfCoreSample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private IService Service { get; set; }

        public ProjectController(IService service)
        {
            Service = service;
        }


        [HttpGet]
        public async Task<IEnumerable<Project>> Get()
        {
            return await Service.Get();
        }


        [Route("{key}")]
        public async Task<Project> Get(long key)
        {
            return await Service.Get(key);
        }

        [HttpPost]
        public async Task<bool> Create([FromBody]Project project)
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