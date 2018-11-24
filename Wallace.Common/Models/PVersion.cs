using System;
using System.Collections.Generic;
using System.Text;
using Wallace.Common.Database;
namespace Wallace.Common.Models
{
    public class PVersion
    {
        public int id;
        public List<Spec> specs;
        public DateTime releaseDate;
        public int versionNumber;
        public List<Team> teams;

        public PVersion(DBVersion v)
        {
            releaseDate = v.release;
            versionNumber = v.vnum;
            id = v.id;
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
