using System;
using System.Collections.Generic;
using System.Text;
using Wallace.Common.Models;
using System.Data.SqlClient;
using Wallace.Common.Database;
namespace Wallace.Common.Database
{
    public class DatabaseInterface
    {
        DatabaseClient client;
        public DatabaseInterface() {
            client = new DatabaseClient();
        }

        public List<Project> getProjects()
        {
            List<DBProject> dbprojects = client.getProjects();
            List<Project> projects = new List<Project>();
            foreach(DBProject p in dbprojects)
            {
                Project _p = new Project(p);
                foreach(DBVersion v in client.getVersions(p))
                {
                    PVersion _v = new PVersion(v);
                    foreach(DBSpecification s in client.getSpecs(v))
                    {
                        _v.specs.Add(new Spec(s));
                    }
                    _p.versions.Add(_v);
                }
                foreach(DBSpecification s in client.getSpecs(p))
                {
                    _p.specs.Add(new Spec(s));
                }
                projects.Add(_p);
            }
            return projects;
        }

        
    }
}
