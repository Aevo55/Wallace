using System;
using System.Collections.Generic;
using Wallace.Common.Models;
namespace Wallace.UI.Models
{
    public class NewProjectEditPageModel
    {
        //public string RequestId { get; set; }
        public List<Employee> employees = new List<Employee>();

        public NewProjectEditPageModel()
        {
            employees = new List<Employee>();
        }

    }
}