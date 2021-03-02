using System;
using HR.Framework.Core.ApplicationService;

namespace HR.ShiftContext.ApplicationService.Contracts.Shifts
{
    public class ShiftSegmentUpdateCommand : Command
    {
        public Guid ShiftId { get; set; }
        public Guid SegmentId { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }


    }
}
