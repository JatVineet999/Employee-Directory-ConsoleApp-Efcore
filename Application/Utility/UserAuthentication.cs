using Infrastructure.Interfaces;
using Application.Interfaces;

namespace Application.Utility
{
    public class UserAuthentication(IEmployeeRepo employeeRepo): IUserAuthentication
    {
        private readonly IEmployeeRepo _employeeRepo = employeeRepo;

        public bool VerifyEmployeeCredentials(string employeeId, string email)
        {
            var employee = _employeeRepo.GetEmployeeByEmployeeID(employeeId);
            if (employee != null && string.Equals(email, employee.Email, StringComparison.OrdinalIgnoreCase))
            {
                return true;
            }
            return false;
        }
    }
}