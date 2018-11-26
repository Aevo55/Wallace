using System;
using System.Collections.Generic;
using System.Text;
using Wallace.Common.Database;
namespace Wallace.Common.Models
{
    public class PVersion
    {
        public int id;
        public int pid;
        public List<Spec> specs;
        public DateTime releaseDate;
        public int versionNumber;
        public List<Team> teams;

        public PVersion()
        {
            specs = new List<Spec>();
            teams = new List<Team>();
        }

        public PVersion(DBVersion v)
        {
            releaseDate = v.release;
            versionNumber = v.vnum;
            pid = v.pid;
            id = v.id;
            specs = new List<Spec>();
            releaseDate = v.release;
            teams = new List<Team>();
        }

        public PVersion(List<Spec> _specs, DateTime _releaseDate, int _versionNumber, List<Team> _teams)
        {
            specs = new List<Spec>();
            teams = new List<Team>();

            specs = _specs;
            teams = _teams;
            releaseDate = _releaseDate;
            versionNumber = _versionNumber;
        }

    }
}
