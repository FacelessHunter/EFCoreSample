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


        /// <summary>
        /// GET list of Employees 
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// 
        ///     GET /Employees
        ///         
        /// </remarks>
        /// <returns>list of Epmloyees</returns>
        /// <response code="200"> if secssesfull return list of Employees</response>
        /// <response code="404">If the items is null</response> 
        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<ActionResult<IEnumerable<Employee>>> Get()
        {
            return Ok(await Service.Get());
        }


        /// <summary>
        /// GET list of Employees by ProjectId 
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// 
        ///     GET /Employees/[key]/Project
        ///     
        ///     [key] = ProjectId;
        ///     
        /// </remarks>
        /// <param name="key"></param>
        /// <returns>list of Employees</returns>
        /// <response code="200"> if secssesfull return list of Employees</response>
        /// <response code="404">If the items is null</response> 
        [HttpGet("{key}/Project")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<IEnumerable<Employee>>> GetEmployees(long key)
        {
            var employees = await Service.GetEmployees(key);
            if (employees == null)
                return NotFound("Not Found employees");
            return Ok(employees);
        }


        /// <summary>
        /// GET list of Employee by Id
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// 
        ///     GET /Employees/[key]
        ///     
        ///     [key] = EmployeeId;
        ///     
        /// </remarks>
        /// <param name="key"></param>
        /// <returns>Employee</returns>
        /// <response code="200"> if secssesfull return Employee</response>
        /// <response code="404">If the item is null</response> 
        [HttpGet("{key}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<Employee>> Get(long key)
        {
            Employee employee = await Service.Get(key);

            if (employee == null)
                return NotFound("Not Found employee");
            else return Ok(employee);
        }

        /// <summary>
        /// Create new employee
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// 
        ///     POST /Employees
        ///     {
        ///         "FirstName": "Vasy",
        ///         "LastName": "Pupkin",
        ///         "ReportsToId": 2,
        ///         "LastModified": "3019-07-09T21:09:36.679336",
        ///     }
        ///     
        /// </remarks>
        /// <param name="employee"></param>
        /// <returns>Employee</returns>
        /// <response code="200"> if secssesfull return Employee</response>
        /// <response code="404">If the item is null</response> 
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

        /// <summary>
        /// Update employee in database
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     PUT /Employees
        ///     {
        ///         "id": 2,
        ///         "FirstName": "Vasy",
        ///         "LastName": "Pupkin",
        ///         "ReportsToId": 1,
        ///         "LastModified": "3021-07-09T21:09:36.679336",
        ///     }
        ///     
        ///
        /// </remarks>
        /// <param name="employee"></param>
        /// <returns>Chenged project</returns>
        /// <response code="200">project</response>
        /// <response code="404">If the item is exist</response> 
        [HttpPut]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public ActionResult<Employee> Update(Employee employee)
        {
            employee = Service.Update(employee);
            if (employee == null)
                return NotFound("Not Found employee for update");
            return Ok(employee);
        }

        /// <summary>
        /// Delete employee in database
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     DELETE /Employees
        ///     {
        ///         "id": 2,
        ///         "FirstName": "Vasy",
        ///         "LastName": "Pupkin",
        ///         "ReportsToId": 1,
        ///         "LastModified": "3021-07-09T21:09:36.679336",
        ///     }
        ///     
        /// </remarks>
        /// <param name="employee"></param>
        /// <returns>Boolean, if secssesfull deleted than return true else false</returns>
        /// <response code="200">If secssesfull deleted</response>
        /// <response code="404">If not secssesfull deleted</response> 
        [HttpDelete]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public ActionResult<bool> Delete(Employee employee)
        {
            if (Service.Remove(employee) == true)
                return Ok(true);
            else return NotFound("Not Found employee for delete");
        }

        /// <summary>
        /// Delete employee in database by key
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// 
        ///     DELETE /Employees/1
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
            else return NotFound("Not Found employee for delete");
        }

    }
}