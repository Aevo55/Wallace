using System;
using System.Collections.Generic;
using System.Text;

namespace Wallace.Common.Models
{
    public class Employee
    {
        public String name;
        public int phone;
        public int salary;
        public int id;

        public Employee(string _name, int _phone, int _salary, int _id)
        {
            name = _name;
            phone = _phone;
            salary = _salary;
            id = _id;
        }



    }

    
}
