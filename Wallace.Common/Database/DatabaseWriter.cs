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
                                                OUTPUT
                                                    Inserted.eId
                                                VALUES(
                                                    @title,
                                                    @salary,
                                                    @name)";

        private const string insertProjStr = @" INSERT INTO
                                                    Projects(
                                                        pName,
                                                        pBudget,
                                                        pDesc)
                                                OUTPUT
                                                    Inserted.pId
                                                VALUES(
                                                    @name,
                                                    @budget,
                                                    @desc)";

        private const string insertSpecStr = @" INSERT INTO
                                                    Specifications(
                                                        sName,
                                                        sDesc,
                                                        pId)
                                                OUTPUT
                                                    Inserted.sId
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
                                                OUTPUT
                                                    Inserted.tId
                                                VALUES(
                                                    @name,
                                                    @desc,
                                                    @leader)";

        private const string insertVerStr = @"  INSERT INTO
                                                    Versions(
                                                        pId,
                                                        vNum,
                                                        ReleaseDate)
                                                OUTPUT
                                                    Inserted.vId
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

        public int executeWithId(SqlCommand cmd)
        {
            try
            {
                cmd.Connection.Open();
                return (int)cmd.ExecuteScalar();

            }

            finally
            {
                cmd.Connection.Close();
            }
        }


        public int addEmployee(DBEmployee e)
        {
            cmd = new SqlCommand(insertEmpStr, conn);
            cmd.Parameters.AddWithValue("@title", e.title);
            cmd.Parameters.AddWithValue("@salary", e.salary);
            cmd.Parameters.AddWithValue("@name", e.name);
            return executeWithId(cmd);
        }

        public int addProject(DBProject p)
        {
            cmd = new SqlCommand(insertProjStr, conn);
            cmd.Parameters.AddWithValue("@name", p.name);
            cmd.Parameters.AddWithValue("@budget", p.budget);
            cmd.Parameters.AddWithValue("@desc", p.desc);
            return executeWithId(cmd);
        }

        public int addSpec(DBSpecification s)
        {
            cmd = new SqlCommand(insertSpecStr, conn);
            cmd.Parameters.AddWithValue("@name", s.name);
            cmd.Parameters.AddWithValue("@desc", s.desc);
            cmd.Parameters.AddWithValue("@pid", s.pid);
            return executeWithId(cmd);
        }

        public void addTeamMem(int eid, int tid)
        {
            cmd = new SqlCommand(insertTeamMemStr, conn);
            cmd.Parameters.AddWithValue("@eid", eid);
            cmd.Parameters.AddWithValue("@tid", tid);
            execute(cmd);
        }

        public int addTeam(DBTeam t)
        {
            cmd = new SqlCommand(insertTeamStr, conn);
            cmd.Parameters.AddWithValue("@name", t.name);
            cmd.Parameters.AddWithValue("@desc", t.desc);
            cmd.Parameters.AddWithValue("@leader", t.leader);
            return executeWithId(cmd);
        }

        public int addVersion(DBVersion v)
        {
            cmd = new SqlCommand(insertVerStr, conn);
            cmd.Parameters.AddWithValue("@pid",v.id);
            cmd.Parameters.AddWithValue("@num",v.vnum);
            cmd.Parameters.AddWithValue("@date",v.release.ToString("yyyy-MM-dd HH:mm:ss.fff"));
            return executeWithId(cmd);
        }

        public void addVersionSpec(int v, int s)
        {
            cmd = new SqlCommand(insertVerSpecStr, conn);
            cmd.Parameters.AddWithValue("@vid", v);
            cmd.Parameters.AddWithValue("@sid", s);
            execute(cmd);
        }

        public void addVersionTeam(int v, int t)
        {
            cmd = new SqlCommand(insertVerTeamStr, conn);
            cmd.Parameters.AddWithValue("@tid", v);
            cmd.Parameters.AddWithValue("@vid", t);
            execute(cmd);
        }
    }
}
