using Application.DTO.Employee;
namespace Application.Interfaces
{
    public interface IEmployeeServices
    {
        bool AddEmployeeRecord(AddEmployeeDto employee);
        AddEmployeeDto FetchEmployeeByID(string employeeID);
        bool SaveUpdatedEmployeeData(string employeeId, AddEmployeeDto updatedEmployeeData);
        List<ViewEmployeeDto> GetEmployeeRecords();
        bool DeleteEmployee(string EmployeeID);
    }
}
