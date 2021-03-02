using HR.EmployeeContext.Domain.Employees.Services;

namespace HR.EmployeeContext.Domain.Services.Employees
{
    public class NationalCodeDuplicationChecker : INationalCodeDuplicationChecker
    {
        private readonly IEmployeeRepository employeeRepository;

        public NationalCodeDuplicationChecker(IEmployeeRepository employeeRepository)
        {
            this.employeeRepository = employeeRepository;
        }
        public bool IsExist(string nationalCode)
        {
            return employeeRepository.Contains(c => c.NationalCode == nationalCode);
        }
    }
}
