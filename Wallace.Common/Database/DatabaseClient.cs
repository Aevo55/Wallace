using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using Wallace.Common.Models;
namespace Wallace.Common.Database
{
    
    public class DatabaseClient
    {
        private const string getProjectsQuery = @"  SeLeCt
                                                        *
                                                    FrOm
                                                        Projects";
        private const string getVersionsString = @" SeLeCt
                                                        *
                                                    FrOm
                                                        Versions
                                                    WhErE
                                                        pid = @pid";
        
        private SqlCommand cmd;
        private SqlConnection conn;

        public DatabaseClient()
        {
            conn = new SqlConnection("Data Source=.;Initial Catalog=Wallace;Integrated Security=True");
        }

        public List<DBProject> getProjects(){
            List<DBProject> projects = new List<DBProject>();
            cmd = new SqlCommand(getProjectsQuery, conn);
            try
            {
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    DBProject currProject = new DBProject();
                    currProject.id = !reader.IsDBNull(0) ? reader.GetInt32(0) : -1;
                    currProject.name = !reader.IsDBNull(1) ? reader.GetString(1) : "";
                    currProject.budget = !reader.IsDBNull(2) ? reader.GetInt32(2) : 0;
                    currProject.desc = !reader.IsDBNull(3) ? reader.GetString(3) : "";
                    currProject.manager = !reader.IsDBNull(4) ? reader.GetInt32(4) : -1;
                    
                    projects.Add(currProject);
                }
                reader.Close();
            }
            finally
            {
                conn.Close();
            }
            return projects;
        }

        public List<DBVersion> getVersions(DBProject p)
        {
            int id = p.id;
            List<DBVersion> versions = new List<DBVersion>();
            cmd = new SqlCommand(getVersionsString, conn);
            try
            {
                conn.Open();
                cmd.Parameters.AddWithValue("@pid", id);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    DBVersion currVersion = new DBVersion();
                    currVersion.id = !reader.IsDBNull(0) ? reader.GetInt32(0) : -1;
                    currVersion.vnum = !reader.IsDBNull(2) ? reader.GetInt32(2) : -1;
                    currVersion.release = !reader.IsDBNull(3) ? reader.GetDateTime(3) : DateTime.UtcNow;

                    versions.Add(currVersion);
                }
            }
            finally
            {
                conn.Close();
            }

            return versions;
        }
    }
}
