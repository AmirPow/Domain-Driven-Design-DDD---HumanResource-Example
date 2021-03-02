using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HR.Framework.Domain;

namespace HR.EmployeeContext.Domain.Employees
{
    public class Contract : EntityBase
    {
        public Contract(Guid employeeId, DateTime startDate,DateTime endDate)
        {
            SetDate(startDate,endDate);
            EmployeeId = employeeId;
        }

        public Guid EmployeeId { get; private set; }
        public DateTime StartDate { get; private set; }
        public DateTime EndDate { get; private set; }

        public void SetDate(in DateTime startDate, in DateTime endDate)
        {
            if (startDate > endDate)
                throw new Exception();
            StartDate = startDate;
            EndDate = endDate;
        }
        

    }
}
