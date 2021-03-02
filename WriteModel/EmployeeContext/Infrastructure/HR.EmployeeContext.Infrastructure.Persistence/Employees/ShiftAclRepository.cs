using System;
using System.Linq;
using HR.EmployeeContext.Domain.Contracts;
using HR.EmployeeContext.Domain.Employees.Services;
using HR.ShiftContext.Domain.Shifts.Services;

namespace HR.EmployeeContext.Infrastructure.Persistence.Employees
{
    public class ShiftAclRepository : IShiftAcl
    {
        private readonly IShiftRepository shiftRepository;

        public ShiftAclRepository(IShiftRepository shiftRepository)
        {
            this.shiftRepository = shiftRepository;
        }

        public ShiftSegmentDto GetShiftSegmentDto(Guid shiftId)
        {
            var shift = shiftRepository.GetShift(shiftId);
            var shiftSegmentsList = shift.ShiftSegments.Where(s => s.ShiftId == shiftId).ToList();
            var shiftSegmentDto = new ShiftSegmentDto
            {
                ShiftSegmentsList = shiftSegmentsList
            };
            return shiftSegmentDto;
        }
    }
}
