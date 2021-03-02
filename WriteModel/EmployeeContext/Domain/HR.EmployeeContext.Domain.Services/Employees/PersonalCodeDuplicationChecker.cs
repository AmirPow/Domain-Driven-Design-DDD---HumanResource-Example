using HR.EmployeeContext.Domain.Employees.Services;

namespace HR.EmployeeContext.Domain.Services.Employees
{
    public class PersonalCodeDuplicationChecker  : IPersonalCodeDuplicationChecker
    {
        private readonly IEmployeeRepository employeeRepository;

        public PersonalCodeDuplicationChecker(IEmployeeRepository employeeRepository)
        {
            this.employeeRepository = employeeRepository;
        }
        public bool IsExist(long personalCode)
        {
            return employeeRepository.Contains(c => c.PersonalCode == personalCode);
        }
    }
}
