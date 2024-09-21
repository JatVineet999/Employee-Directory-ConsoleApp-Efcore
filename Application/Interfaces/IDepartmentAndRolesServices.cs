using Application.DTO.DepartmentAndRoles;

namespace Application.Interfaces
{
    public interface IDepartmentAndRolesServices
    {
        bool AddRoleToDepartment(int departmentId, string newRole);
        List<ViewDepartmentAndRolesDto> GetDepartmentsAndRoles();
    }
}
