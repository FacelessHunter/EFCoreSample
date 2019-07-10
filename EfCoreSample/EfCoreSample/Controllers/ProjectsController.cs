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
    public class ProjectsController : Controller
    {
        private IProjectService Service { get; set; }

        public ProjectsController(IProjectService service)
        {
            Service = service;
        }
        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Project>>> Get(Status? status, 
                                                    string title, 
                                                    DateTime? startTime, 
                                                    DateTime? endTime, 
                                                    int page = 1, 
                                                    int pageSize = 3,
                                                    SortState sortOrder = SortState.LastUpdateTimeAsc)
        {
            return Ok(await Service.Get(status, title, startTime, endTime, page, pageSize, sortOrder));
        }

        
        [HttpGet("{key}")]
        public async Task<ActionResult<Project>> Get(long key)
        {
            Project project = await Service.Get(key);

            if (project == null)
                return NotFound("Not Found project");
            else return Ok(project);
        }
        
        [HttpPost]
        public async Task<ActionResult<Project>> Create([FromBody]Project project)
        {
            project = await Service.Create(project);
            if (project == null)
                return BadRequest("Maybe this project is exist");
            else return Ok(project);
        }

        [HttpPut]
        public ActionResult<Project> Update(Project project)
        {
            project = Service.Update(project);
            if (project == null)
                return NotFound("Not Found project for update");
            return Ok(project);
        }
        [HttpDelete]
        public ActionResult<bool> Delete(Project project)
        {
            if (Service.Remove(project) == true)
                return Ok(true);
            else return NotFound("Not Found project for delete");
        }

        [HttpDelete("{key}")]
        public ActionResult<bool> Delete(long key)
        {
            if (Service.Remove(key) == true)
                return Ok(true);
            else return NotFound("Not Found project for delete");
        }
        
    }
}