using Microsoft.AspNetCore.Mvc;
using Application.Interfaces;
using Application.DTO.DepartmentAndRoles;
using Microsoft.AspNetCore.Authorization;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class DepartmentAndRolesController : ControllerBase
    {
        private readonly IDepartmentAndRolesServices _departmentAndRolesServices;

        public DepartmentAndRolesController(IDepartmentAndRolesServices departmentAndRolesServices)
        {
            _departmentAndRolesServices = departmentAndRolesServices;
        }

        [HttpPost("AddRole")]
        public IActionResult AddRole([FromBody] AddRoleDto request)
        {
            if (request == null || string.IsNullOrWhiteSpace(request.RoleName))
            {
                return BadRequest("Invalid request. Role name cannot be empty.");
            }

            var result = _departmentAndRolesServices.AddRoleToDepartment(request.DepartmentId, request.RoleName);
            if (result)
            {
                return Ok($"Role '{request.RoleName}' added to the department.");
            }
            else
            {
                return StatusCode(500, $"Failed to add role '{request.RoleName}' to the department.");
            }
        }

        [HttpGet("DisplayDepartmentsAndRoles")]
        public IActionResult DisplayDepartmentsAndRoles()
        {
            var departmentsAndRoles = _departmentAndRolesServices.GetDepartmentsAndRoles();
            if (departmentsAndRoles == null || departmentsAndRoles.Count == 0)
            {
                return NotFound("No department and roles data available.");
            }
            return Ok(departmentsAndRoles);
        }
    }
}
