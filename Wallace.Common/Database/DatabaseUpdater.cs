using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using Wallace.Common.Models;

namespace Wallace.Common.Database
{
    class DatabaseUpdater
    {
        private const string updateEmpsStr = @" UPDATE
                                                    Employees
                                                SET
                                                    Title = @title,
                                                    Salary = @salary,
                                                    eName = @name
                                                WHERE
                                                    eId = @id";

        private const string updateProjStr = @" UPDATE 
                                                    Projects
                                                SET
                                                    pName = @name,
                                                    pBudget = @budget,
                                                    pDesc = @desc,
                                                    Manager = @manager
                                                WHERE
                                                    pId = @id";

        private const string updateSpecStr = @" UPDATE
                                                    Specifications
                                                SET
                                                    sName = @name,
                                                    sDesc = @desc
                                                WHERE
                                                    sId = @id";

        private const string updateTeamStr = @" UPDATE
                                                    Teams
                                                SET
                                                    tName = @name,
                                                    tDesc = @desc,
                                                    tLeader = @leader
                                                WHERE
                                                    tId = @id";

        private const string updateVerStr = @"  UPDATE
                                                    Versions
                                                SET
                                                    vNum = @num,
                                                    ReleaseDate = @date
                                                WHERE
                                                    vId = @id";

        private SqlCommand cmd;
        private SqlConnection conn;

        public DatabaseUpdater()
        {
            conn = new SqlConnection("Data Source=.;Initial Catalog=Wallace;Integrated Security=True");
        }

        public void execute(SqlCommand cmd)
        {
            try
            {
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
            }
            finally
            {
                cmd.Connection.Close();
            }
        }

        public void updateEmployee(DBEmployee e)
        {
            cmd = new SqlCommand(updateEmpsStr, conn);
            cmd.Parameters.AddWithValue("title", e.title);
            cmd.Parameters.AddWithValue("salary", e.salary);
            cmd.Parameters.AddWithValue("name", e.name);
            cmd.Parameters.AddWithValue("id", e.id);
            execute(cmd);
        }

        public void updateProject(DBProject p)
        {
            cmd = new SqlCommand(updateProjStr, conn);
            cmd.Parameters.AddWithValue("name", p.name);
            cmd.Parameters.AddWithValue("budget", p.budget);
            cmd.Parameters.AddWithValue("desc", p.desc);
            cmd.Parameters.AddWithValue("manager", p.manager);
            cmd.Parameters.AddWithValue("id", p.id);
            execute(cmd);
        }

        public void updateSpecification(DBSpecification s)
        {
            cmd = new SqlCommand(updateSpecStr, conn);
            cmd.Parameters.AddWithValue("name", s.name);
            cmd.Parameters.AddWithValue("desc", s.desc);
            cmd.Parameters.AddWithValue("id", s.id);
            execute(cmd);
        }

        public void updateTeam(DBTeam t)
        {
            cmd = new SqlCommand(updateTeamStr, conn);
            cmd.Parameters.AddWithValue("name", t.name);
            cmd.Parameters.AddWithValue("desc", t.desc);
            cmd.Parameters.AddWithValue("leader", t.leader);
            cmd.Parameters.AddWithValue("id", t.id);
            execute(cmd);
        }

        public void updateVersion(DBVersion v)
        {
            cmd = new SqlCommand(updateVerStr, conn);
            cmd.Parameters.AddWithValue("num", v.vnum);
            cmd.Parameters.AddWithValue("date", v.release);
            cmd.Parameters.AddWithValue("id", v.id);
            execute(cmd);
        }
    }
}
