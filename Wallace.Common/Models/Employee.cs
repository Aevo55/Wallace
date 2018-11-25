using System;
using System.Collections.Generic;
using System.Text;
using Wallace.Common.Database;

namespace Wallace.Common.Models
{
    public class Employee
    {
        public String name;
        public int salary;
        public int phone;
        public int id;
        public List<Team> teams;

        public Employee(string _name, int _phone, int _salary, int _id)
        {
            name = _name;
            phone = _phone;
            salary = _salary;
            id = _id;
            teams = new List<Team>();
        }

        public Employee(DBEmployee e)
        {
            name = e.name;
            salary = e.salary;
            id = e.id;
            teams = new List<Team>();
        }
    }
}
