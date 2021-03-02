using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HR.Framework.Core.ApplicationService;

namespace HR.EmployeeContext.ApplicationService.Contracts.Employees
{
    public class EmployeeIOCommand :Command
    {
        public Guid EmployeeId { get; set; }
        public DateTime Date { get;  set; }
        public string ArrivalTime { get; set; }
        public string ExiTime { get; set; }
    }
}
