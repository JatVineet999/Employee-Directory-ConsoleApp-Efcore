using System;
using System.ComponentModel.DataAnnotations;
using Application.Utility;

namespace Application.DTO.Employee
{
    public class AddEmployeeDto : EmployeeDto
    {
        [Required(ErrorMessage = "Role ID is required")]
        public int RoleID { get; set; }

        [Required(ErrorMessage = "Department ID is required")]
        public int DepartmentID { get; set; }

        [Required(ErrorMessage = "Mobile number is required")]
        [RegularExpression(@"^[0-9]{10}$", ErrorMessage = "Mobile number must be exactly 10 digits long and can only contain numeric values")]
        public long? MobileNumber { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email format")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Date of birth is required")]
        [DataType(DataType.Date, ErrorMessage = "Invalid date format")]
        [DateNotGreaterThanCurrent(ErrorMessage = "Date of birth cannot be greater than the current date")]
        public DateTime DateOfBirth { get; set; }
    }
}
