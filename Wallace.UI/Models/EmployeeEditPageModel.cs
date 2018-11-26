using System;
using System.Collections.Generic;
using Wallace.Common.Models;
namespace Wallace.UI.Models
{
    public class EmployeeEditPageModel
    {
        //public string RequestId { get; set; }
        public Employee employee = new Employee();
        public bool isNew = false;
        //public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}