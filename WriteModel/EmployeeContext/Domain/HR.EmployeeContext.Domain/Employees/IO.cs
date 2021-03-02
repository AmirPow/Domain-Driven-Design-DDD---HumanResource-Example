using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HR.Framework.Domain;

namespace HR.EmployeeContext.Domain.Employees
{
    public class IO : EntityBase
    {
        protected IO()
        {
            
        }
        public IO(Guid employeeId ,DateTime date, string arrivalTime, string exitTime)
        {
            EmployeeId = employeeId;
            Date = date;
            ArrivalTime = arrivalTime;
            ExiTime = exitTime;
        }
        public Guid EmployeeId { get; private set; }
        public DateTime Date { get; private set; }
        public string ArrivalTime { get; private set; }
        public string ExiTime { get; private set; }
    }
}
