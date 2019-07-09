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
        [Route("{i}")]
        public async Task<Project> Get(int i)
        {
            
            return await Service.Get(i);
        }
    }
}