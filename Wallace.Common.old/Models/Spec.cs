using System;
using System.Collections.Generic;
using System.Text;

namespace Wallace.Common.Models
{
    public class Spec
    {

        public int id;
        public string name;
        public string description;

        public Spec(int _id, string _name, string _description)
        {
            id = _id;
            name = _name;
            description = _description;
        }

    }
}
