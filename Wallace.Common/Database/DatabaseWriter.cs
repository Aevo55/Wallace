using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using Wallace.Common.Models;

namespace Wallace.Common.Database
{
    class DatabaseWriter
    {
        private const string insertEmpStr = @"  INSERT INTO
                                                    Employees(
                                                        Title,
                                                        Salary,
                                                        eName)
                                                VALUES(
                                                    @title,
                                                    @salary,
                                                    @name)";

        private const string insertProjStr = @" INSERT INTO
                                                    Projects(
                                                        pName,
                                                        pBudget,
                                                        pDesc)
                                                VALUES(
                                                    @name,
                                                    @budget,
                                                    @desc)";

        private const string insertSpecStr = @" INSERT INTO
                                                    Specifications(
                                                        sName,
                                                        sDesc,
                                                        pId)
                                                VALUES(
                                                    @name,
                                                    @desc,
                                                    @pid)";

        private const string insertTeamMemStr = @"INSERT INTO
                                                    TeamMembers
                                                VALUES(
                                                    @eid,
                                                    @tid)";

        private const string insertTeamStr = @" INSERT INTO
                                                    Teams(
                                                        tName,
                                                        tDesc,
                                                        tLeader)
                                                VALUES(
                                                    @name,
                                                    @desc,
                                                    @leader)";

        private const string insertVerStr = @"  INSERT INTO
                                                    Versions(
                                                        pId,
                                                        vNum,
                                                        ReleaseDate)
                                                VALUES(
                                                    @pid,
                                                    @num,
                                                    @date)";

        private const string insertVerSpecStr = @"INSERT INTO
                                                    VersionSpecs
                                                VALUES(
                                                    @vid,
                                                    @sid)";

        private const string insertVerTeamStr = @"INSERT INTO
                                                    VersionTeams
                                                VALUES(
                                                    @tid,
                                                    @vid)";

        private SqlCommand cmd;
        private SqlConnection conn;

        public DatabaseWriter()
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

        public void addEmployee(DBEmployee e)
        {
            cmd = new SqlCommand(insertEmpStr, conn);
            cmd.Parameters.AddWithValue("@title", e.title);
            cmd.Parameters.AddWithValue("@salary", e.salary);
            cmd.Parameters.AddWithValue("@name", e.name);
            execute(cmd);
        }

        public void addProject(DBProject p)
        {
            cmd = new SqlCommand(insertProjStr, conn);
            cmd.Parameters.AddWithValue("@name", p.name);
            cmd.Parameters.AddWithValue("@budget", p.budget);
            cmd.Parameters.AddWithValue("@desc", p.desc);
            execute(cmd);
        }

        public void addSpec(DBSpecification s)
        {
            cmd = new SqlCommand(insertSpecStr, conn);
            cmd.Parameters.AddWithValue("@name", s.name);
            cmd.Parameters.AddWithValue("@desc", s.desc);
            cmd.Parameters.AddWithValue("@pid", s.pid);
            execute(cmd);
        }

        public void addTeamMem(int eid, int tid)
        {
            cmd = new SqlCommand(insertTeamMemStr, conn);
            cmd.Parameters.AddWithValue("@eid", eid);
            cmd.Parameters.AddWithValue("@tid", tid);
            execute(cmd);
        }

        public void addTeam(DBTeam t)
        {
            cmd = new SqlCommand(insertTeamStr, conn);
            cmd.Parameters.AddWithValue("@name", t.name);
            cmd.Parameters.AddWithValue("@desc", t.desc);
            cmd.Parameters.AddWithValue("@leader", t.leader.id);
            execute(cmd);
        }
    }
}
