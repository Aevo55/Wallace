using System;
using System.Collections.Generic;
using Wallace.Common.Models;
namespace Wallace.UI.Models
{
    public class EmployeesPageModel
    {
        //public string RequestId { get; set; }
        public List<Employee> Employees = new List<Employee>();

        //public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}