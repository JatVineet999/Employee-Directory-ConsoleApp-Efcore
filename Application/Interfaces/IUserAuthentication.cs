namespace Application.Interfaces
{
    public interface IUserAuthentication
    {

        bool VerifyEmployeeCredentials(string employeeId, string email);
    }
}