﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using Wallace.Common.Models;
namespace Wallace.Common.Database
{
    
    public class DatabaseReader
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
                                                                vId = @vid)";

        private const string getSpecsString = @"    SELECT
                                                        *
                                                    FROM
                                                        Specifications
                                                    WHERE
                                                        pId = @pid";

        private const string getAllTeamsString = @" SELECT
                                                        *
                                                    FROM
                                                        Teams";

        private const string getTeamsByEmpStr = @"  SELECT
                                                        *
                                                    FROM
                                                        Teams
                                                    WHERE
                                                        tId IN (
                                                            SELECT
                                                                tId
                                                            FROM
                                                                TeamMembers
                                                            WHERE
                                                                eId = @eid)";

        private const string getAllEmpsString = @"  SELECT
                                                        *
                                                    FROM
                                                        Employees";

        private const string getEmpsByTeamStr = @"  SELECT
                                                        *
                                                    FROM
                                                        Employees
                                                    WHERE
                                                        eId IN (
                                                            SELECT
                                                                eId
                                                            FROM
                                                                TeamMembers
                                                            WHERE
                                                                tId = @tid)";

        private const string getEmployeeStr = @"SELECT
                                                    *
                                                FROM
                                                    Employees
                                                WHERE
                                                    eId = @eId";

        private const string getVersionTeamsStr = @"SELECT
                                                        *
                                                    FROM
                                                        Teams
                                                    WHERE
                                                        tId IN (
                                                            SELECT
                                                                tId
                                                            FROM    
                                                                VersionTeams
                                                            WHERE
                                                                vId = @vid)";

        private SqlCommand cmd;
        private SqlConnection conn;

        public DatabaseReader()
        {
            conn = new SqlConnection("Data Source=.;Initial Catalog=Wallace;Integrated Security=True");
        }

        public List<DBProject> getAllProjects(){
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

        public List<DBVersion> getVersionsByProj(int p)
        {
            int id = p;
            List<DBVersion> versions = new List<DBVersion>();
            cmd = new SqlCommand(getVersionsString, conn);
            try
            {
                conn.Open();
                cmd.Parameters.AddWithValue("pid", id);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    DBVersion currVersion = new DBVersion();
                    currVersion.id = !reader.IsDBNull(0) ? reader.GetInt32(0) : -1;
                    currVersion.pid = !reader.IsDBNull(1) ? reader.GetInt32(1) : -1;
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

        public List<DBSpecification> getSpecsByVer(int v)
        {
            int id = v;
            List<DBSpecification> specs = new List<DBSpecification>();
            cmd = new SqlCommand(getVerSpecsString, conn);
            try
            {
                conn.Open();
                cmd.Parameters.AddWithValue("vid", id);
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

        public List<DBSpecification> getSpecsByProj(int p)
        {
            int id = p;
            List<DBSpecification> specs = new List<DBSpecification>();
            cmd = new SqlCommand(getSpecsString, conn);
            try
            {
                conn.Open();
                cmd.Parameters.AddWithValue("pid", id);
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

        public List<DBTeam> getAllTeams()
        {
            List<DBTeam> teams = new List<DBTeam>();
            cmd = new SqlCommand(getAllTeamsString, conn);
            try
            {
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    DBTeam currTeam = new DBTeam();
                    currTeam.id = !reader.IsDBNull(0) ? reader.GetInt32(0) : -1;
                    currTeam.name = !reader.IsDBNull(1) ? reader.GetString(1) : "";
                    currTeam.desc = !reader.IsDBNull(2) ? reader.GetString(2) : "";
                    currTeam.leader = !reader.IsDBNull(3) ? reader.GetInt32(3) : -1;

                    teams.Add(currTeam);
                }
            }
            finally
            {
                conn.Close();
            }
            return teams;
        }
        
        public List<DBTeam> getTeamsByEmp(int e)
        {
            List<DBTeam> teams = new List<DBTeam>();
            cmd = new SqlCommand(getTeamsByEmpStr, conn);
            cmd.Parameters.AddWithValue("eid", e);
            try
            {
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    DBTeam currTeam = new DBTeam();
                    currTeam.id = !reader.IsDBNull(0) ? reader.GetInt32(0) : -1;
                    currTeam.name = !reader.IsDBNull(1) ? reader.GetString(1) : "";
                    currTeam.desc = !reader.IsDBNull(2) ? reader.GetString(2) : "";
                    currTeam.leader = !reader.IsDBNull(3) ? reader.GetInt32(3) : -1;

                    teams.Add(currTeam);
                }
            }
            finally
            {
                conn.Close();
            }
            return teams;
        }

        public List<DBEmployee> getAllEmployees()
        {
            List<DBEmployee> employees = new List<DBEmployee>();
            cmd = new SqlCommand(getAllEmpsString, conn);
            try
            {
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    DBEmployee currEmp = new DBEmployee();
                    currEmp.id = !reader.IsDBNull(0) ? reader.GetInt32(0) : -1;
                    currEmp.title = !reader.IsDBNull(1) ? reader.GetString(1) : "";
                    currEmp.salary = !reader.IsDBNull(2) ? reader.GetInt32(2) : -1;
                    currEmp.name = !reader.IsDBNull(3) ? reader.GetString(3) : "";

                    employees.Add(currEmp);
                }
            }
            finally
            {
                conn.Close();
            }
            return employees;
        }

        public List<DBEmployee> getEmpsByTeam(int t)
        {
            List<DBEmployee> employees = new List<DBEmployee>();
            cmd = new SqlCommand(getEmpsByTeamStr, conn);
            cmd.Parameters.AddWithValue("tid", t);
            try
            {
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    DBEmployee currEmp = new DBEmployee();
                    currEmp.id = !reader.IsDBNull(0) ? reader.GetInt32(0) : -1;
                    currEmp.title = !reader.IsDBNull(1) ? reader.GetString(1) : "";
                    currEmp.salary = !reader.IsDBNull(2) ? reader.GetInt32(2) : -1;
                    currEmp.name = !reader.IsDBNull(3) ? reader.GetString(3) : "";

                    employees.Add(currEmp);
                }
            }
            finally
            {
                conn.Close();
            }
            return employees;
        }

        public DBEmployee getEmployee(int e)
        {
            cmd = new SqlCommand(getEmployeeStr, conn);
            DBEmployee employee = new DBEmployee();
            cmd.Parameters.AddWithValue("eid", e);
            try
            {
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    employee.id = !reader.IsDBNull(0) ? reader.GetInt32(0) : -1;
                    employee.title = !reader.IsDBNull(1) ? reader.GetString(1) : "";
                    employee.salary = !reader.IsDBNull(2) ? reader.GetInt32(2) : -1;
                    employee.name = !reader.IsDBNull(3) ? reader.GetString(3) : "";
                }
            }
            finally
            {
                conn.Close();
            }
            return employee;
        }

        public List<DBTeam> getTeamsByVersion(int v)
        {
            List<DBTeam> teams = new List<DBTeam>();
            cmd = new SqlCommand(getVersionTeamsStr, conn);
            cmd.Parameters.AddWithValue("vid", v);
            try
            {
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    DBTeam currTeam = new DBTeam();
                    currTeam.id = !reader.IsDBNull(0) ? reader.GetInt32(0) : -1;
                    currTeam.name = !reader.IsDBNull(1) ? reader.GetString(1) : "";
                    currTeam.desc = !reader.IsDBNull(2) ? reader.GetString(2) : "";

                    teams.Add(currTeam);
                }
            }
            finally
            {
                conn.Close();
            }
            return teams;
        }
    }
}
