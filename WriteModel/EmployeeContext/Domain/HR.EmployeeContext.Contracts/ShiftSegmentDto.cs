using System;
using System.Collections.Generic;
using HR.ShiftContext.Domain.Shifts;

namespace HR.EmployeeContext.Domain.Contracts
{
    public class ShiftSegmentDto
    {
        public List<ShiftSegment> ShiftSegmentsList { get; set; }
    }
}
