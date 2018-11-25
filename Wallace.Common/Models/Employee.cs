﻿using System;
using System.Collections.Generic;
using System.Text;
using Wallace.Common.Database;

namespace Wallace.Common.Models
{
    public class Employee
    {
        public String name;
        public int salary;
        public string title;
        public int id;
        public List<Team> teams;

        public Employee(string _name, string _title, int _salary, int _id)
        {
            name = _name;
            title = _title;
            salary = _salary;
            id = _id;
            teams = new List<Team>();
        }

        public Employee(DBEmployee e)
        {
            name = e.name;
            salary = e.salary;
            title = e.title;
            id = e.id;
            teams = new List<Team>();
        }
    }
}
