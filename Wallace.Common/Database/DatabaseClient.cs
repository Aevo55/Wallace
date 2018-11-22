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
                    DBProject currProject = new DBProject(
                        Convert.ToInt32(reader["pId"]),
                        Convert.ToString(reader["pName"]),
                        Convert.ToInt32(reader["pBudget"]),
                        Convert.ToString(reader["pDesc"]),
                        Convert.ToInt32(reader["Manager"])
                        );
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
