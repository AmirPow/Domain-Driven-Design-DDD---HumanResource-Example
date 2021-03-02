using System.Collections.Generic;
using HR.ReadModel.Queries.Contracts.Employees.DataContracts;

namespace HR.ReadModel.Queries.Contracts.Employees
{
    public interface IEmployeeQueryFacade
    {
        List<EmployeeDto> GetEmployee(string keyWord);
    }
}
