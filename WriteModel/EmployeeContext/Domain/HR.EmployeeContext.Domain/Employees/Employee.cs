using System;
using System.Collections.Generic;
using System.Linq;
using HR.EmployeeContext.Domain.Contracts;
using HR.EmployeeContext.Domain.Employees.Exceptions;
using HR.EmployeeContext.Domain.Employees.Services;
using HR.Framework.Core.Domain;
using HR.Framework.Domain;
using Exception = System.Exception;

namespace HR.EmployeeContext.Domain.Employees
{
    public class Employee : EntityBase, IAggregateRoot<Employee>
    {
        private INationalCodeDuplicationChecker nationalCodeDuplicationChecker;
        private IPersonalCodeDuplicationChecker personalCodeDuplicationChecker;

        public Employee(
            INationalCodeDuplicationChecker nationalCodeDuplicationChecker,
            IPersonalCodeDuplicationChecker personalCodeDuplicationChecker,
            string nationalCode,
            long personalCode,
            string firstName,
            string lastName)
        {
            this.nationalCodeDuplicationChecker = nationalCodeDuplicationChecker;
            this.personalCodeDuplicationChecker = personalCodeDuplicationChecker;
            SetNationalCode(nationalCode);
            SetPersonalCode(personalCode);
            SetName(firstName, lastName);
        }

        protected Employee()
        {

        }

        public string NationalCode { get; private set; }
        public long PersonalCode { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public ICollection<Contract> Contracts { get; private set; } = new HashSet<Contract>();
        public ICollection<AssignShift> AssignShifts { get; private set; } = new HashSet<AssignShift>();
        public ICollection<IO> Ios { get; private set; } = new HashSet<IO>();

        public void AddAssignShift(AssignShift assignShift)
        {
            AssignShifts.Add(assignShift);
        }


        public void AddIo(IO io, ShiftSegmentDto shiftSegmentDto, AssignShift assignShift)
        {
            var assignedSegment = shiftSegmentDto.ShiftSegmentsList.Single(s => s.Index == assignShift.Index);
            var dateDiff = (io.Date - assignShift.StartDate).Days;
            var mod = (dateDiff + assignedSegment.Index) % shiftSegmentDto.ShiftSegmentsList.Count;
            if (mod == 0)
                mod = shiftSegmentDto.ShiftSegmentsList.Count;


            if ((Convert.ToDecimal(shiftSegmentDto.ShiftSegmentsList[mod].StartTime.Replace(":", "")) +
                    Convert.ToDecimal(shiftSegmentDto.ShiftSegmentsList[mod].EndTime.Replace(":", "")) == 0)
                ||
                (Convert.ToDecimal(shiftSegmentDto.ShiftSegmentsList[mod].StartTime.Replace(":", "")) >
                Convert.ToDecimal(io.ArrivalTime.Replace(":", "")) 
                &&
                Convert.ToDecimal(shiftSegmentDto.ShiftSegmentsList[mod].EndTime.Replace(":", "")) <
                Convert.ToDecimal(io.ExiTime.Replace(":", ""))))

                throw new EnteredTimeIsNotInSegmentInside();

            Ios.Add(io);
        }


        public void AddContract(Contract contract)
        {

            Contracts.Add(contract);
        }
        public void RemoveContract(Contract contract)
        {
            Contracts.Remove(contract);
        }

        public void Initial(INationalCodeDuplicationChecker nationalCodeDuplicationChecker, IPersonalCodeDuplicationChecker personalCodeDuplicationChecker)
        {
            this.personalCodeDuplicationChecker = personalCodeDuplicationChecker;
            this.nationalCodeDuplicationChecker = nationalCodeDuplicationChecker;
        }

        public void SetNationalCode(string nationalCode)
        {
            if (string.IsNullOrWhiteSpace(nationalCode))
                throw new NationalCodeIsRequiredException();
            if (nationalCode.Length != 10)
                throw new NationalCodeLengthIsNotValidException();
            if (!nationalCode.Any(char.IsDigit))
                throw new NationalCodeMustBeDigitException();
            if (nationalCodeDuplicationChecker.IsExist(nationalCode))
                throw new NationalCodeMustBeUniqueException();

            NationalCode = nationalCode;

        }


        public void SetPersonalCode(long personalCode)
        {
            if (string.IsNullOrWhiteSpace(personalCode.ToString()))
                throw new PersonalCodeIsRequiredException();

            if (personalCodeDuplicationChecker.IsExist(personalCode))
                throw new Exception();

            PersonalCode = personalCode;
        }

        public void SetName(string firstName, string lastName)
        {
            if (string.IsNullOrWhiteSpace(firstName))
                throw new FirstNameIsRequiredException();


            if (string.IsNullOrWhiteSpace(lastName))
                throw new LastNameIsRequiredException();

            FirstName = firstName;
            LastName = lastName;

        }
    }
}
