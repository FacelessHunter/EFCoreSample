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
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectsController : Controller
    {
        private IProjectService Service { get; set; }

        public ProjectsController(IProjectService service)
        {
            Service = service;
        }


        /// <summary>
        /// GET paginated list of searching projects according to the filer, sorted by 
        ///StartTimeAsc=1,
        ///StartTimeDesc=2,
        ///EndTimeAsc=3,
        ///EndTimeDesc=4,
        ///LastUpdateTimeAsc=5,
        ///LastUpdateTimeDesc=6,
        ///TitleAsc=7,
        ///TitleDes=8c
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// 
        ///     GET /Projects
        ///     GET /Projects?[name]=[value]
        ///     
        /// </remarks>
        /// <param name="status"></param>
        /// <param name="title"></param>
        /// <param name="startTime"></param>
        /// <param name="endTime"></param>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        /// <param name="sortOrder"></param>
        /// <returns>Paginated list of searching projects according to the filer and sorted</returns>
        /// <response code="200">list of searching projects</response>
        /// <response code="400">If the items is null</response>   
        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
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

        /// <summary>
        /// Get project by key
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// 
        ///     GET /Projects/1
        ///     
        /// </remarks>
        /// <param name="key"></param> 
        [HttpGet("{key}")]
        public async Task<ActionResult<Project>> Get(long key)
        {
            Project project = await Service.Get(key);

            if (project == null)
                return NotFound("Not Found project");
            else return Ok(project);
        }

        /// <summary>
        /// Creates a Project.
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /Projects
        ///     {
        ///         "title": "DWPsdgbfnshj",
        ///         "description": "sdfghjkjsfghgfdsx",
        ///         "status": 2,
        ///         "endTime": "2019-07-09T21:09:36.679336",
        ///     }
        ///
        /// </remarks>
        /// <param name="project"></param>
        /// <returns>A newly created project</returns>
        /// <response code="200">Returns the newly created item</response>
        /// <response code="400">If the item is null</response>            
        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<ActionResult<Project>> Create([FromBody]Project project)
        {
            project = await Service.Create(project);
            if (project == null)
                return BadRequest("Maybe this project is exist");
            else return Ok(project);
        }

        /// <summary>
        /// Update project in database
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     PUT /Projects
        ///     {
        ///         "id": 2,
        ///         "title": "Title",
        ///         "description": "Description",
        ///         "status": 1,
        ///         "endTime": "3001-01-01T00:00:00"
        ///     }
        ///
        /// </remarks>
        /// <param name="project"></param>
        /// <returns>Chenged project</returns>
        /// <response code="200">project</response>
        /// <response code="404">If the item is exist</response>   
        [HttpPut]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public ActionResult<Project> Update(Project project)
        {
            project = Service.Update(project);
            if (project == null)
                return NotFound("Not Found project for update");
            return Ok(project);
        }
        /// <summary>
        /// Delete project in database
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     DELETE /Projects
        ///     {
        ///         "id": 2,
        ///         "title": "Title",
        ///         "description": "Description",
        ///         "status": 1,
        ///         "endTime": "3001-01-01T00:00:00"
        ///     }
        ///
        /// </remarks>
        /// <param name="project"></param>
        /// <returns>Boolean, if secssesfull deleted than return true else false</returns>
        /// <response code="200">If secssesfull deleted</response>
        /// <response code="404">If not secssesfull deleted</response>   
        [HttpDelete]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public ActionResult<bool> Delete(Project project)
        {
            if (Service.Remove(project) == true)
                return Ok(true);
            else return NotFound("Not Found project for delete");
        }

        /// <summary>
        /// Delete project in database by key
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// 
        ///     DELETE /Projects/1
        ///     
        /// </remarks>
        /// <param name="key"></param>
        /// <returns>Boolean, if secssesfull deleted than return true else false</returns>
        /// <response code="200">If secssesfull deleted</response>
        /// <response code="404">If not secssesfull deleted</response>   
        [HttpDelete("{key}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public ActionResult<bool> Delete(long key)
        {
            if (Service.Remove(key) == true)
                return Ok(true);
            else return NotFound("Not Found project for delete");
        }
        
    }
}