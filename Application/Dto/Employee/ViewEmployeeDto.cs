namespace Application.DTO.Employee
{
    public class ViewEmployeeDto : EmployeeDto
    {
        public string? EmployeeID { get; set; }
        public string? JobTitle { get; set; }
        public string? DepartmentName { get; set; }

    }
}
