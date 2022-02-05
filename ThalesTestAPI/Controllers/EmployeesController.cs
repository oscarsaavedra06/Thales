using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using ThalesTestAPI.CustomEntities;
using ThalesTestApplicationCore.Entities;
using ThalesTestApplicationCore.Interfaces;

namespace ThalesTestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployee _repository;
        public EmployeesController(IEmployee repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// Retrieve all employees
        /// </summary>
       
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ApiResponse<IEnumerable<Employee>>))] 
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            try
            {
                var result = await _repository.getEmployees();
                var response = new ApiResponse<IEnumerable<Employee>>(result)
                {
                    code = ((int)HttpStatusCode.OK),
                    status = "Ok",
                    message = ""
                };

                return Ok(response);
            }
            catch (Exception ex)
            {

                return BadRequest(new ApiResponse<object>(null) { code = ((int)HttpStatusCode.InternalServerError), status = "Internal Server Error", message = "" });
            }
        }

        /// <summary>
        /// Get specific employee
        /// </summary>
        /// /// <param name="id">Employee id.</param>
    
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ApiResponse<Employee>))] 
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult> Get(int id)
        {
            try
            {
                var result = await _repository.getEmployeesById(id);
                var response = new ApiResponse<Employee>(result)
                {
                    code = ((int)HttpStatusCode.OK),
                    status = "Ok",
                    message = ""
                };

                return Ok(response);
            }
            catch (Exception ex)
            {

                return BadRequest(new ApiResponse<object>(null) { code = ((int)HttpStatusCode.InternalServerError), status = "Internal Server Error", message = "" });
            }
        }
    }
}

