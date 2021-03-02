using System;
using HR.Framework.Core.ApplicationService;

namespace HR.ShiftContext.ApplicationService.Contracts.Shifts
{
    public class ShiftSegmentAddCommand : Command
    {
        public Guid ShiftId { get; set; }
        public int Index { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }

    }
}
