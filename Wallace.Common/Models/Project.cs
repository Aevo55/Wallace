using System;
using System.Collections.Generic;
using System.Text;
using Wallace.Common.Database;

namespace Wallace.Common.Models
{
   public class Project
    {

        public List<PVersion> versions;
        public List<Spec> specs;
        public string name;
        public int budget;
        public int id;
        public string desc;
        public Employee manager;

        public Project(DBProject project)
        {
            name = project.name;
            id = project.id;
            budget = project.budget;
            desc = project.desc;
            versions = new List<PVersion>();
            specs = new List<Spec>();
        }
        public Project(List<PVersion> _versions, List<Spec> _specs, string _name, int _budget, int _id, Employee _manager)
        {
            versions = new List<PVersion>();
            versions = _versions;
            specs = new List<Spec>();
            specs = _specs;
            name = _name;
            budget = _budget;
            id = _id;
            manager = _manager;
        }


    }
}
