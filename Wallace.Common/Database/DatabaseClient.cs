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

        private const string getVerSpecsString = @" SELECT
                                                        *
                                                    FROM
                                                        Specifications
                                                    WHERE
                                                        sId IN (
                                                            SELECT
                                                                sId
                                                            FROM
                                                                VersionSpecs
                                                            WHERE
                                                                vId = @vId)";

        private const string getSpecsString = @"    SELECT
                                                        *
                                                    FROM
                                                        Specifications
                                                    WHERE
                                                        sId = @pId";


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

        public List<DBSpecification> getSpecs(DBVersion v)
        {
            int id = v.id;
            List<DBSpecification> specs = new List<DBSpecification>();
            cmd = new SqlCommand(getVerSpecsString, conn);
            try
            {
                conn.Open();
                cmd.Parameters.AddWithValue("vId", id);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    DBSpecification currSpec = new DBSpecification();
                    currSpec.id = !reader.IsDBNull(0) ? reader.GetInt32(0) : -1;
                    currSpec.name = !reader.IsDBNull(1) ? reader.GetString(1) : "";
                    currSpec.desc = !reader.IsDBNull(2) ? reader.GetString(2) : "";
                    currSpec.pid = !reader.IsDBNull(3) ? reader.GetInt32(3) : -1;
                    specs.Add(currSpec);
                }
            }
            finally
            {
                conn.Close();
            }
            return specs;
        }

        public List<DBSpecification> getSpecs(DBProject p)
        {
            int id = p.id;
            List<DBSpecification> specs = new List<DBSpecification>();
            cmd = new SqlCommand(getSpecsString, conn);
            try
            {
                conn.Open();
                cmd.Parameters.AddWithValue("pId", id);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    DBSpecification currSpec = new DBSpecification();
                    currSpec.id = !reader.IsDBNull(0) ? reader.GetInt32(0) : -1;
                    currSpec.name = !reader.IsDBNull(1) ? reader.GetString(1) : "";
                    currSpec.desc = !reader.IsDBNull(2) ? reader.GetString(2) : "";
                    currSpec.pid = !reader.IsDBNull(3) ? reader.GetInt32(3) : -1;
                    specs.Add(currSpec);
                }
            }
            finally
            {
                conn.Close();
            }
            return specs;
        }
    }
}
