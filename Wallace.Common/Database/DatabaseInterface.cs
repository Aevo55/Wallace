using System;
using System.Collections.Generic;
using System.Text;
using Wallace.Common.Models;
using System.Data.SqlClient;
using Wallace.Common.Database.DBModels;
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
                projects.Add(new Project(p));
            }
            return projects;
        }
    }
}
