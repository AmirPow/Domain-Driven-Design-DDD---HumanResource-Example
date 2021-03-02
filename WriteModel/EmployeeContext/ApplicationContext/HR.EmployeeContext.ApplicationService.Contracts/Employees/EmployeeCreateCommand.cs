﻿using System;
using System.Collections.Generic;
using System.Text;
using HR.Framework.Core.ApplicationService;

namespace HR.EmployeeContext.ApplicationService.Contracts.Employees
{
    public class EmployeeCreateCommand :Command
    {
        public string NationalCode { get;  set; }
        public long PersonalCode { get;  set; }
        public string FirstName { get;  set; }
        public string LastName { get;  set; }
    }
}
