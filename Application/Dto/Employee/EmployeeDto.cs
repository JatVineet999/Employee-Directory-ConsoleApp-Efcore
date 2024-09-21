using System.ComponentModel.DataAnnotations;
using Application.Utility;

namespace Application.DTO.Employee
{
    public class EmployeeDto
    {
        [Required(ErrorMessage = "First name is required")]
        [StringLength(30, ErrorMessage = "First name must be between 1 and 30 characters", MinimumLength = 1)]
        [RegularExpression(@"^[A-Za-z\s]+$", ErrorMessage = "First name can only contain alphabetical characters")]
        public string? FirstName { get; set; }

        [Required(ErrorMessage = "Last name is required")]
        [StringLength(50, ErrorMessage = "Last name must be between 1 and 50 characters", MinimumLength = 1)]
        [RegularExpression(@"^[A-Za-z\s]+$", ErrorMessage = "Last name can only contain alphabetical characters")]
        public string? LastName { get; set; }

        [Required(ErrorMessage = "Joining date is required")]
        [DataType(DataType.Date, ErrorMessage = "Invalid date format")]
        [DateNotGreaterThanCurrent(ErrorMessage = "Date cannot be greater than the current date")]
        public DateTime JoiningDate { get; set; }

        [Required(ErrorMessage = "Location is required")]
        [StringLength(50, ErrorMessage = "Location must be between 1 and 50 characters", MinimumLength = 1)]
        public string? Location { get; set; }

        [StringLength(50, ErrorMessage = "Manager name must be between 1 and 50 characters", MinimumLength = 1)]
        [RegularExpression(@"^[A-Za-z\s]+$", ErrorMessage = "Manager name can only contain alphabetical characters")]
        public string? ManagerName { get; set; }

        [StringLength(50, ErrorMessage = "Project name must be between 1 and 50 characters", MinimumLength = 1)]
        [RegularExpression(@"^[A-Za-z\s]+$", ErrorMessage = "Project name can only contain alphabetical characters")]
        public string? ProjectName { get; set; }

    }
}
