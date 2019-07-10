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
    public class EmployeesController : Controller
    {
        private IEmployeesService Service { get; set; }

        public EmployeesController(IEmployeesService service)
        {
            Service = service;
        }

        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<ActionResult<IEnumerable<Employee>>> Get()
        {
            return Ok(await Service.Get());
        }

        [HttpGet("{key}/Project")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<ActionResult<IEnumerable<Employee>>> GetEmployees(long key)
        {
            return Ok(await Service.GetEmployees(key));
        }

        [HttpGet("{key}")]
        public async Task<ActionResult<Employee>> Get(long key)
        {
            Employee employee = await Service.Get(key);

            if (employee == null)
                return NotFound("Not Found employee");
            else return Ok(employee);
        }
        
        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<ActionResult<Employee>> Create([FromBody]Employee employee)
        {
            employee = await Service.Create(employee);
            if (employee == null)
                return BadRequest("Maybe this employee is exist");
            else return Ok(employee);
        }

        [HttpPut]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public ActionResult<Employee> Update(Employee employee)
        {
            employee = Service.Update(employee);
            if (employee == null)
                return NotFound("Not Found employee for update");
            return Ok(employee);
        }
        [HttpDelete]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public ActionResult<bool> Delete(Employee employee)
        {
            if (Service.Remove(employee) == true)
                return Ok(true);
            else return NotFound("Not Found employee for delete");
        }

        [HttpDelete("{key}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public ActionResult<bool> Delete(long key)
        {
            if (Service.Remove(key) == true)
                return Ok(true);
            else return NotFound("Not Found employee for delete");
        }

    }
}