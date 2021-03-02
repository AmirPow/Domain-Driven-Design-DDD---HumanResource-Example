using System;
using HR.Framework.Domain;

namespace HR.EmployeeContext.Domain.Employees
{
    public class AssignShift : EntityBase
    {
        public AssignShift(int index, Guid employeeId ,Guid shiftId , DateTime startDate)
        {
            Index = index;
            EmployeeId = employeeId;
            ShiftId = shiftId;
            ValidateStartDate(startDate);
        }

        private void ValidateStartDate(in DateTime startDate)
        {
            StartDate = startDate;
        }

        public int Index { get;private set; }
        public Guid EmployeeId { get; private set; }
        public Guid ShiftId { get;private set; }
        public DateTime StartDate { get;private set; }
        
    }
}
