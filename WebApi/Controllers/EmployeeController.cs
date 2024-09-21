using Microsoft.AspNetCore.Mvc;
using Application.Interfaces;
using AutoMapper;
using Application.DTO.Employee;
using Microsoft.AspNetCore.Authorization;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeServices _employeeService;

        public EmployeesController(IEmployeeServices employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet("ViewEmployees")]
        public IActionResult ViewEmployees()
        {
            try
            {
                var employeeRecords = _employeeService.GetEmployeeRecords();

                if (employeeRecords == null || employeeRecords.Count == 0)
                {
                    return NotFound("No employee records available.");
                }

                return Ok(employeeRecords);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while loading employee records: {ex.Message}");
            }
        }

        [HttpGet("DisplayEmployeeByNumber/{employeeId}")]
        public IActionResult DisplayEmployeeByNumber(string employeeId)
        {
            try
            {
                var employee = _employeeService.FetchEmployeeByID(employeeId);

                if (employee == null)
                {
                    return NotFound("Employee with the provided employee number does not exist.");
                }

                return Ok(employee);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while fetching the employee record: {ex.Message}");
            }
        }

        [HttpPost("AddEmployee")]
        public IActionResult AddEmployee([FromBody] AddEmployeeDto newEmployee)
        {
            try
            {
                if (newEmployee == null)
                {
                    return BadRequest("Invalid request. Employee data is missing.");
                }
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                if (_employeeService.AddEmployeeRecord(newEmployee))
                {
                    return Ok("Employee added successfully.");
                }
                else
                {
                    return StatusCode(500, "Failed to add employee record.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while adding employee record: " + ex.Message);
            }
        }

        [HttpPut("UpdateEmployee/{employeeId}")]
        public IActionResult UpdateEmployee(string employeeId, [FromBody] AddEmployeeDto updatedEmployeeData)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                if (updatedEmployeeData == null)
                {
                    return BadRequest("Invalid request. Updated employee data is missing.");
                }

                if (_employeeService.SaveUpdatedEmployeeData(employeeId, updatedEmployeeData))
                {
                    return Ok("Employee updated successfully.");
                }
                else
                {
                    return NotFound("Employee not found.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while updating employee record: {ex.Message}");
            }
        }


        [HttpDelete("DeleteEmployee/{employeeId}")]
        public IActionResult DeleteEmployee(string employeeId)
        {
            try
            {
                bool deletedSuccessfully = _employeeService.DeleteEmployee(employeeId);
                if (deletedSuccessfully)
                {
                    return Ok($"Employee with Employee Number {employeeId} deleted successfully.");
                }
                else
                {
                    return NotFound("Employee not found.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while deleting the employee record: {ex.Message}");
            }
        }



    }
}