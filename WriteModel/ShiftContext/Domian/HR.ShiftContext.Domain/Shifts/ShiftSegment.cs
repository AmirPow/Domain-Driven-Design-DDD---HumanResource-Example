using HR.Framework.Domain;
using HR.ShiftContext.Domain.Shifts.Exceptions;
using System;
using System.Linq;

namespace HR.ShiftContext.Domain.Shifts
{
    public class ShiftSegment : EntityBase
    {
        protected ShiftSegment(){}
        public ShiftSegment(Guid shiftId,int index, string startTime, string endTime)
        {
            ShiftId = shiftId;
            SetTime(startTime, endTime);
            SetIndex(index);
        }

        public Guid ShiftId { get; private set; }
        public int Index { get; private set; }
        public string StartTime { get; private set; }
        public string EndTime { get; private set; }

        public void SetTime(in string startTime, in string endTime)
        {
            StartTime = startTime;
            EndTime = endTime;
        }

        private void SetIndex(in int index)
        {
            if (index<=0)
                throw new IndexMustMoreThanZeroExceptions();

            if(index.ToString().Any(i=>!char.IsDigit(i)))
                throw new IndexShouldBeNumberExceptions();

            Index = index;
        }

    }
}
