using Infrastructure.Models;
using Application.DTO.Employee;
using Application.Interfaces;
using Infrastructure.Interfaces;
using AutoMapper;
namespace Application.Services
{
    public class EmployeeServices : IEmployeeServices
    {
        private readonly IEmployeeRepo _employeeRepo;
        private readonly IMapper _mapper;

        public EmployeeServices(IEmployeeRepo employeeRepo, IMapper mapper)
        {
            _employeeRepo = employeeRepo;
            _mapper = mapper;
        }
        private string GenerateEmployeeID()
        {
            Random rand = new Random();
            return $"TZ{rand.Next(1000, 10000)}";
        }

        public bool AddEmployeeRecord(AddEmployeeDto employeeDto)
        {
            var employee = _mapper.Map<Employee>(employeeDto);
            employee.EmployeeID = GenerateEmployeeID();
            bool isAdded = _employeeRepo.SaveEmployeeRecord(employee);
            return isAdded;
        }

        public AddEmployeeDto FetchEmployeeByID(string employeeID)
        {
            var employee = _employeeRepo.GetEmployeeByEmployeeID(employeeID);
            var employeeDto = _mapper.Map<AddEmployeeDto>(employee);
            return employeeDto;
        }


        public bool SaveUpdatedEmployeeData(string employeeId, AddEmployeeDto updatedEmployeeData)
        {
            try
            {
                var employeeToUpdate = _mapper.Map<Employee>(updatedEmployeeData);

                employeeToUpdate.EmployeeID = employeeId;
                return _employeeRepo.UpdateEmployee(employeeToUpdate);
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while updating the employee record.", ex);
            }
        }


        public List<ViewEmployeeDto> GetEmployeeRecords()
        {
            var employees = _employeeRepo.LoadEmployeeRecords();
            var employeeDtos = _mapper.Map<List<ViewEmployeeDto>>(employees);

            return employeeDtos;
        }

        public bool DeleteEmployee(string EmployeeID)
        {
            return _employeeRepo.RemoveEmployee(EmployeeID);
        }
    }
}
