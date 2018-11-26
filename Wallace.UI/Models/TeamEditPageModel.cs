using System;
using System.Collections.Generic;
using Wallace.Common.Models;
namespace Wallace.UI.Models
{
    public class TeamEditPageModel
    {

        public List<Employee> employees = new List<Employee>();
        public Team team= new Team();
        public bool isNew = false;

    }
}