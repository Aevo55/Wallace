using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using Wallace.Common.Models;
using Wallace.Common.Database.DBModels;
namespace Wallace.Common.Database
{
    
    public class DatabaseClient
    {
        private string query;
        private SqlCommand cmd;
        private SqlConnection conn;
        public DatabaseClient()
        {
            conn = new SqlConnection("Data Source=.;Initial Catalog=Wallace;Integrated Security=True");
        }
        //"Data Source=SEAN-LAPTOP;Initial Catalog=Wallace;Integrated Security=True"
        //"Data Source=DESKTOP-IO1PN0S;Initial Catalog=Wallace;Integrated Security=True"
        public List<DBProject> getProjects(){
            List<DBProject> projects = new List<DBProject>();
            query = @"  SELECT
                            *
                        FROM
                            Projects";
            cmd = new SqlCommand(query, conn);
            try
            {
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    DBProject currProject = new DBProject();
                    currProject.pid = !reader.IsDBNull(0) ? reader.GetInt32(0) : -1;
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
    }
}
