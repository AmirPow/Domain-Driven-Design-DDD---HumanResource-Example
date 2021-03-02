using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using HR.Framework.Core.Domain;
using HR.Framework.Domain;
using HR.ShiftContext.Domain.Shifts.Exceptions;

namespace HR.ShiftContext.Domain.Shifts
{
    public class Shift : EntityBase, IAggregateRoot<Shift>
    {
        public Shift(string shiftTitle)
        {
            SetShiftTitle(shiftTitle);
        }

        protected Shift()
        {
        }

        public string ShiftTitle { get; set; }
        public ICollection<ShiftSegment> ShiftSegments { get; private set; }=new HashSet<ShiftSegment>();

        public void AddShiftSegment(ShiftSegment shiftSegment , List<ShiftSegment> currentShiftSegmentList)
        {
            if (currentShiftSegmentList.Any(c => c.Index == shiftSegment.Index))
                throw new ShiftSegmentIndexCanNotBeDuplicateExceptions();
            ShiftSegments.Add(shiftSegment);
        }

        public void RemoveShiftSegment(ShiftSegment shiftSegment)
        {
            ShiftSegments.Remove(shiftSegment);
        }

        public IEnumerable<Expression<Func<Shift, dynamic>>> GetAggregateExpression()
        {
            yield return s => s.ShiftSegments;
        }

        public void SetShiftTitle(string shiftTitle)
        {
            if (string.IsNullOrWhiteSpace(shiftTitle))
            {
                throw new ShiftTitleMustNotBeEmptyOrWhiteSpaceExceptions();
            }
            ShiftTitle = shiftTitle;
        }


    }
}
