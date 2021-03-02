

using HR.EmployeeContext.ApplicationService.Contracts.Employees;
using HR.EmployeeContext.Domain.Employees;
using HR.EmployeeContext.Domain.Employees.Services;
using HR.Framework.Core.ApplicationService;

namespace HR.EmployeeContext.ApplicationService.Employees
{
    public class EmployeeUpdateCommandHandler :ICommandHandler<EmployeeUpdateCommand>
    {
        private readonly INationalCodeDuplicationChecker nationalCodeDuplicationChecker;
        private readonly IPersonalCodeDuplicationChecker personalCodeDuplicationChecker;

        private readonly IEmployeeRepository employeeRepository;

        public EmployeeUpdateCommandHandler(INationalCodeDuplicationChecker nationalCodeDuplicationChecker,
            IPersonalCodeDuplicationChecker personalCodeDuplicationChecker,
            IEmployeeRepository employeeRepository)
        {
            this.nationalCodeDuplicationChecker = nationalCodeDuplicationChecker;
            this.personalCodeDuplicationChecker = personalCodeDuplicationChecker;

            this.employeeRepository = employeeRepository;
        }

        public void Execute(EmployeeUpdateCommand command)
        {
            var employee = employeeRepository.GetEmployee(command.EmployeeId);
            employee.Initial(nationalCodeDuplicationChecker,personalCodeDuplicationChecker);
            employee.SetPersonalCode(command.PersonalCode);
            employee.SetNationalCode(command.NationalCode);
            employee.SetName(command.FirstName , command.LastName);
            
            employeeRepository.Update(employee);
        }
    }
}
