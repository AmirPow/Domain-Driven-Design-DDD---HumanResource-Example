

using HR.EmployeeContext.ApplicationService.Contracts.Employees;
using HR.EmployeeContext.Domain.Employees;
using HR.EmployeeContext.Domain.Employees.Services;
using HR.Framework.Core.ApplicationService;

namespace HR.EmployeeContext.ApplicationService.Employees
{
    public class EmployeeCreateCommandHandler :ICommandHandler<EmployeeCreateCommand>
    {
        private readonly INationalCodeDuplicationChecker nationalCodeDuplicationChecker;
        private readonly IPersonalCodeDuplicationChecker personalCodeDuplicationChecker;
        private readonly IEmployeeRepository employeeRepository;

        public EmployeeCreateCommandHandler(INationalCodeDuplicationChecker nationalCodeDuplicationChecker,
            IPersonalCodeDuplicationChecker personalCodeDuplicationChecker,
            IEmployeeRepository employeeRepository)
        {
            this.nationalCodeDuplicationChecker = nationalCodeDuplicationChecker;
            this.personalCodeDuplicationChecker = personalCodeDuplicationChecker;
            this.employeeRepository = employeeRepository;
        }
        public void Execute(EmployeeCreateCommand command)
        {
            
            var employee = new Employee(nationalCodeDuplicationChecker,
                personalCodeDuplicationChecker,
                command.NationalCode,
                command.PersonalCode,
                command.FirstName,
                command.LastName);
            employeeRepository.Create(employee);
        }
    }
}
