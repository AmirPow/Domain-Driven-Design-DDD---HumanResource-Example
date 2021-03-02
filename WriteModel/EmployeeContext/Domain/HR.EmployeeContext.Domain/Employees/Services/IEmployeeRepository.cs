using System;
using System.Linq.Expressions;
using HR.Framework.Core.Persistence;

namespace HR.EmployeeContext.Domain.Employees.Services
{
    public interface IEmployeeRepository : IRepository
    {
        void Create(Employee employee);
        Employee GetEmployee(Guid employeeId);
        void Update(Employee employee);
        bool Contains(Expression<Func<Employee, bool>> predicate);
        void Remove(Employee employee);
    }
}
