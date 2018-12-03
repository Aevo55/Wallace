using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using Wallace.Common.Models;

namespace Wallace.Common.Database
{
    class DatabaseDeleter
    {
        #region Queries
        private const string deleteEmployeeString = @"  DELETE FROM
                                                            Employees
                                                        WHERE
                                                            eId = @id";

        private const string deleteProjectsString = @"  DELETE FROM
                                                            Projects
                                                        WHERE
                                                            pId = @id";

        private const string deleteSpecsString = @"     DELETE FROM
                                                            Specifications
                                                        WHERE
                                                            sId = @id";

        private const string deleteTeamMemsString1 = @" DELETE FROM
                                                            TeamMembers
                                                        WHERE
                                                            eId = @id";

        private const string deleteTeamMemsString2 = @" DELETE FROM
                                                            TeamMembers
                                                        WHERE
                                                            tId = @id";

        private const string deleteTeamMemsString3 = @" DELETE FROM
                                                            TeamMembers
                                                        Where
                                                            tId = @tid
                                                            AND
                                                            eId = @eid";

        private const string deleteTeamString = @"      DELETE FROM
                                                            Teams
                                                        WHERE
                                                            tId = @id";

        private const string deleteVersionString = @"   DELETE FROM
                                                            Versions
                                                        WHERE
                                                            vId = @id";

        private const string deleteVersionSpecsStr1 = @"DELETE FROM
                                                            VersionSpecs
                                                        WHERE
                                                            vId = @id;";

        private const string deleteVersionSpecsStr2 = @"DELETE FROM
                                                            VersionSpecs
                                                        WHERE
                                                            sId = @id;";

        private const string deleteVersionSpecsStr3 = @"DELETE FROM
                                                            VersionSpecs
                                                        WHERE
                                                            vId = @vid
                                                            AND
                                                            sId = @sid";

        private const string deleteVersionTeamsStr1 = @"DELETE FROM
                                                            VersionTeams
                                                        WHERE
                                                            tId = @id";

        private const string deleteVersionTeamsStr2 = @"DELETE FROM
                                                            VersionTeams
                                                        WHERE
                                                            vId = @id";

        private const string deleteVersionTeamsStr3 = @"DELETE FROM
                                                            VersionTeams
                                                        WHERE
                                                            tId = @tid
                                                            AND
                                                            vId = @vid";
        #endregion
        
        private SqlCommand cmd;
        private SqlConnection conn;

        public DatabaseDeleter()
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

        public void delEmployee(int id)
        {
            cmd = new SqlCommand(deleteEmployeeString, conn);
            cmd.Parameters.AddWithValue("id", id);
            execute(cmd);
        }

        public void delProject(int id)
        {
            cmd = new SqlCommand(deleteProjectsString, conn);
            cmd.Parameters.AddWithValue("id", id);
            execute(cmd);
        }

        public void delSpec(int id)
        {
            cmd = new SqlCommand(deleteSpecsString, conn);
            cmd.Parameters.AddWithValue("id", id);
            execute(cmd);
        }

        public void delTeamMemByEmp(int id)
        {
            cmd = new SqlCommand(deleteTeamMemsString1, conn);
            cmd.Parameters.AddWithValue("id", id);
            execute(cmd);
        }

        public void delTeamMemByTeam(int id)
        {
            cmd = new SqlCommand(deleteTeamMemsString2, conn);
            cmd.Parameters.AddWithValue("id", id);
            execute(cmd);
        }

        public void delTeamMemByBoth(int tid, int eid)
        {
            cmd = new SqlCommand(deleteTeamMemsString3, conn);
            cmd.Parameters.AddWithValue("tid", tid);
            cmd.Parameters.AddWithValue("eid", eid);
            execute(cmd);
        }

        public void delTeam(int id)
        {
            cmd = new SqlCommand(deleteTeamString, conn);
            cmd.Parameters.AddWithValue("id", id);
            execute(cmd);
        }

        public void delVersion(int id)
        {
            cmd = new SqlCommand(deleteVersionString, conn);
            cmd.Parameters.AddWithValue("id", id);
            execute(cmd);
        }

        public void delVerSpecByVer(int id)
        {
            cmd = new SqlCommand(deleteVersionSpecsStr1, conn);
            cmd.Parameters.AddWithValue("id", id);
            execute(cmd);
        }

        public void delVerSpecBySpec(int id)
        {
            cmd = new SqlCommand(deleteVersionSpecsStr2, conn);
            cmd.Parameters.AddWithValue("id", id);
            execute(cmd);
        }

        public void delVerSpecByBoth(int vid, int sid)
        {
            cmd = new SqlCommand(deleteVersionSpecsStr3, conn);
            cmd.Parameters.AddWithValue("vid", vid);
            cmd.Parameters.AddWithValue("sid", sid);
            execute(cmd);
        }

        public void delVerTeamByTeam(int id)
        {
            cmd = new SqlCommand(deleteVersionTeamsStr1, conn);
            cmd.Parameters.AddWithValue("id", id);
            execute(cmd);
        }

        public void delVerTeamByVer(int id)
        {
            cmd = new SqlCommand(deleteVersionTeamsStr2, conn);
            cmd.Parameters.AddWithValue("id", id);
            execute(cmd);
        }

        public void delVerTeamByBoth(int tid, int vid)
        {
            cmd = new SqlCommand(deleteVersionTeamsStr3, conn);
            cmd.Parameters.AddWithValue("tid", tid);
            cmd.Parameters.AddWithValue("vid", vid);
        }
    }
}
